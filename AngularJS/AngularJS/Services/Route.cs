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
   public class Route
   {
   }

   public sealed class RouteMap
   {
      [ScriptName("controller")]     public string Controller;
      [ScriptName("template")]       public string Template;
      [ScriptName("templateUrl")]    public string TemplateUrl;
      [ScriptName("resolve")]        public JsDictionary<string,object> Resolve;
      [ScriptName("redirectTo")]     public dynamic RedirectTo;
      [ScriptName("reloadOnSearch")] public bool ReloadOnSearch;

      [InlineCode("{}")]
      public RouteMap()
      {
      }
   }

   public class RouteProvider
   {
      [InlineCode("{this}.otherwise({route})")]
      public RouteProvider otherwise(RouteMap route)
      {
         return this;
      }

      [InlineCode("{this}.when({path},{route})")]
      public RouteProvider when(string path, RouteMap route)
      {
         return this;
      }
   }

   public class RouteParams
   {
   }

   public static class RouteProviderExtension
   {
   }
}

