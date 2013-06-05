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

   public class Event
   {                     
      /// <summary>
      /// the scope on which the event was $emit-ed or $broadcast-ed.
      /// </summary>      
      [ScriptName("targetScope")]
      public Scope TargetScope;
      
      /// <summary>
      /// the current scope which is handling the event.
      /// </summary>  
      [ScriptName("currentScope")]    
      public Scope CurrentScope; 
      
      /// <summary>
      /// Name of the event.
      /// </summary>  
      [ScriptName("name")]    
      public string Name; 
      
      /// <summary>
      /// calling stopPropagation function will cancel further event propagation (available only for events that were $emit-ed).
      /// </summary>  
      [ScriptName("stopPropagation")]    
      public Action StopPropagation; 
      
      /// <summary>
      /// calling preventDefault sets defaultPrevented flag to true.
      /// </summary>  
      [ScriptName("preventDefault")]    
      public Action PreventDefault; 
      
      /// <summary>
      /// true if preventDefault was called.   
      /// </summary>  
      [ScriptName("defaultPrevented")]    
      public bool DefaultPrevented; 
   }
      
   public class Scope 
   {             
      public int Id
      {
         [InlineCode("{this}.$id")]
         get { return 0; }
      }

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
      public T Apply<T>(string expression)
      {
         return default(T);
      }      

      /// <summary>
      /// Executes an expression in angular from outside of the angular framework
      /// </summary>      
      [InlineCode("{this}.$apply({function})")]
      public T Apply<T>(Func<T,Scope> function)
      {
         return default(T);
      }      
      
      /// <summary>
      /// Dispatches an event name downwards to all child scopes (and their children) notifying the registered listeners.
      /// </summary>            
      [ExpandParams]
      [InlineCode("{this}.$broadcast({name},{args})")]      
      public Event Broadcast(string name, params object[] args)
      {
         return null;
      }      

      /// <summary>
      /// Removes the current scope (and all of its children) from the parent scope.
      /// </summary>                  
      [InlineCode("{this}.$destroy()")]      
      public void Destroy()
      {         
      }      
      
      /// <summary>
      /// Processes all of the watchers of the current scope and its children.
      /// </summary>                  
      [InlineCode("{this}.$digest()")]      
      public void Digest()
      {         
      }      

      /// <summary>
      /// Dispatches an event name upwards through the scope hierarchy notifying the registered listeners.
      /// </summary>            
      [ExpandParams]
      [InlineCode("{this}.$emit({name},{args})")]      
      public Event Emit(string name, params object[] args)
      {
         return null;
      }    
      
      /// <summary>
      /// Executes the expression on the current scope returning the result.
      /// </summary>      
      [InlineCode("{this}.$eval({expression})")]
      public T Eval<T>(string expression)
      {
         return default(T);
      }      

      /// <summary>
      /// Executes the expression on the current scope returning the result.
      /// </summary>      
      [InlineCode("{this}.$eval({function})")]
      public T Eval<T>(Func<T,Scope> function)
      {
         return default(T);
      }      

      /// <summary>
      /// Executes the expression on the current scope at a later point in time.
      /// </summary>      
      [InlineCode("{this}.$evalAsync({expression})")]
      public T EvalAsync<T>(string expression)
      {
         return default(T);
      }      

      /// <summary>
      /// Executes the expression on the current scope at a later point in time.
      /// </summary>      
      [InlineCode("{this}.$evalAsync({function})")]
      public T EvalAsync<T>(Func<T,Scope> function)
      {
         return default(T);
      }      

      /// <summary>
      /// Creates a new child scope.
      /// </summary>      
      [InlineCode("{this}.$new({isolate})")]
      public Scope New(bool isolate)
      {
         return null;
      }
      
      /// <summary>
      /// Listens on events of a given type.
      /// </summary>      
      [InlineCode("{this}.$on({name},{listener})")] public Action On(string name, Action<Event> listener)  { return null; }     
      [InlineCode("{this}.$on({name},{listener})")] public Action On<T1>(string name, Action<Event,T1> listener)  { return null; }     
      [InlineCode("{this}.$on({name},{listener})")] public Action On<T1,T2>(string name, Action<Event,T1,T2> listener)  { return null; }     
      [InlineCode("{this}.$on({name},{listener})")] public Action On<T1,T2,T3>(string name, Action<Event,T1,T2,T3> listener)  { return null; }     
      [InlineCode("{this}.$on({name},{listener})")] public Action On<T1,T2,T3,T4>(string name, Action<Event,T1,T2,T3,T4> listener)  { return null; }     
      [InlineCode("{this}.$on({name},{listener})")] public Action On<T1,T2,T3,T4,T5>(string name, Action<Event,T1,T2,T3,T4,T5> listener)  { return null; }     
      
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
   } 
}

