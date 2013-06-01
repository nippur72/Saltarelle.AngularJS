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
   public sealed class Location
   {
      public string Path
      {
         [InlineCode("{this}.path()")]        get { return ""; }         
         [InlineCode("{this}.path({value})")] set { }
      }
   }
}

