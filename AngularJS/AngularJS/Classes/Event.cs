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
}

