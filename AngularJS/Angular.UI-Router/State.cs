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
   public sealed class StateService
   {      
      [InlineCode("{this}.go({name})")]                        public Promise Go(string name) { return null; }
      [InlineCode("{this}.go({name},{parameters})")]           public Promise Go(string name, object parameters) { return null; }
      [InlineCode("{this}.go({name},{parameters},{options})")] public Promise Go(string name, object parameters, object options) { return null; }      

      public State Current { [InlineCode("{this}.current")] get { return null; } }
   }
}

