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
   public class Resource
   {
      [InlineCode("{this}({url},{paramDefaults},{actions})")] public ResourceObject Create(string url, object paramDefaults, ResourceActions actions) { return null; }
      [InlineCode("{this}({url},{paramDefaults},{actions})")] public ResourceObject Create(string url, object paramDefaults, object          actions) { return null; }
   }

   [Imported]
   public class ResourceActions
   {
      [InlineCode("{}")]
      public ResourceActions()
      {
      }

      [InlineCode("{this}[{ActionName}]={{ method:{Method}, isArray:{ReturnsArray} }}")]
      public void Add(string ActionName, string Method, bool ReturnsArray)
      {
         
      }
   }

   public interface IResourceObject
   {
      
   }

   public static class ResourceObjectExtensions
   {
      [InlineCode("{self}.${@action}()")]                       public static IResourceObject Action(this IResourceObject self, string action) { return default(IResourceObject); }
      [InlineCode("{self}.${@action}({ob})")]                   public static IResourceObject Action(this IResourceObject self, string action, object ob) { return default(IResourceObject); }
      [InlineCode("{self}.${@action}({ob},{success})")]         public static IResourceObject Action(this IResourceObject self, string action, object ob, Action success) { return default(IResourceObject); }
      [InlineCode("{self}.${@action}({ob},{success})")]         public static IResourceObject Action(this IResourceObject self, string action, object ob, Action<IResourceObject,HttpResponseHeaders> success) { return default(IResourceObject); }
      [InlineCode("{self}.${@action}({ob},{success},{error})")] public static IResourceObject Action(this IResourceObject self, string action, object ob, Action<IResourceObject,HttpResponseHeaders> success, Action<HttpResponse> error) { return default(IResourceObject); }
      [InlineCode("{self}.${@action}({ob},{success},{error})")] public static IResourceObject Action(this IResourceObject self, string action, object ob, Action success, Action<HttpResponse> error) { return default(IResourceObject); }
      [InlineCode("{self}.${@action}({ob},{success},{error})")] public static IResourceObject Action(this IResourceObject self, string action, object ob, Action success, Action error) { return default(IResourceObject); }
   }

   [Imported]   
   public class ResourceObject
   {
      [InlineCode("{res}({url},{paramDefaults},{actions})")]
      public ResourceObject(Resource res, string url, object paramDefaults, object actions)
      {                  
      }

      [InlineCode("{this}.{@action}({ob})")]                   public T Action<T>(string action, object ob) { return default(T); }
      [InlineCode("{this}.{@action}({ob},{success})")]         public T Action<T>(string action, object ob, Action success) { return default(T); }
      [InlineCode("{this}.{@action}({ob},{success})")]         public T Action<T>(string action, object ob, Action<T,HttpResponseHeaders> success) { return default(T); }
      [InlineCode("{this}.{@action}({ob},{success},{error})")] public T Action<T>(string action, object ob, Action<T,HttpResponseHeaders> success, Action<HttpResponse> error) { return default(T); }
      [InlineCode("{this}.{@action}({ob},{success},{error})")] public T Action<T>(string action, object ob, Action success, Action<HttpResponse> error) { return default(T); }
      [InlineCode("{this}.{@action}({ob},{success},{error})")] public T Action<T>(string action, object ob, Action success, Action error) { return default(T); }

      [InlineCode("{this}.get({ob})")]                   public T Get<T>(object ob) { return default(T);}
      [InlineCode("{this}.get({ob},{success})")]         public T Get<T>(object ob, Action success) { return default(T); }
      [InlineCode("{this}.get({ob},{success})")]         public T Get<T>(object ob, Action<T,HttpResponseHeaders> success) { return default(T); }
      [InlineCode("{this}.get({ob},{success},{error})")] public T Get<T>(object ob, Action<T,HttpResponseHeaders> success, Action<HttpResponse> error) { return default(T); }
      [InlineCode("{this}.get({ob},{success},{error})")] public T Get<T>(object ob, Action success, Action<HttpResponse> error) { return default(T); }
      [InlineCode("{this}.get({ob},{success},{error})")] public T Get<T>(object ob, Action success, Action error) { return default(T); }

      [InlineCode("{this}.save({ob})")]
      public object Save(object ob)
      {
         return null;
      }

      [InlineCode("{this}.save({parameters},{ob})")]
      public object Save(object parameters, object ob)
      {
         return null;
      }

      [InlineCode("{this}.query()")]
      public object[] Query()
      {
         return null;
      }

      [InlineCode("{this}.remove({ob})")]
      public object Remove(object ob)
      {
         return null;
      }

      [InlineCode("{this}['delete']({ob})")]
      public object Delete(object ob)
      {
         return null;
      }
   }         

}

