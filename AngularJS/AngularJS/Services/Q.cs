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
   public sealed class QService
   {
      //[ScriptName("all")]    public IPromise<any[]> All(promises: IPromise<any>[]);
      //[ScriptName("all")]    public IPromise<{[id: string]: any}> All(promises: {[id: string]: IPromise<any>;});
      [ScriptName("defer")]  public Deferred Defer() { return null; }
      [ScriptName("reject")] public Promise Reject(){ return null; }
      [ScriptName("reject")] public Promise Reject(object reason){ return null; }
      [ScriptName("when")]   public Promise When(Promise value){ return null; }
      [ScriptName("when")]   public Promise When(object value){ return null; }
   }      
}

