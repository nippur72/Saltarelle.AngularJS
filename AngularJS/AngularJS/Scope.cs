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
      
      #region Watch

      [InlineCode("{this}.$watch({watchFunction},{listener})")]                    public void Watch<T>(string watchFunction, Action listener) {} 
      [InlineCode("{this}.$watch({watchFunction},{listener},{objectEquality})")]   public void Watch<T>(string watchFunction, Action listener, bool objectEquality) {} 
      [InlineCode("{this}.$watch({watchFunction},{listener})")]                    public void Watch<T>(string watchFunction, Action<T> listener) {} 
      [InlineCode("{this}.$watch({watchFunction},{listener},{objectEquality})")]   public void Watch<T>(string watchFunction, Action<T> listener, bool objectEquality) {}
      [InlineCode("{this}.$watch({watchFunction},{listener})")]                    public void Watch<T>(string watchFunction, WatchListener<T> listener) {} 
      [InlineCode("{this}.$watch({watchFunction},{listener},{objectEquality})")]   public void Watch<T>(string watchFunction, WatchListener<T> listener, bool objectEquality) {}

      [InlineCode("{this}.$watch({watchFunction},{listener})")]                    public void Watch<T>(Func<T> watchFunction, Action listener) {} 
      [InlineCode("{this}.$watch({watchFunction},{listener},{objectEquality})")]   public void Watch<T>(Func<T> watchFunction, Action listener, bool objectEquality) {} 
      [InlineCode("{this}.$watch({watchFunction},{listener})")]                    public void Watch<T>(Func<T> watchFunction, Action<T> listener) {} 
      [InlineCode("{this}.$watch({watchFunction},{listener},{objectEquality})")]   public void Watch<T>(Func<T> watchFunction, Action<T> listener, bool objectEquality) {}
      [InlineCode("{this}.$watch({watchFunction},{listener})")]                    public void Watch<T>(Func<T> watchFunction, WatchListener<T> listener) {} 
      [InlineCode("{this}.$watch({watchFunction},{listener},{objectEquality})")]   public void Watch<T>(Func<T> watchFunction, WatchListener<T> listener, bool objectEquality) {}
      
      #endregion 

      /*
      $id
      $destroy
      */
   } 
}

