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
   public sealed class StateProvider
   {      
      [InlineCode("{this}.state({conf})")]        public StateProvider State(State conf) { return this; }
      [InlineCode("{this}.state({name},{conf})")] public StateProvider State(string name, State conf) { return this; }      
   }  
}

