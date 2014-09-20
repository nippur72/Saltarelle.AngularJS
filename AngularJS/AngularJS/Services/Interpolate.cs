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
   public delegate string InterpolationFunction(object context);   

   [Imported] public sealed class Interpolate
   {
      /// <summary>
      /// Compiles a string with markup into an interpolation function.
      /// </summary>
      [InlineCode("{this}({text})")]
      public extern InterpolationFunction Call(string text); 

      /// <summary>
      /// Compiles a string with markup into an interpolation function.
      /// </summary>
      [InlineCode("{this}({text},{mustHaveExpression})")]
      public InterpolationFunction Call(string text, bool mustHaveExpression) { return null; }

      /// <summary>
      /// Compiles a string with markup into an interpolation function.
      /// </summary>
      [InlineCode("{this}({text},{mustHaveExpression},{trustedContext})")]
      public InterpolationFunction Call(string text, bool mustHaveExpression, string trustedContext) { return null; }

      /// <summary>
      /// Compiles a string with markup into an interpolation function.
      /// </summary>
      [InlineCode("{this}({text},{mustHaveExpression},{trustedContext},{allOrNothing})")]
      public InterpolationFunction Call(string text, bool mustHaveExpression, string trustedContext, bool allOrNothing) { return null; }

      /// <summary>
      /// Symbol to denote the start of expression in the interpolated string. Defaults to {{.
      /// </summary>
      public string startSymbol() { return null; }

      /// <summary>
      /// Symbol to denote the end of expression in the interpolated string. Defaults to }}.
      /// </summary>
      public string endSymbol() { return null; }
   }
}

