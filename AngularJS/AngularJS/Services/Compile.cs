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
   public sealed class Compile
   {
      /// <summary>
      /// Compiles an HTML element and returns a linking function
      /// </summary>
      [InlineCode("{this}({element})")]
      public Action<Scope> Call(AngularJS.Element element) { return null; }
   }  
}

