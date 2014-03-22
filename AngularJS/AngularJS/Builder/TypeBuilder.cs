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
      public static List<string> GetInstanceMethodNames(this Type type)
      {
         List<string> result = new List<string>();
         foreach(string key in type.Prototype.Keys)
         {
            if(key!="constructor") result.Add(key);
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

      [InlineCode("{type}")]      
      public static Function ToFunction(this Type type)
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
         var parameters = Angular.Injector().Annotate(type.GetConstructorFunction());
                  
         if(this_mode == ThisMode.ScopeStrict)
         {
            // verifies that "scope" is the first parameter in constructor
            if(parameters.Count<1 || parameters[0]!="_scope")
            {
               throw new Exception(String.Format("Controller {0} must specify '_scope' as first parameter in its constructor",type.Name));
            } 
         }
                  
         // takes method into $scope, binding "$scope" to "this"                 
         foreach(string funcname in type.GetInstanceMethodNames())
         {
            body += String.Format("{2}.{1} = {0}.prototype.{1}.bind({2});\r\n",type.FullName,funcname,thisref);             
         }
                  
         // put call at the end so that methods are defined first
         body+=String.Format("{0}.apply({1},arguments);\r\n",type.FullName,thisref);

         if(return_function!=null)
         {
            if(return_function_call) body+=String.Format("return {1}.{0}();\r\n",return_function,thisref);   
            else                     body+=String.Format("return {1}.{0}  ;\r\n",return_function,thisref);   
            
            if(!type.GetInstanceMethodNames().Contains(return_function))
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

         // builds array, but also FIX $injection in the type
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
}

