using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;
using System.Reflection;
using System.Diagnostics;

namespace AngularJS.Animate
{          
   public interface IAnimation
   {
      object GetDefinition();
   }    

   [Imported]   
   public sealed class Animate
   {      
      public Action enter(jElement element, jElement parentElement, jElement afterElement) { return null; }
      public Action enter(jElement element, jElement parentElement, jElement afterElement, Action doneCallback) { return null; }

      public Action leave(jElement element) { return null; }
      public Action leave(jElement element, Action doneCallback) { return null; }

      public Action move(jElement element, jElement parentElement, jElement afterElement) { return null; }
      public Action move(jElement element, jElement parentElement, jElement afterElement, Action doneCallback) { return null; }

      public Action addClass(jElement element, string className) { return null; }
      public Action addClass(jElement element, string className, Action doneCallback) { return null; }

      public Action removeClass(jElement element, string className) { return null; }
      public Action removeClass(jElement element, string className, Action doneCallback) { return null; }

      public Action setClass(jElement element, string add, string remove) { return null; }
      public Action setClass(jElement element, string add, string remove, Action doneCallback) { return null; }
      
      public bool enabled() { return false; }
      public bool enabled(bool value) { return false; }
      public bool enabled(bool value, jElement element) { return false; }      
   }    
}


