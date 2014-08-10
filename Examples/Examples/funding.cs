using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;
using System.Diagnostics;

namespace TestAngularJS
{                           
   public class FundingExample
   {
      public static void Main()
      {
         Module app = new Module("myApp");
         app.Controller<StartUpController>();
      }   
   }  
      
   public class StartUpController 
   {                    	                                                                                               
      public double fundingStartingEstimate;
      public double _fundingNeeded;        

      public double fundingNeeded
      {
         get { return _fundingNeeded; }
         set { _fundingNeeded = value; }
      }
      
      public StartUpController(Scope _scope)
      {
         fundingStartingEstimate = 0;        
         _scope.Watch<double>( ()=>{ return fundingStartingEstimate; }, compneeded);          
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

