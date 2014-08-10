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

      public static string[] FixAnnotation(Type type, params string[] annotations)
      {         
         Injectable constructor = type.GetConstructorFunction();
         string[] parameters = null;
         
         if(annotations != null && annotations.Length > 0)
         {
             // annotations are specified as argument 
             parameters = annotations;
         }
         else
         {
            var attrs = type.GetCustomAttributes(typeof(InjectAttribute),true);
            if(attrs.Length!=0)
            {
               // annotations are specified with the [Inject] decorator 
               parameters = (attrs[0] as InjectAttribute).Injectables;
            }
            else
            {
               // annotations are read from constructor parameter names
               // fix "$" in parameter names
               parameters = PatchDollarName(Angular.Injector().Annotate(constructor));
            }
         }
        
         // annotations are stored in type.$inject
         constructor.Inject = parameters;
         
         return parameters;                        
      }     

      #region Controllers      

      public static void Controller<T>(this Module module, params string[] annotations)
      {         
         Type type = typeof(T);
         type.FixGetterSetter();
         FixAnnotation(type, annotations);                   
         Controller(module,type.Name,type);
      }

      #endregion

      #region Services

      public static void Service<T>(this Module module, params string[] annotations)
      {         
         Type type = typeof(T);
         type.FixGetterSetter();
         FixAnnotation(type, annotations); 

         // patch service name for names starting with "$"                
         string servicename = PatchDollarName(typeof(T).Name); 
           
         Service(module,servicename,type);
      }

      #endregion 

      #region Configs

      public static void Config<T>(this Module module, params string[] annotations)
      {
         Type type = typeof(T);
         var parameters = FixAnnotation(type, annotations);          
         var plist = CommaSeparatedList(parameters);
                  
         // "run" function are called without a "this" reference, so we need to instantiate the class with "new"
         string body = "{ new "+type.FullName+"("+plist+"); }";
         Function F = new Function(parameters,body);                     
         
         Injectable.From(F).Inject = parameters;         
         Config(module,F);
      }

      #endregion

      #region Runs

      public static void Run<T>(this Module module, params string[] annotations)
      {       
         Type type = typeof(T);
         var parameters = FixAnnotation(type, annotations);          
         var plist = CommaSeparatedList(parameters);
                  
         // "run" function are called without a "this" reference, so we need to instantiate the class with "new"
         string body = "{ new "+type.FullName+"("+plist+"); }";
         Function F = new Function(parameters,body);            
         
         Injectable.From(F).Inject = parameters;
         
         Run(module,F);
      }

      #endregion      
     
      #region Factory

      public static void Factory<T>(this Module module, params string[] annotations)
      {                  
         Type type = typeof(T);
         type.FixGetterSetter();
         var parameters = FixAnnotation(type, annotations); 
         var plist = CommaSeparatedList(parameters);
                  
         // register all public instance methods as factory                      
         foreach(string funcname in type.GetInstanceMethodNames())
         {
            string body = "{ return (new "+type.FullName+"("+plist+"))."+funcname+"(); }";
            Function F = new Function(parameters,body);
            Factory(module,PatchDollarName(funcname),F);
         }
      }
            
      #endregion

      #region Provider

      public static void Provider<T>(this Module module, params string[] annotations)
      {                         
         Type type = typeof(T);
         FixAnnotation(type, annotations); 

         string providerName = type.FullName;
         if(!providerName.EndsWith("Provider")) throw new Exception("provider names must end with the suffix 'Provider'");
         string serviceName = providerName.Substring(0,providerName.Length-8);                   
           
         Provider(module,serviceName,type);
      }
            
      #endregion

      #region Filters

      public static void Filter<T>(this Module module, params string[] annotations)
      {         
         Type type = typeof(T);
         var parameters = FixAnnotation(type, annotations); 
         var plist = CommaSeparatedList(parameters);                         

         // register all public instance methods as filters                      
         foreach(string funcname in type.GetInstanceMethodNames())
         {
            string body = "{ var $ob = new "+type.FullName+"("+plist+"); return $ob."+funcname+".bind($ob); }";  // bind required because reference to this is lost somewhere
            Function F = new Function(parameters,body);                        
            Filter(module,PatchDollarName(funcname),F);
         }
      }      

      #endregion     

      #region Directives                 

      public static void Directive<T>(this Module module, params string[] annotations) where T : IDirective
      {        
         Type type = typeof(T);
         var parameters = FixAnnotation(type, annotations); 
         var plist = CommaSeparatedList(parameters);

         // a directive is a (injectable) function returning a definition object
         string body = "{ var $ob = new "+type.FullName+"("+plist+"); return $ob.GetDefinition(); }";
         Function F = new Function(parameters,body);
                     
         // extract directive name from the class name
         string DirectiveName = type.Name;
         if(!DirectiveName.EndsWith("Directive")) throw new Exception("'"+DirectiveName+"' must end with the suffix 'Directive'");
         DirectiveName = DirectiveName.Substring(0,DirectiveName.Length-9);         
         
         Directive(module,DirectiveName,F);         
      }      
         
      #endregion

      #region Animations            

      public static void Animation<T>(this Module module, string name, params string[] annotations) where T : AngularJS.Animate.IAnimation
      {         
         Type type = typeof(T);
         var parameters = FixAnnotation(type, annotations); 
         var plist = CommaSeparatedList(parameters);

         // an animation is a (injectable) function returning a definition object
         string body = "{ var $ob = new "+type.FullName+"("+plist+"); return $ob.GetDefinition(); }";
         Function F = new Function(parameters,body);
                     
         // extract directive name from the class name         
         Animation(module,name,F);         
      }   
                        
      #endregion

      #region Low level Angular methods

      [InlineCode("{module}.animation({Name},{func})")]
      public static void Animation(Module module, string Name, object func) { }          

      [InlineCode("{module}.config({func})")]
      public static void Config(Module module, object func) { }    

      [InlineCode("{module}.constant({Name},{value})")]
      public static void Constant(this Module module, string Name, object value) { }            

      [InlineCode("{module}.controller({Name},{func})")]
      public static void Controller(Module module, string Name, object func) { }            

      [InlineCode("{module}.decorator({Name},{func})")]
      public static void Decorator(Module module, string Name, object func) { }          

      [InlineCode("{module}.directive({Name},{defob})")]
      public static void Directive(Module module, string Name, object defob) { }

      [InlineCode("{module}.factory({Name},{func})")]
      public static void Factory(Module module, string Name, object func) { }          

      [InlineCode("{module}.provider({Name},{func})")]
      public static void Provider(Module module, string Name, object func) { }          

      [InlineCode("{module}.filter({FilterName},{ob})")]
      public static void Filter(Module module, string FilterName, object ob) { }            

      [InlineCode("{module}.run({func})")]
      public static void Run(Module module, object func) { }    

      [InlineCode("{module}.service({Name},{ob})")]
      public static void Service(Module module, string Name, object ob) { }          

      [InlineCode("{module}.value({Name},{value})")]
      public static void Value(this Module module, string Name, object value) { }            

      #endregion
   }

}

