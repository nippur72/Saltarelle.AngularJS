using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

namespace TestAngularJS
{                      
   public class FundingModel : Scope
   {      
      public double fundingStartingEstimate;
      public double fundingNeeded;

      public Action computeNeeded;
      public Action requestFunding;
      public Action reset;                
   }
   
   [Reflectable]
   public class FundingControllers 
   {                    	                                                                                            
      [Reflectable]
      public static void StartUpController(FundingModel scope)
      {
         scope.fundingStartingEstimate = 0;

         scope.computeNeeded = delegate() 
         {
            scope.fundingNeeded = scope.fundingStartingEstimate * 10;
         };

         scope.requestFunding = delegate() 
         {
            Window.Alert("Sorry, please get more customers first.");
         };

         scope.reset = delegate()
         {
            scope.fundingStartingEstimate = 0;
         };

         WatchListener<double> compneeded = (newval,oldval) => 
         {
            scope.fundingNeeded = scope.fundingStartingEstimate * 10;
         };            

         scope.Watch<double>( ()=>{ return scope.fundingStartingEstimate; }, compneeded);
      }

   }   
}
