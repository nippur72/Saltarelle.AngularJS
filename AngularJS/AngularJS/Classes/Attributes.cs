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
   public sealed class Attributes
   {
      [IntrinsicProperty]
      public string this[string key] { get {return "";}  set {}  }
            
      public JsDictionary Attr 
      {
         [InlineCode("{this}.$attr")] get { return null; }
      }
      
      public object Element  // TODO: fix to jElement or Angular.Element
      {
         [InlineCode("{this}.$$element")] get { return null; }
      }

      [InlineCode("{this}.$normalize({name})")]
      public string Normalize(string name) { return ""; }

      [InlineCode("{this}.$set({key},{value})")]
      public void Set(string key, string value) {}      
      
      [InlineCode("{this}.$set({key},{value})")]
      public void Set(string key, bool value) {}      

      [InlineCode("{this}.$set({key},null)")]
      public void Delete(string key) {}      

      /// <summary>
      /// Observe an interpolated attribute. The observer will never be called, if given attribute is not interpolated.
      /// </summary>
      [InlineCode("{this}.$observe({key},{function})")]
      public void Observe(string key, Action function) {}
   }                                  
}

