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
   [Imported, ScriptName("angular"), ScriptNamespace("")]
   public static class Angular
   {
      public static string ModuleName { [InlineCode("'ng'")] get { return null;} }

      #region Builtin filters
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
      #endregion

      #region Global api

      /// <summary>
      /// Retrieves an already existing module by its name
      /// </summary>      
      [ScriptName("module")] public static Module Module(string Name) { return null; }   
      
      [ScriptName("bind")] public static Function Bind(object self, Function fn, object args) { return null; } 
      [ScriptName("bootstrap")] public static Injector Bootstrap(Element element) { return null; } 
      [ScriptName("bootstrap")] public static Injector Bootstrap(Element element, string[] modules) { return null; } 
      [ScriptName("copy")] public static object Copy(object source, object destination) { return null; } 
      [ScriptName("copy")] public static object Copy(object source) { return null; } 
      [ScriptName("element")] public static AngularJS.Element Element(string ob) { return null; } 
      [ScriptName("element")] public static AngularJS.Element Element(object ob) { return null; } 
      [ScriptName("equals")] public static bool AreEquals(object ob1, object ob2) { return false; } 
      [ScriptName("extend")] public static object Extend(object dest, object src) { return null; } 
      [ScriptName("forEach")] public static JsDictionary ForEach<T>(JsDictionary ob, Action<object,string> iterator) { return null; } 
      [ScriptName("forEach")] public static JsDictionary ForEach<T>(JsDictionary ob, Action<object,string> iterator, object Context) { return null; }       
      [ScriptName("forEach")] public static T[] ForEach<T>(T[] ob, Action<T,int> iterator) { return null; } 
      [ScriptName("forEach")] public static T[] ForEach<T>(T[] ob, Action<T,int> iterator, object Context) { return null; } 
      [ScriptName("fromJson")] public static T FromJson<T>(string value) { return default(T); } 
      [ScriptName("identity")] public static object Identity(object value) { return null; } 
      [ScriptName("injector")] public static Injector Injector() { return null; } 
      //[ScriptName("injector")] public static Injector Injector(string[] ob) { return null; } 
      [ScriptName("injector")] public static Injector Injector(params string[] ob) { return null; } 
      [ScriptName("isArray")] public static bool IsArray(object ob) { return false; }
      [ScriptName("isDate")] public static bool IsDate(object ob) { return false; }
      [ScriptName("isDefined")] public static bool IsDefined(object ob) { return false; }
      [ScriptName("isElement")] public static bool IsElement(object ob) { return false; }
      [ScriptName("isFunction")] public static bool IsFunction(object ob) { return false; }
      [ScriptName("isNumber")] public static bool IsNumber(object ob) { return false; }
      [ScriptName("isObject")] public static bool IsObject(object ob) { return false; }
      [ScriptName("isString")] public static bool IsString(object ob) { return false; }
      [ScriptName("isUndefined")] public static bool IsUndefined(object ob) { return false; }
      [ScriptName("lowercase")] public static string LowerCase(string s) { return null; }
      [ScriptName("noConflict")] public static void NoConflict() { }
      [ScriptName("noop")] public static Action NoOp() { return null; }
      [ScriptName("toJson")] public static string ToJson(string s) { return null; }
      [ScriptName("toJson")] public static string ToJson(string s, bool pretty) { return null; }
      [ScriptName("uppercase")] public static string UpperCase(string s) { return null; }
      [ScriptName("version"), IntrinsicProperty] public static JsDictionary Version { get { return null; } }

      #endregion
   }  
}

