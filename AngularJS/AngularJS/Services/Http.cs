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
   public delegate void HttpDelegate2(object data, object status);
   public delegate void HttpDelegate3(object data, object status, object header);
   public delegate void HttpDelegate4(object data, object status, object header, object config);

   [Imported]
   public sealed class HttpPromise
   {
      [ScriptName("then")]
      public HttpPromise Then(object success, object error)
      {
         return this;
      }

      [ScriptName("success")] public HttpPromise Success(HttpDelegate2 function) { return this; }
      [ScriptName("success")] public HttpPromise Success(HttpDelegate3 function) { return this; }
      [ScriptName("success")] public HttpPromise Success(HttpDelegate4 function) { return this; }

      [ScriptName("error")] public HttpPromise Error(HttpDelegate2 function) { return this; }
      [ScriptName("error")] public HttpPromise Error(HttpDelegate3 function) { return this; }
      [ScriptName("error")] public HttpPromise Error(HttpDelegate4 function) { return this; }
   }

   [Imported]
   public sealed class Http
   {
      [InlineCode("{this}.get({Url})         ")] public HttpPromise Get(string Url               ) { return null; }
      [InlineCode("{this}.get({Url},{Config})")] public HttpPromise Get(string Url, object Config) { return null; }
      
      [InlineCode("{this}.head({Url})"         )] public HttpPromise Head(string Url)                { return null; }
      [InlineCode("{this}.head({Url},{Config})")] public HttpPromise Head(string Url, object Config) { return null; }
      
      [InlineCode("{this}.post({Url},{Data})"         )] public HttpPromise Post(string Url, object Data)                { return null; }
      [InlineCode("{this}.post({Url},{Data},{Config})")] public HttpPromise Post(string Url, object Data, object Config) { return null; }

      [InlineCode("{this}.put({Url},{Data})"         )] public HttpPromise Put(string Url, object Data)                { return null; }
      [InlineCode("{this}.put({Url},{Data},{Config})")] public HttpPromise Put(string Url, object Data, object Config) { return null; }

      [InlineCode("{this}['delete']({Url})         ")] public HttpPromise Delete(string Url               ) { return null; }
      [InlineCode("{this}['delete']({Url},{Config})")] public HttpPromise Delete(string Url, object Config) { return null; }      

      [InlineCode("{this}.jsonp({Url})         ")] public HttpPromise Jsonp(string Url               ) { return null; }
      [InlineCode("{this}.jsonp({Url},{Config})")] public HttpPromise Jsonp(string Url, object Config) { return null; }

      public dynamic defaults;
      public dynamic pendingRequests;
   }

   [Imported]
   public class HttpResponseHeaders
   {
      //[IntrinsicProperty]
      public string this[string key] 
      { 
         [InlineCode("{this}({key})")]
         get {return null;}           
      } 

      public JsDictionary<string, string> Items
      {
         [InlineCode("{this}()")]
         get {return null;}           
      }
   }

   [Imported]
   public class HttpResponse
   {
      [ScriptName("data")]     public object Data;
      [ScriptName("status")]   public int Status;
      [ScriptName("headers")]  public HttpResponseHeaders Headers;

      [InlineCode("{this}.data")]
      public T DataAs<T>()
      {
         return default(T);
      }
   }

}

