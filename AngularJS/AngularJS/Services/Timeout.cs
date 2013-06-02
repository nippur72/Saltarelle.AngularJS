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
   public sealed class Timeout
   {
      [InlineCode("{this}({function})")]
      public Promise Function(Action function) { return null; }

      [InlineCode("{this}({function}, {delay})")]
      public Promise Function(Action function, int delay) { return null; }

      [InlineCode("{this}({function}, {delay}, {InvokeApply})")]
      public Promise Function(Action function, int delay, bool InvokeApply) { return null; } 
           
      /// <summary>
      /// Cancels a task associated with the promise. As a result of this, the promise will be resolved with a rejection.
      /// Returns true if the task hasn't executed yet and was successfully canceled.
      /// </summary>
      [InlineCode("{this}.cancel({promise})")] public bool Cancel(Promise promise) { return false; }           
   }  
}

