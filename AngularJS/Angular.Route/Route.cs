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
   public sealed class Route
   {
   }

   [Imported]
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
   
   public class RouteParams
   {
   }  
}

