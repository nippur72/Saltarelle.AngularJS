using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;
using System.Reflection;
using System.Diagnostics;

namespace AngularJS
{         
   public static class ModuleBuilder
   {              
      public static string PatchDollarName(string name)
      {
         if(name.StartsWith("_")) return "$"+name.Substring(1);
         else return name;
      }

      public static string[] PatchDollarName(string[] names)
      {
         List<string> result = new List<string>();

         for(int t=0;t<names.Length;t++)
         {
            result.Add(PatchDollarName(names[t]));
         }

         return result.ToArray();
      }

      public static string CommaSeparatedList(string[] parameters)
      {
         string result = "";
         for(int t=0;t<parameters.Length;t++)
         {
            result+=parameters[t];
            if(t!=parameters.Length-1) result+=",";
         }
         return result;
      }      

      public static string[] FixAnnotation(Type type)
      {
         Injectable constructor = type.GetConstructorFunction();
         
         // gets and annotate constructor parameter; annotations are stored in type.$inject                                             
         var parameters = PatchDollarName(Angular.Injector().Annotate(constructor));
         
         // fix "$" in parameter names
         constructor.Inject = parameters;
         
         return parameters;                        
      }

      // TODO: provider, value, constant

      #region Controllers      

      public static void Controller<T>(this Module module)
      {         
         Type type = typeof(T);
         FixAnnotation(type);                  
         Controller(module,type.Name,type);
      }

      #endregion

      #region Services
      
      public static void Service<T>(this Module module)
      {         
         Type type = typeof(T);
         FixAnnotation(type); 

         // patch service name for names starting with "$"                
         string servicename = PatchDollarName(typeof(T).Name); 
           
         Service(module,servicename,type);
      }

      #endregion 

      #region Configs

      public static void Config<T>(this Module module)
      {
         Type type = typeof(T);
         FixAnnotation(type); 
         Config(module,type);
      }

      #endregion

      #region Runs

      public static void Run<T>(this Module module)
      {       
         Type type = typeof(T);
         var parameters = FixAnnotation(type);          
         var plist = CommaSeparatedList(parameters);
                  
         // "run" function are called without a "this" reference, so we need to instantiate the class with "new"
         string body = "{ new "+type.Name+"("+plist+"); }";
         Function F = new Function(parameters,body);            
         
         Injectable.From(F).Inject = parameters;
         
         Run(module,F);
      }

      #endregion

      #region Factory

      public static void Factory<T>(this Module module)
      {         
         Type type = typeof(T);
         var parameters = FixAnnotation(type); 
         var plist = CommaSeparatedList(parameters);
                  
         // register all public instance methods as factory                      
         foreach(string funcname in type.GetInstanceMethodNames())
         {
            string body = "{ return (new "+type.Name+"("+plist+"))."+funcname+"(); }";
            Function F = new Function(parameters,body);
            Factory(module,PatchDollarName(funcname),F);
         }
      }
            
      #endregion

      #region Filters
     
      public static void Filter<T>(this Module module)
      {         
         Type type = typeof(T);
         var parameters = FixAnnotation(type); 
         var plist = CommaSeparatedList(parameters);                         

         // register all public instance methods as filters                      
         foreach(string funcname in type.GetInstanceMethodNames())
         {
            string body = "{ var $ob = new "+type.Name+"("+plist+"); return $ob."+funcname+"; }";
            Function F = new Function(parameters,body);                        
            Filter(module,PatchDollarName(funcname),F);
         }
      }      

      #endregion     

      #region Directives                 

      public static void Directive<T>(this Module module) where T: IDirective
      {        
         Type type = typeof(T);
         var parameters = FixAnnotation(type); 
         var plist = CommaSeparatedList(parameters);

         // a directive is a (injectable) function returning a definition object
         string body = "{ var $ob = new "+type.Name+"("+plist+"); return $ob.GetDefinition(); }";
         Function F = new Function(parameters,body);
                     
         // extract directive name from the class name
         string DirectiveName = type.Name;
         if(!DirectiveName.EndsWith("Directive")) throw new Exception("'"+DirectiveName+"' must end with the suffix 'Directive'");
         DirectiveName = DirectiveName.Substring(0,DirectiveName.Length-9);         
         
         Directive(module,DirectiveName,F);         
      }      
         
      #endregion

      #region Animations            

      public static void Animation<T>(this Module module, string name=null)
      {         
         /*
         Type type = typeof(T);

         // TODO when there will be IsSubClassOf
         //if(!type.IsSubclassOf(DirectiveDefinition)) throw new Exception(String.Format("{0} is not sub class of {1}",type.Name,typeof(DirectiveDefinition).Name);

         Function fun = CreateAnimationFunction(type);
         var parameters = Angular.Injector().Annotate(fun);          
         var fcall = fun.CreateFunctionCall(parameters);       
         Animation(module, name==null ? type.Name : name, fcall);
         */
      }

      private static Function CreateAnimationFunction(Type type)
      {
         return null;
         /*
         string body = "";
         string thisref = "this";  
         
         body+="var $animob = {};\r\n"; 
         
         // gets and annotate constructor parameter; annotations are stored in type.$inject                                             
         var parameters = Angular.Injector().Annotate(type.GetConstructorFunction());
                                    
         // takes method into $scope, binding "$scope" to "this"                 
         foreach(string funcname in type.GetInstanceMethodNames())
         {
            body += String.Format("{2}.{1} = {0}.prototype.{1}.bind({2});\r\n",type.FullName,funcname,thisref);             

            if(funcname=="Start" || funcname=="Setup" || funcname=="Cancel" )
            {
               body += String.Format("$animob.{0} = {2}.{1};\r\n",funcname.ToLower(),funcname,thisref);                
            }
         }
                  
         // put call at the end so that methods are defined first
         body+=String.Format("{0}.apply({1},arguments);\r\n",type.FullName,thisref);
         body+=String.Format("return $animob;\r\n");   
         return TypeExtensionMethods.CreateNewFunction(parameters,body);
         */
      }
                
      #endregion

      #region Low level Angular methods

      [InlineCode("{module}.config({func})")]
      public static void Config(Module module, object func) { }    

      [InlineCode("{module}.controller({Name},{func})")]
      public static void Controller(Module module, string Name, object func) { }            

      [InlineCode("{module}.directive({Name},{defob})")]
      public static void Directive(Module module, string Name, object defob) { }

      [InlineCode("{module}.factory({Name},{func})")]
      public static void Factory(Module module, string Name, object func) { }          

      [InlineCode("{module}.filter({FilterName},{ob})")]
      public static void Filter(Module module, string FilterName, object ob) { }            

      [InlineCode("{module}.service({Name},{ob})")]
      public static void Service(Module module, string Name, object ob) { }          

      [InlineCode("{module}.run({func})")]
      public static void Run(Module module, object func) { }    

      [InlineCode("{module}.animation({Name},{func})")]
      public static void Animation(Module module, string Name, object func) { }          

      #endregion
   }

}

