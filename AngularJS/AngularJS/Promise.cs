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
   public sealed class Promise
   {
      [ScriptName("then")] public Promise Then(object success, object error)  { return this; }
   }     
}

