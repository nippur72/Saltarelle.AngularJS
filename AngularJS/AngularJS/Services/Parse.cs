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
   /// Converts Angular expression into a function.
   /// Returns a function(context,locals) which represents the compiled expression:
   /// </summary>
   public delegate ParsedFunction Parse(string expression);   

   // $parse() returns a structured object with a callable function. 
   // In C# we wrap it around the ParseFunction object

   [Imported] public sealed class ParsedFunction
   {
      [InlineCode("{this}()")]
      public object Call() { return null; }

      [InlineCode("{this}({context})")]
      public object Call(object context) { return null; }
      
      [InlineCode("{this}({context},{locals})")]
      public object Call(object context, object locals) { return null; }

      /// <summary>
      /// whether the expression's top-level node is a JavaScript literal.
      /// </summary>
      public bool literal; 

      /// <summary>
      /// whether the expression is made entirely of JavaScript constant literals.
      /// </summary>
      public bool constant; 

      /// <summary>
      /// {?function(context, value)} – if the expression is assignable, this will be set to a function to change its value on the given context.         
      /// </summary>
      public Action<object,object> assign;      
   }
}

