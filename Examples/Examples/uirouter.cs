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
      public UiRouterConfig(StateProvider _stateProvider, UrlRouterProvider _urlRouterProvider, LocationProvider _locationProvider)
      {                           
         _urlRouterProvider.Otherwise("state1");

         _stateProvider.State( new StateConfig()
         {
            Name = "state1",
            Url = "/state1/{id}",
            //Controller = "State1Controller";
            TemplateUrl = "state1.html"
         });

         _stateProvider.State( new StateConfig()
         {
            Name = "state2",
            Url = "/state2",
            TemplateUrl = "state2.html"
         });

         _stateProvider.State( new StateConfig()
         {
            Name = "state2.inner",
            Url = "/state2inner",
            TemplateUrl = "state2.inner.html"
         });                 
      }      
   }
}
