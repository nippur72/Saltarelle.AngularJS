using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

namespace TestAngularJS
{                      
   public class TestApplication
   {
      public static void Main()
      {         
         Module app = new Module("myApp"); 

         app.Register();        
         app.RegisterConfig(new PhoneConfig());
         app.RegisterControllers(new PhoneController());                                  

         /*
         app.RegisterFactory(new CartFactory());
         app.RegisterFilters(new CartFilters());                           
         app.RegisterControllers(new CartControllers());         
         */
                               
         //AngularControllers.RegisterControllers(app, new FundingControllers());                  
         //AngularControllers.RegisterControllers(app, new HelloControllers());         
      }
   }                                                                                                 
}
