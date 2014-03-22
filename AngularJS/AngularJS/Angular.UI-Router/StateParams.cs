using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;
using System.Reflection;
using System.Diagnostics;

namespace AngularJS.UiRouter
{          
   [Imported]
   public sealed class StateParams 
   {            
      public string this[string key] { [InlineCode("{this}[{key}]")] get { return null; } }
   }    
}

