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
   [Imported, ScriptName("angular"), ScriptNamespace("")]
   public static class UiRouter
   {      
      public static string ModuleName { [InlineCode("'ui.router'")] get { return null;} }
   }

   [Imported]
   public sealed class StateParams 
   {            
      public string this[string key] { [InlineCode("{this}[{key}]")] get { return null; } }
   }

   [Imported]
   public sealed class State
   {      
      [InlineCode("{this}.go({name})")]                        public Promise Go(string name) { return null; }
      [InlineCode("{this}.go({name},{parameters})")]           public Promise Go(string name, object parameters) { return null; }
      [InlineCode("{this}.go({name},{parameters},{options})")] public Promise Go(string name, object parameters, object options) { return null; }      

      public StateConfig Current { [InlineCode("{this}.current")] get { return null; } }
   }

   [Imported]
   public sealed class StateProvider
   {      
      [InlineCode("{this}.state({conf})")]        public StateProvider State(StateConfig conf) { return this; }
      [InlineCode("{this}.state({name},{conf})")] public StateProvider State(string name, StateConfig conf) { return this; }      
   }

   [Imported]
   public sealed class StateConfig
   {
      [ScriptName("name")]                public string Name;
      [ScriptName("template")]            public string Template;
      [ScriptName("template")]            public Func<object[],string> TemplateFunction;
      [ScriptName("templateUrl")]         public string TemplateUrl;
      [ScriptName("templateUrl")]         public Func<object[],string> TemplateUrlFunction;
      [ScriptName("templateProvider")]    public Func<object[],string> TemplateProvider;
      [ScriptName("controller")]          public string Controller;
      [ScriptName("controller")]          public object ControllerFunction;
      [ScriptName("controllerProvider")]  public object ControllerProvider;
      [ScriptName("controllerAs")]        public string ControllerAs;
      [ScriptName("resolve")]             public JsDictionary<string,object> Resolve;
      [ScriptName("url")]                 public string Url;
      [ScriptName("params")]              public string[] Params;
      [ScriptName("views")]               public JsDictionary<string,StateConfig> Views;
      [ScriptName("abstract")]            public bool Abstract;
      [ScriptName("onEnter")]             public Action OnEnter;
      [ScriptName("onExit")]              public Action OnExit;
      [ScriptName("reloadOnSearch")]      public bool ReloadOnSearch;
      [ScriptName("data")]                public object Data;

      [InlineCode("{}")]
      public StateConfig()
      {
      }
   }

   [Imported]
   public sealed class UrlRouterProvider
   {
      [InlineCode("{this}.otherwise({rule})")]
      public UrlRouterProvider Otherwise(string rule)
      {
         return this;
      }

      /*[InlineCode("{this}.when({path},{route})")]
      public RouteProvider when(string path, RouteMap route)
      {
         return this;
      }*/
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

