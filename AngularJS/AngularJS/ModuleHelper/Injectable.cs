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
   ///<summary>
   ///  Exposes the $inject property field to injectable JavaScript functions
   ///</summary>
   [Imported]
   public sealed class Injectable
   {
      [InlineCode("{ob}")]
      public static Injectable From(Function ob) 
      {
         return null;
      }
      
      [ScriptName("$inject"), IntrinsicProperty]  
      public string[] Inject
      {
          get; set;
      }
   }   
}

