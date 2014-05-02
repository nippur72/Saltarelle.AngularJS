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
   public sealed class Injector
   {
      [ScriptName("annotate")]    public List<string> Annotate(object fn) { return null; }  
      
      [ScriptName("get")]                             public T Get<T>(string ServiceName) { return default(T); }
      [InlineCode("{this}.get(ss.getTypeName({T}))")] public T Get<T>() { return default(T); }

      [ScriptName("has")]         public bool Has(string ServiceName) { return false; }
      [ScriptName("instantiate")] public object Instantiate(object Type, object locals) { return null; }
      [ScriptName("invoke")]      public object Invoke(object fn, object self, object locals) { return null; }          
   }
}

