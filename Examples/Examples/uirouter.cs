using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;
using AngularJS.UiRouter;

using System.Diagnostics;

namespace TestAngularJS
{                        
   public class UiRouterExample
   {
      public static void Main()
      {
         Module app = new Module("UiRouterExample", UiRouter.ModuleName);
                  
         app.Config<UiRouterConfig>();
         app.Controller<MyController>();
         app.Controller<State1Controller>();
      }   
   }

   public class MyController
   {
      State state;      

      public MyController(Scope _scope, State _state)
      {
         state = _state;
      }

      public void VaiStato2()
      {
         //Window.Alert("KK");
         state.Go("state2.inner");
      }
   }

   public class State1Controller
   {
      public string MyValue;
      public string id;

      public State1Controller(Scope _scope, StateParams _stateParams)
      {         
         MyValue = "hjhh";   
         id = _stateParams["id"];
      }
   }

   public class UiRouterConfig
   {
      public UiRouterConfig(StateProvider _stateProvider)
      {                  
         var state1 = new StateConfig();
         state1.Name = "state1";
         state1.Url = "/state1/{id}";
         //state1.Controller = "State1Controller";
         state1.TemplateUrl = "state1.html";

         var state2 = new StateConfig();
         state2.Name = "state2";
         state2.Url = "/state2";
         state2.TemplateUrl = "state2.html";

         var state2inner = new StateConfig();
         state2inner.Name = "state2.inner";
         state2inner.Url = "/state2inner";
         state2inner.TemplateUrl = "state2.inner.html";

         _stateProvider.State(state1)
                       .State(state2)
                       .State(state2inner);
      }      
   }
}
