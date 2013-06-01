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
   [ScriptNamespace("angular")]
   [ScriptName("$injector")]
   public sealed class Injector
   {
      //[ScriptName("annotate")] public static List<string> Annotate(object fn) { return null; }      
      [InlineCode("angular.injector().annotate({fn})")] 
      public static List<string> Annotate(object fn) { return null; }      
   }
}

