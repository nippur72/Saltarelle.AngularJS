using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;
using System.Reflection;
using System.Diagnostics;

namespace AngularJS.UiRouter
{          
   [Imported]
   public sealed class UrlRouterProvider
   {
      [InlineCode("{this}.otherwise({rule})")]
      public UrlRouterProvider Otherwise(string rule)
      {
         return this;
      }

      [InlineCode("{this}.when({path},{route})")]
      public UrlRouterProvider When(string path, string route)
      {
         return this;
      }
   }

   /*
   [Imported]
   public sealed class Rule
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
   */
}

