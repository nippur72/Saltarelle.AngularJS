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
   [Imported]
   public sealed class currencyFilter
   {
      [InlineCode("{this}({number})")]          public string Filter(double number)                { return null; }
      [InlineCode("{this}({number},{symbol})")] public string Filter(double number, string symbol) { return null; }
   }

   [Imported]
   public sealed class dateFilter
   {
      [InlineCode("{this}({date})")]          public string Filter(JsDate date)                { return null; }
      [InlineCode("{this}({date},{format})")] public string Filter(JsDate date, string format) { return null; }
   }
          
   [Imported]
   public sealed class filterFilter
   {
      [InlineCode("{this}({array},{matchstring})")]    public T[] Filter<T>(T[] array, string matchstring)          { return null; }
      [InlineCode("{this}({array},{filterobject})")]   public T[] Filter<T>(T[] array, object filterobject)         { return null; }
      [InlineCode("{this}({array},{filterobject})")]   public T[] Filter<T>(T[] array, JsDictionary filterobject)   { return null; }
      [InlineCode("{this}({array},{filterfunction})")] public T[] Filter<T>(T[] array, Func<bool,T> filterfunction) { return null; }
   }

   [Imported]
   public sealed class jsonFilter
   {
      [InlineCode("{this}({o})")] public string Filter(object o) { return null; }      
   }

   [Imported]
   public sealed class limitToFilter
   {      
      [InlineCode("{this}({array},{limit})")] public T Filter<T>(T[] array, int limit) { return default(T); }
   }

   [Imported]
   public sealed class lowercaseFilter
   {
      [InlineCode("{this}({s})")] public string Filter(string s) { return null; }      
   }

   [Imported]
   public sealed class numberFilter
   {
      [InlineCode("{this}({number})")]                public string Filter(object number)                   { return null; }
      [InlineCode("{this}({number},{fractionSize})")] public string Filter(object number, int fractionSize) { return null; }
   }

   [Imported]
   public sealed class orderByFilter
   {
      [InlineCode("{this}({array},{function})"  )] public T Filter<T>(T[] array, Func<object,T> function) { return default(T); }
      [InlineCode("{this}({array},{expression})")] public T Filter<T>(T[] array, string expression)       { return default(T); }
      [InlineCode("{this}({array},{predicates})")] public T Filter<T>(T[] array, object[] predicates)     { return default(T); }      
      [InlineCode("{this}({array},{function},{reverse})"  )] public T Filter<T>(T[] array, Func<object,T> function, bool reverse) { return default(T); }
      [InlineCode("{this}({array},{expression},{reverse})")] public T Filter<T>(T[] array, string expression, bool reverse)       { return default(T); }
      [InlineCode("{this}({array},{predicates},{reverse})")] public T Filter<T>(T[] array, object[] predicates, bool reverse)     { return default(T); }      
   }

   [Imported]
   public sealed class uppercaseFilter
   {
      [InlineCode("{this}({s})")] public string Filter(string s) { return null; }      
   }  
}

