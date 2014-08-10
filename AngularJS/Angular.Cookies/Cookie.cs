using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;
using System.Reflection;
using System.Diagnostics;

namespace AngularJS.Cookies 
{          
   [Imported]
   public class Cookie
   {
      /// </summary>
      /// Adding or removing properties to/from this object, new cookies are created/deleted at the end of current $eval
      /// <summary>
      public string this[string prop] 
      { 
         [InlineCode("{this}[{prop}]")] 
         get { return null; }
         [InlineCode("{this}[{prop}] = {value}")] 
         set { }
      }    
   }
}




