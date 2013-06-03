using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

namespace TestAngularJS
{                        
   public class PhoneExample
   {
      public static void Main()
      {
         Module app = new Module("myApp");
         app.Config<PhoneConfig>();
         app.Controller<PhoneListController>();
         app.Controller<PhoneListControllerDetail>();
      }   
   }

   public class PhoneRouteParams : RouteParams
   {
      public int phoneId;
   }
   
   public class PhoneListController
   {                  
      public string what;
      public JsDictionary person;

      public PhoneListController(Scope _scope, Http _http)
      {
         what = "main";         

         /*
         http.Get("hello.html").Success((data,status)=> {
            Window.Alert(data.ToString());
         }).Error((data,status)=>{ 
            Window.Alert("errore!");
         });
         */

         var risp = _http.Get("data.json");

         risp.Success((data,status,header)=> 
         {            
            person = (JsDictionary) data;
            Window.Alert(person["name"].ToString());
         });

         risp.Error((data,status)=>
         { 
            Window.Alert("errore!");
         });                
      }
   }
   
   public class PhoneListControllerDetail
   {  
      public string what;
      public int phoneId;

      public PhoneListControllerDetail(Scope _scope, PhoneRouteParams _routeParams)
      {
         what = "detail";
         phoneId = _routeParams.phoneId;
      }
   }                 
   
   public class PhoneConfig
   {                  
      public PhoneConfig(RouteProvider _routeProvider)
      {
         _routeProvider.when("/phones"          , new RouteMap() { TemplateUrl = "phonemain.html"   })
                       .when("/phones/:phoneId" , new RouteMap() { TemplateUrl = "phonedetail.html" })
                       .otherwise(                new RouteMap() { RedirectTo  = "/phones"          });
      }
   }                 
}
