using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

namespace TestAngularJS
{                           
   public class FundingExample
   {
      public static void Main()
      {
         Module app = new Module("myApp");
         app.Factory<ItemsFactory>();
         app.Service<ExampleService>();
         app.Controller<StartUpController>();

         Window.Alert("'"+(string) Script.Eval("typeof new Date()")+"'");
         
      }   
   }  
   
   public class ExampleService
   {
      List<CartItem> Items;

      public ExampleService(List<CartItem> Items, Http _http)
      {
         this.Items = Items;   
      }

      public void DoAlert()
      {
         Window.Alert(Items[0].title);
      }
   } 
   
   public class StartUpController : Scope
   {                    	                                                                                               
      public double fundingStartingEstimate;
      public double fundingNeeded;

      public StartUpController(Scope _scope, ExampleService ExampleService)
      {
         fundingStartingEstimate = 0;

         Watch<double>( ()=>{ return fundingStartingEstimate; }, compneeded);

         ExampleService.DoAlert();         
      }

      public void computeNeeded() 
      {
         fundingNeeded = fundingStartingEstimate * 10;
      }

      public void requestFunding() 
      {
         Window.Alert("Sorry, please get more customers first.");
      }

      public void reset()
      {
         fundingStartingEstimate = 0;
      }

      public void compneeded(double newval, double oldval)
      {
         fundingNeeded = fundingStartingEstimate * 10;
      }            
   }   
}
