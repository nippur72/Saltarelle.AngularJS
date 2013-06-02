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
   [ScriptNamespace("angular")]
   public static class Angular
   {
      [InlineCode("angular.module({ModuleName},[])")]
      public static Module Module(string ModuleName)
      {
         return null;
      }

      [InlineCode("angular.module({ModuleName},{Requires})")]
      public static Module Module(string ModuleName, object[] Requires)
      {
         return null;
      }

      [InlineCode("angular.injector(['ng']).get({name})")]
      public static dynamic InjectorRead(string name)
      {
         return null;
      }

      [InlineCode("angular.injector([{modulename}]).get({name})")]
      public static dynamic InjectorRead(string modulename, string name)
      {
         return null;
      }
   }   
       
}

