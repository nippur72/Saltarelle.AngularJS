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
   [Imported]   
   public sealed class Interval
   {      
      /// <summary>
      /// Angular's wrapper for window.setInterval. The fn function is executed every delay milliseconds.
      /// Returns a promise which will be notified on each iteration.
      /// </summary>
      [InlineCode("{this}({function})")]
      public Promise Set(Action function) { return null; }

      /// <summary>
      /// Angular's wrapper for window.setInterval. The fn function is executed every delay milliseconds.
      /// Returns a promise which will be notified on each iteration.
      /// </summary>
      [InlineCode("{this}({function}, {delay})")]
      public Promise Set(Action function, int delay) { return null; }

      /// <summary>
      /// Angular's wrapper for window.setInterval. The fn function is executed every delay milliseconds.
      /// Returns a promise which will be notified on each iteration.
      /// </summary>
      [InlineCode("{this}({function}, {delay}, {count})")]
      public Promise Set(Action function, int delay, int count) { return null; } 
           
      /// <summary>
      /// Angular's wrapper for window.setInterval. The fn function is executed every delay milliseconds.
      /// Returns a promise which will be notified on each iteration.
      /// </summary>
      [InlineCode("{this}({function}, {delay}, {count}, {InvokeApply})")]
      public Promise Set(Action function, int delay, int count, bool InvokeApply) { return null; } 

      /// <summary>
      /// Cancels a task associated with the promise. As a result of this, the promise will be resolved with a rejection.
      /// Returns true if the task hasn't executed yet and was successfully canceled.
      /// </summary>
      [InlineCode("{this}.cancel({promise})")] public bool Cancel(Promise promise) { return false; }           
   }  
}

