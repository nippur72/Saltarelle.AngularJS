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
   public enum ThisMode { ScopeStrict, Scope, This, NewObject};

   public static class TypeExtensionMethods
   {
      public static List<string> GetPublicInstanceMethodNames(this Type type)
      {
         List<string> result = new List<string>();
         foreach(string key in type.Prototype.Keys)
         {
            if(key!="constructor" && !key.StartsWith("$")) result.Add(key);
         }   
         return result;
      }

      public static Function GetConstructorFunction(this Type type)
      {         
         return (Function) type.Prototype["constructor"];                 
      }

      [InlineCode("{type}.$inject")]      
      public static List<string> ReadInjection(this Type type)
      {
         return null;
      }      

      [InlineCode("{type}[{funcname}]")]
      public static Function GetKey(this Type type, string funcname) { return null; }

      [InlineCode("new Function({args},{body})")]
      public static Function CreateNewFunction(List<string> args, string body) { return null; }

      #region Basic Function builder      

      public static Function BuildControllerFunction(this Type type, ThisMode this_mode, string return_function=null, bool return_function_call=false)
      {         
         string body = "";
         string thisref = "";  
         
              if(this_mode == ThisMode.NewObject)   thisref = "$self";  
         else if(this_mode == ThisMode.ScopeStrict) thisref = "_scope";
         else if(this_mode == ThisMode.Scope)       thisref = "_scope";
         else if(this_mode == ThisMode.This)        thisref = "this";

         if(this_mode == ThisMode.NewObject) body+="var $self = new Object();"; 
         
         // gets and annotate constructor parameter; annotations are stored in type.$inject                                             
         var parameters = Injector.Annotate(type.GetConstructorFunction());
                  
         if(this_mode == ThisMode.ScopeStrict)
         {
            // verifies that "scope" is the first parameter in constructor
            if(parameters.Count<1 || parameters[0]!="_scope")
            {
               throw new Exception(String.Format("Controller {0} must specify '_scope' as first parameter in its constructor",type.Name));
            } 
         }
                  
         // takes method into $scope, binding "$scope" to "this"                 
         foreach(string funcname in type.GetPublicInstanceMethodNames())
         {
            body += String.Format("{2}.{1} = {0}.prototype.{1}.bind({2});\r\n",type.FullName,funcname,thisref);             
         }
                  
         // put call at the end so that methods are defined first
         body+=String.Format("{0}.apply({1},arguments);\r\n",type.FullName,thisref);

         if(return_function!=null)
         {
            if(return_function_call) body+=String.Format("return {1}.{0}();\r\n",return_function,thisref);   
            else                     body+=String.Format("return {1}.{0}  ;\r\n",return_function,thisref);   
            
            if(!type.GetPublicInstanceMethodNames().Contains(return_function))
            {
               throw new Exception("function '"+return_function+"' not defined in controller '"+type.Name+"'");
            }
         }

         return TypeExtensionMethods.CreateNewFunction(parameters,body);
      }

      #endregion
   }

   public static class FunctionExtensionMethods
   {
      public static object CreateFunctionCall(this Function fun, List<string> parameters) 
      {
         // if no parameters, takes function out of the array
         if(parameters.Count==0) return fun;

         // builds array
         List<object> result = new List<object>();
         for(int t=0;t<parameters.Count;t++)
         {
            if(parameters[t].StartsWith("_")) parameters[t] = "$" + parameters[t].Substring(1);
            result.Add(parameters[t]);
         }                           
         result.Add(fun);
         return result;
      }      
   }

   #region Comment explaining how classes are turned into function controllers
   /*
   public class ControllerClass
   {
      public string a;

      public ControllerClass(Scope _scope, Http _http)
      {
         a = "done";
      }

      public void remove(int index) { ... }

      public void clear() { ... }

      public static List<string> Items(Http _http) { return ...; }
   }

   // *** resume ***
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

   public static class AngularUtils
   {        
      #region Controllers

      public static void RegisterController(this Module module, Type type)
      {
         // TODO
         // if(!type.IsSubClassOf(Scope)) throw new Exception("controller must be derived from Scope class");
         
         Function fun = type.BuildControllerFunction(ThisMode.ScopeStrict);     
         
         var parameters = type.ReadInjection();         
         var fcall = fun.CreateFunctionCall(parameters);         
         module.Controller(type.Name,fcall);
      }
      
      #endregion

      #region Factory

      public static void RegisterFactory(this Module module, Type type)
      {         
         // register all public instance methods as filters                       
         foreach(string funcname in type.GetPublicInstanceMethodNames())
         {
            module.RegisterFactory(type,funcname);
         }
      }

      private static void RegisterFactory(this Module module, Type type, string funcname)
      {
         Function fun = type.BuildControllerFunction(ThisMode.This,funcname,true);         
         
         var parameters = type.ReadInjection();
         var fcall = fun.CreateFunctionCall(parameters);         
         module.Factory(funcname,fcall);
      }     

      //
      // Factor is a special case, it does use function builder (yet)
      //

      public static void RegisterFactoryOld(this Module module, Type type)
      {         
         // scan class static methods (contained in Object.keys)
         var keys = Object.Keys(type);
                           
         foreach(string funcname in keys)
         {
            // skips reserved and private methods
            if(!funcname.StartsWith("__") && !funcname.StartsWith("$"))
            {
               var fun = type.GetKey(funcname);
               
               // make sure it's a function
               if(fun.GetType()==typeof(Function))
               {                          
                  var parameters = Injector.Annotate(fun);
                  var injarr = fun.CreateFunctionCall(parameters);                   
                  module.Factory(funcname,injarr);                  
               }
            }
         }
      }
      #endregion

      #region Filters
     
      public static void RegisterFilter(this Module module, Type type)
      {         
         // register all public instance methods as filters                       
         foreach(string funcname in type.GetPublicInstanceMethodNames())
         {
            module.RegisterFilter(type,funcname);
         }
      }

      private static void RegisterFilter(this Module module, Type type, string funcname)
      {
         Function fun = type.BuildControllerFunction(ThisMode.NewObject,funcname);         
         
         var parameters = type.ReadInjection();
         var fcall = fun.CreateFunctionCall(parameters);         
         module.Filter(funcname,fcall);
      }

      #endregion
      
      #region Configs

      public static void RegisterConfig(this Module module, Type type)
      {
         Function fun = type.BuildControllerFunction(ThisMode.NewObject);                
         var parameters = type.ReadInjection();         
         var fcall = fun.CreateFunctionCall(parameters);         
         module.Config(fcall);
      }

      #endregion

      #region Directives            

      public static void RegisterDirective(this Module module, DirectiveDefinition dirob)
      {
         Function fun = CreateDirectiveFunction(dirob);
         var parameters = Injector.Annotate(fun);          
         var fcall = fun.CreateFunctionCall(parameters);       
         module.Directive(dirob.Name, fcall);
      }

      public static Function CreateDirectiveFunction(DirectiveDefinition def)
      {         
         object defob = def.CreateDefinitionObject();
         
         List<string> parameters = new List<string>();
         List<string> fnames = new List<string>();

         Type type = def.DirectiveController;

         object SharedController = ((dynamic)defob).controller;

         if(type!=null)
         {
            parameters = Injector.Annotate(type.GetConstructorFunction());
            fnames = type.GetPublicInstanceMethodNames();
         }       

         string body = "";

         body += "var $obdef = " + Json.Stringify(defob)+";\r\n";

         if(type!=null && fnames.Contains("Link"))
         {
            body += "var $outer_arguments = arguments;\r\n";
            body += "$obdef.link = function(_scope) { \r\n";
         
            foreach(string funcname in fnames)
            {
               body += String.Format("   _scope.{1} = {0}.prototype.{1}.bind(_scope);\r\n",type.FullName,funcname);             
            }
            
            body += String.Format("   {0}.apply(_scope,$outer_arguments);\r\n",type.FullName);
            body += "   _scope.Link.apply(_scope,arguments);\r\n";
            body += "}\r\n";
         }

         if(SharedController!=null)
         {
            body+= "$obdef.controller = "+SharedController.ToString()+";";
         }
         
         body += "return $obdef;\r\n";

         return TypeExtensionMethods.CreateNewFunction(parameters,body);
      }
      
      /*
      public static void RegisterDirectiveAsFactory(this Module module, string nn, Type type)
      {
         Function fun = type.BuildControllerFunction(ThisMode.NewObject,"Link");
         var parameteres = type.ReadInjection();
         var fcall = fun.CreateFunctionCall(parameteres);
         module.Directive2(nn, fcall);
      }
      */

      #endregion
   }
}

