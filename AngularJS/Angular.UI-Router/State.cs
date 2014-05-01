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
   public sealed class State
   {      
      [InlineCode("{this}.go({name})")]                        public Promise Go(string name) { return null; }
      [InlineCode("{this}.go({name},{parameters})")]           public Promise Go(string name, object parameters) { return null; }
      [InlineCode("{this}.go({name},{parameters},{options})")] public Promise Go(string name, object parameters, object options) { return null; }      

      [InlineCode("{this}.transitionTo({name})")]                      public Promise TransitionTo(string name) { return null; }
      [InlineCode("{this}.transitionTo({name},{toParams})")]           public Promise TransitionTo(string name, object toParams) { return null; }
      [InlineCode("{this}.transitionTo({name},{toParams},{options})")] public Promise TransitionTo(string name, object toParams, object options) { return null; }      

      public StateConfig Current { [InlineCode("{this}.current")] get { return null; } }
      public dynamic     Params  { [InlineCode("{this}.params")]  get { return null; } }
   }
}

