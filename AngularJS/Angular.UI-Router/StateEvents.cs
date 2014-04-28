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
   public static class StateEventsExtensions
   {
      public static void OnStateChangeStart(this RootScope _rootscope, Action<Event,StateConfig,object,StateConfig,Object> Function)
      {
         _rootscope.On("$stateChangeStart",Function);
      }

      // view load events

      public static void OnViewContentLoading(this Scope _scope, Action<Event,StateConfig> Function)
      {
         _scope.On("$viewContentLoading",Function);
      }

      public static void OnViewContentLoaded(this Scope _scope, Action<Event> Function)
      {
         _scope.On("$viewContentLoaded",Function);
      }
   }
}

