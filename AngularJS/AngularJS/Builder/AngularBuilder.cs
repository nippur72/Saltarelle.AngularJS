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
   #region Comment explaining how classes are turned into function controllers
   /*
   
   injectable objects:
      - Service 
      - Factory 
      - Provider
      - Value
      - Constant

   non injectable objects:
      - Config 
      - Run 

   special purpose objects
      - controller
      - directive
      - animation
      - filter
   

   // config:     this = global   (no name required)
   // directive:  this = global 

   // factory:    this = new object 
   // controller: this = new object   // scope patched
   // filter:     this = new object 
   // service:    this = new object 

   // as controller: requires $scope as first parameter, inject derived from constructor
   function($scope,injectables)
   {
      $scope.remove = ControllerClass.prototype.remove.bind($scope);
      $scope.clear = ControllerClass.prototype.clear.bind($scope);
      ControllerExample.apply($scope,arguments);  // this = $scope
   }

   // as config: does not require $scope as first parameter, inject derived from constructor
   function()
   {
      this.remove = ControllerClass.prototype.remove.bind(this);
      this.clear = ControllerClass.prototype.clear.bind(this);
      ControllerExample.apply(this,arguments);  
   }

   // as factory: static methods are registered one by one, with their own injection
   function(_http)
   {
   }

   // as filter: does not require $scope as first parameter, inject derived from constructor, each method is mapped separately 
   function()
   {
      this.euro = FilterEuro.prototype.bind(this);
      FilterEuro.apply(this,arguments);
      return this.euro;
   }

   */
   #endregion

   public static class AngularBuilder
   {              
      public static string PatchDollarName(string name)
      {
         if(name.StartsWith("_")) return "$"+name.Substring(1);
         else return name;
      }

      #region Controllers

      public static void Controller<T>(this Module module)
      {         
         Type type = typeof(T);
      
         // TODO
         // if(!type.IsSubClassOf(Scope)) throw new Exception("controller must be derived from Scope class");
         
         Function fun = type.BuildControllerFunction(ThisMode.ScopeStrict);     
         
         var parameters = type.ReadInjection();         
         var fcall = fun.CreateFunctionCall(parameters);         
         Controller(module,type.Name,fcall);
      }
      
      #endregion

      #region Services
      
      public static void Service<T>(this Module module)
      {         
         Type type = typeof(T);
         var parameters = Angular.Injector().Annotate(type.GetConstructorFunction());         
         type.ToFunction().CreateFunctionCall(parameters); // only used to fix the "_" to "$" in type.$inject
         string servicename = typeof(T).Name; // TODO: fix for names starting with "_" ?    

         // patch service name for names starting with "$"
         servicename = PatchDollarName(servicename);         
  
         Service(module,servicename,type);
      }

      #endregion 

      #region Factory

      public static void Factory<T>(this Module module)
      {         
         Type type = typeof(T);
               
         // register all public instance methods as filters                       
         foreach(string funcname in type.GetInstanceMethodNames())
         {
            module.RegisterFactory(type,funcname);
         }
      }

      private static void RegisterFactory(this Module module, Type type, string funcname)
      {
         Function fun = type.BuildControllerFunction(ThisMode.This,funcname,true);         
                  
         var parameters = type.ReadInjection();
         var fcall = fun.CreateFunctionCall(parameters); 
         
         // patch function name for names starting with "$"
         funcname = PatchDollarName(funcname);
                 
         Factory(module,funcname,fcall);
      }     
      
      #endregion

      #region Filters
     
      public static void Filter<T>(this Module module)
      {         
         Type type = typeof(T);

         // register all public instance methods as filters                       
         foreach(string funcname in type.GetInstanceMethodNames())
         {
            module.RegisterFilter(type,funcname);
         }
      }

      private static void RegisterFilter(this Module module, Type type, string funcname)
      {
         Function fun = type.BuildControllerFunction(ThisMode.NewObject,funcname);         
         
         var parameters = type.ReadInjection();
         var fcall = fun.CreateFunctionCall(parameters);         
         Filter(module,funcname,fcall);
      }

      #endregion
      
      #region Configs

      public static void Config<T>(this Module module)
      {
         Type type = typeof(T);
         Function fun = type.BuildControllerFunction(ThisMode.NewObject);                
         var parameters = type.ReadInjection();         
         var fcall = fun.CreateFunctionCall(parameters);         
         Config(module,fcall);
      }

      #endregion

      #region Runs

      public static void Run<T>(this Module module)
      {
         Type type = typeof(T);
         Function fun = type.BuildControllerFunction(ThisMode.NewObject);                
         var parameters = type.ReadInjection();         
         var fcall = fun.CreateFunctionCall(parameters);         
         Run(module,fcall);
      }

      #endregion

      #region Directives            

      public static void Directive<T>(this Module module)
      {         
         Type type = typeof(T);

         // TODO when there will be IsSubClassOf
         //if(!type.IsSubclassOf(DirectiveDefinition)) throw new Exception(String.Format("{0} is not sub class of {1}",type.Name,typeof(DirectiveDefinition).Name);

         DirectiveDefinition dirob = (DirectiveDefinition) Activator.CreateInstance(type);

         Function fun = dirob.CreateDirectiveFunction();
         var parameters = Angular.Injector().Annotate(fun);          
         var fcall = fun.CreateFunctionCall(parameters);       
         Directive(module, dirob.Name, fcall);
      }   
      
      #endregion

      #region Animations            

      public static void Animation<T>(this Module module, string name=null)
      {         
         Type type = typeof(T);

         // TODO when there will be IsSubClassOf
         //if(!type.IsSubclassOf(DirectiveDefinition)) throw new Exception(String.Format("{0} is not sub class of {1}",type.Name,typeof(DirectiveDefinition).Name);

         Function fun = CreateAnimationFunction(type);
         var parameters = Angular.Injector().Annotate(fun);          
         var fcall = fun.CreateFunctionCall(parameters);       
         Animation(module, name==null ? type.Name : name, fcall);
      }

      private static Function CreateAnimationFunction(Type type)
      {
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

      [InlineCode("{module}.service({Name},{func})")]
      public static void Service(Module module, string Name, Type func) { }          

      [InlineCode("{module}.run({func})")]
      public static void Run(Module module, object func) { }    

      [InlineCode("{module}.animation({Name},{func})")]
      public static void Animation(Module module, string Name, object func) { }          

      #endregion
   }

}

