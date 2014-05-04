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
   public sealed class HttpPromise
   {
      [ScriptName("then")]
      public HttpPromise Then(object success, object error)
      {
         return this;
      }

      [ScriptName("success")] public HttpPromise Success(Action                           SuccessFunction) { return this; }
      [ScriptName("success")] public HttpPromise Success(Action<object>                   SuccessFunction) { return this; }
      [ScriptName("success")] public HttpPromise Success<T>(Action<T>                     SuccessFunction) { return this; }
      [ScriptName("success")] public HttpPromise Success(Action<object,int>               SuccessFunction) { return this; }
      [ScriptName("success")] public HttpPromise Success(Action<object,int,object>        SuccessFunction) { return this; }
      [ScriptName("success")] public HttpPromise Success(Action<object,int,object,object> SuccessFunction) { return this; }
          
      [ScriptName("error")] public HttpPromise Error(Action                           ErrorFunction) { return this; }
      [ScriptName("error")] public HttpPromise Error(Action<object>                   ErrorFunction) { return this; }
      [ScriptName("error")] public HttpPromise Error<T>(Action<T>                     ErrorFunction) { return this; }
      [ScriptName("error")] public HttpPromise Error(Action<object,int>               ErrorFunction) { return this; }
      [ScriptName("error")] public HttpPromise Error(Action<object,int,object>        ErrorFunction) { return this; }
      [ScriptName("error")] public HttpPromise Error(Action<object,int,object,object> ErrorFunction) { return this; }

      [ScriptName("finally")] public HttpPromise Finally(Action FinallyCallback) { return null; }
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

