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
   public delegate void WatchListener(object newValue, object oldValue);
   
   public class RootScope
   {             
   } 

   public class Http
   {
   }

   public class Location
   {
   }
   
   public interface IScope
   {
   }

   public class Scope : IScope
   {             
      /// <summary>
      /// Executes an expression in angular from outside of the angular framework
      /// </summary>      
      [InlineCode("{this}.$apply()")]
      public void Apply()
      {
      }

      /// <summary>
      /// Executes an expression in angular from outside of the angular framework
      /// </summary>      
      [InlineCode("{this}.$apply({expression})")]
      public object Apply(string expression)
      {
         return null;
      }

      /*
      $broadcast(name, args)
      $destroy()
      $digest()
      $emit(name, args)
      $eval(expression)
      $evalAsync(expression)
      $new(isolate)
      $on(name, listener)
      */
      
      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchExpression})")]
      public void Watch(string watchExpression)
      {
      }

      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchExpression},{listener})")]
      public void Watch(string watchExpression, Action listener)
      {
      }

      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchExpression},{listener},{objectEquality})")]
      public void Watch(string watchExpression, Action listener, bool objectEquality)
      {
      }
      
      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchExpression},{listener})")]
      public void Watch(string watchExpression, WatchListener listener)
      {
      }       

      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchExpression},{listener},{objectEquality})")]
      public void Watch(string watchExpression, WatchListener listener, bool objectEquality)
      {
      }

      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchFunction},{listener})")]
      public void Watch(Func<object> watchFunction, Action listener)
      {
      } 

      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchFunction},{listener},{objectEquality})")]
      public void Watch(Func<object> watchFunction, Action listener, bool objectEquality)
      {
      } 

      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchFunction},{listener})")]
      public void Watch(Func<object,object> watchFunction, Action listener)
      {
      } 

      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchFunction},{listener},{objectEquality})")]
      public void Watch(Func<object,object> watchFunction, Action listener, bool objectEquality)
      {
      } 

      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchFunction},{listener})")]
      public void Watch(Func<object> watchFunction, WatchListener listener)
      {
      } 

      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchFunction},{listener},{objectEquality})")]
      public void Watch(Func<object> watchFunction, WatchListener listener, bool objectEquality)
      {
      } 

      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchFunction},{listener})")]
      public void Watch(Func<object,object> watchFunction, WatchListener listener)
      {
      } 

      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchFunction},{listener},{objectEquality})")]
      public void Watch(Func<object,object> watchFunction, WatchListener listener, bool objectEquality)
      {
      } 

      /*
      $id
      $destroy
      */
   } 

   [Imported]
   public class Module
   {
      [InlineCode("{this}.controller({Name},{func})")]
      public void Controller(string Name, List<object> func)
      {
      }   
   }
   
   [Imported]
   public static class Angular
   {
      [InlineCode("angular.module({ModuleName},[])")]
      public static Module Module(string ModuleName)
      {
         return null;
      }

      public static Module Module(string ModuleName, object[] Requires)
      {
         return null;
      }
   }                       

   public class AngularControllers
   {                  
      private static string[] names = new[] { "$scope","$rootscope","$http","$location" };
      private static Type[] types = new Type[] { typeof(Scope), typeof(RootScope), typeof(Http), typeof(Location) };
       
      public static void RegisterControllers(Module App, AngularControllers contrs)
      {
         Type ct = contrs.GetType();

         BindingFlags bf = BindingFlags.Static | BindingFlags.Public;
         MethodInfo[] mis = ct.GetMethods(bf);         

         foreach(MethodInfo mi in mis)
         {
            RegisterController(App, mi, ct);
         }
      }

      public static void RegisterController(Module App, MethodInfo mi, Type ct)
      {
         List<object> NamedParameters = new List<object>();
                                             
         for(int j=0;j<mi.ParameterTypes.Length;j++)
         {
            Type t = mi.ParameterTypes[j];               
            bool found = false;
            for(int i=0;i<types.Length;i++)
            {
               if(t==types[i] || IsSubclassOf(t,types[i]))
               {  
                  NamedParameters.Add(names[i]);
                  found = true;
                  break;
               }
            }                        

            if(!found) throw new Exception("controller named parameter["+j.ToString()+"] of type '"+t.ToString()+"' not recognized");
         }   
         
         List<object> wr = new List<object>();
                                                                                                  
         foreach(string s in NamedParameters) wr.Add(s);

         object x = mi.CreateDelegate();

         // wr.Add(ct.FullName+"."+mi.ScriptName);                          

         wr.Add(x);                 
         
         App.Controller(mi.Name,wr);
      }

      [InlineCode("ss.isSubclassOf({target},{type})")]
      public static bool IsSubclassOf(Type target, Type type)
      {
         return false;
      }
   }
}

