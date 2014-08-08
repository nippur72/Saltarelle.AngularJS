using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;
using System.Reflection;
using System.Diagnostics;

namespace AngularJS.Sanitize  
{          
   [Imported, ScriptName("angular"), ScriptNamespace("")]
   public static class ngSanitize
   {      
      public static string ModuleName { [InlineCode("'ngSanitize'")] get { return null; } }
   }   

   public delegate string Sanitize(string html);
   
   [Imported]
   public sealed class linkyFilter
   {
      [InlineCode("{this}({text})")]          public string Filter(string text)                { return null; }
      [InlineCode("{this}({text},{target})")] public string Filter(string text, string target) { return null; }
   }     
}


