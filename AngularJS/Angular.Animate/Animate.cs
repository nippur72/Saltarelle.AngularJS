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
   [Imported, ScriptName("angular"), ScriptNamespace("")]
   public static class ngAnimate
   {      
      public static string ModuleName { [InlineCode("'ngAnimate'")] get { return null; } }
   }   

   [Imported]   
   public sealed class Animate
   {      
      public Action enter(Element element, Element parentElement, Element afterElement) { return null; }
      public Action enter(Element element, Element parentElement, Element afterElement, Action doneCallback) { return null; }

      public Action leave(Element element) { return null; }
      public Action leave(Element element, Action doneCallback) { return null; }

      public Action move(Element element, Element parentElement, Element afterElement) { return null; }
      public Action move(Element element, Element parentElement, Element afterElement, Action doneCallback) { return null; }

      public Action addClass(Element element, string className) { return null; }
      public Action addClass(Element element, string className, Action doneCallback) { return null; }

      public Action removeClass(Element element, string className) { return null; }
      public Action removeClass(Element element, string className, Action doneCallback) { return null; }

      public Action setClass(Element element, string add, string remove) { return null; }
      public Action setClass(Element element, string add, string remove, Action doneCallback) { return null; }
      
      public bool enabled() { return false; }
      public bool enabled(bool value) { return false; }
      public bool enabled(bool value, Element element) { return false; }      
   } 
   
   public interface IAnimation
   {
      object GetDefinition();
   }    
}


