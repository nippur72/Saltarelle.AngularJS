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
         app.RegisterController(typeof(StartUpController));
      }   
   }   
   
   public class StartUpController : Scope
   {                    	                                                                                               
      public double fundingStartingEstimate;
      public double fundingNeeded;

      public StartUpController(Scope _scope)
      {
         fundingStartingEstimate = 0;

         Watch<double>( ()=>{ return fundingStartingEstimate; }, compneeded);
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
