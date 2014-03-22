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
}

