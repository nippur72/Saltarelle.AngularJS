using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;
using System.Reflection;
using System.Diagnostics;

#pragma warning disable 1591   // disables missing XML documentation warning

namespace AngularJS
{             
   [Imported, ScriptNamespace("angular")]
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
   
      public static class BuiltinFilters
      {
         public static currencyFilter  currencyFilter  { [InlineCode("angular.injector(['ng']).get('$filter')('currency')" )] get {return null; } }
         public static dateFilter      dateFilter      { [InlineCode("angular.injector(['ng']).get('$filter')('date')"     )] get {return null; } }
         public static filterFilter    filterFilter    { [InlineCode("angular.injector(['ng']).get('$filter')('filter')"   )] get {return null; } }
         public static jsonFilter      jsonFilter      { [InlineCode("angular.injector(['ng']).get('$filter')('json')"     )] get {return null; } }
         public static limitToFilter   limitToFilter   { [InlineCode("angular.injector(['ng']).get('$filter')('limitTo')"  )] get {return null; } }
         public static lowercaseFilter lowercaseFilter { [InlineCode("angular.injector(['ng']).get('$filter')('lowercase')")] get {return null; } }
         public static numberFilter    numberFilter    { [InlineCode("angular.injector(['ng']).get('$filter')('number')"   )] get {return null; } }
         public static orderByFilter   orderByFilter   { [InlineCode("angular.injector(['ng']).get('$filter')('orderBy')"  )] get {return null; } }
         public static uppercaseFilter uppercaseFilter { [InlineCode("angular.injector(['ng']).get('$filter')('uppercase')")] get {return null; } }
      }
   }   
       
}

