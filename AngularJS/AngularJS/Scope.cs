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
   //public delegate void WatchListener(object newValue, object oldValue);
   public delegate void WatchListener<T>(T newValue, T oldValue);
      
   public class Scope 
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
      
      /*
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
      */

      /*
      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchFunction},{listener})")]
      public void Watch<T>(string watchFunction, WatchListener<T> listener)
      {
      } 

      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchFunction},{listener},{objectEquality})")]
      public void Watch<T>(string watchFunction, WatchListener<T> listener, bool objectEquality)
      {
      } 
      */

      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchFunction},{listener})")]
      public void Watch<T>(Func<T> watchFunction, Action listener)
      {
      } 

      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchFunction},{listener},{objectEquality})")]
      public void Watch<T>(Func<T> watchFunction, Action listener, bool objectEquality)
      {
      } 

      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchFunction},{listener})")]
      public void Watch<T>(Func<T> watchFunction, WatchListener<T> listener)
      {
      } 

      /// <summary>
      /// Registers a listener callback to be executed whenever the watchExpression changes.
      /// </summary>
      [InlineCode("{this}.$watch({watchFunction},{listener},{objectEquality})")]
      public void Watch<T>(Func<T> watchFunction, WatchListener<T> listener, bool objectEquality)
      {
      } 

      /*
      $id
      $destroy
      */
   } 
}

