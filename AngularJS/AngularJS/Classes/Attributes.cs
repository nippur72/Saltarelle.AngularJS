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
   /// <summary>
   /// $compile.directive.Attributes 
   /// A shared object between directive compile / linking functions which contains normalized DOM element attributes.    
   /// </summary>
   [Imported]
   public sealed class Attributes
   {
      [IntrinsicProperty]
      public string this[string key] { get {return "";}  set {}  }
            
      public JsDictionary attr 
      {
         [InlineCode("{this}.$attr")] get { return null; }
      }

      /// <summary>
      /// Adds the CSS class value specified by the classVal parameter to the element. If animations are enabled then an animation will be triggered for the class addition.
      /// </summary>
      [ScriptName("$addClass")] public void addClass(string classVal) { }

      /// <summary>
      /// Removes the CSS class value specified by the classVal parameter from the element. If animations are enabled then an animation will be triggered for the class removal.
      /// </summary>
      [ScriptName("$removeClass")] public void removeClass(string classVal) { }
      
      /// <summary>
      /// Adds and removes the appropriate CSS class values to the element based on the difference between the new and old CSS class values (specified as newClasses and oldClasses).
      /// </summary>
      [ScriptName("$updateClass")] public void updateClass(string newClasses, string oldClasses) { }

      /// <summary>
      /// Observe an interpolated attribute. The observer will never be called, if given attribute is not interpolated.
      /// </summary>
      [ScriptName("$observe")] public Action observe(string key, Action<string> function) { return null; }

      /// <summary>
      /// Set DOM element attribute value.
      /// </summary>
      [InlineCode("{this}.$set({key},{value})")]
      public void set(string key, string value) {}      
      
      /// <summary>
      /// Set DOM element attribute value.
      /// </summary>
      [InlineCode("{this}.$set({key},{value})")]
      public void set(string key, bool value) {}      

      [ScriptName("$normalize")] public string normalize(string name) { return ""; }

      /*
      // these seems to be obsolete
      public object Element  // TODO: fix to jElement or Angular.Element
      {
         [InlineCode("{this}.$$element")] get { return null; }
      }

      [InlineCode("{this}.$set({key},null)")]
      public void Delete(string key) {}      
      */
   }                                  
}

