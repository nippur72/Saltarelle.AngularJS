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

namespace Test
    {

    public class TestMain
    {
    public static void Main()
    {
        new SubClass();
        new SubClass2().Type = ((EnumType)(0));

    }
    }
    public enum EnumType
        {
        Zero,
        One
        }
    public partial class SubClass : BaseClass
        {
        public SubClass()
            {
            base.Type.ToString();
            base.Type = ((EnumType)(0));
            }
        }
    public class SubClass2 : BaseClass
    {
       EnumType subType;
       public override EnumType Type
            {
            get
                {
                return this.subType;
                }
            set
                {
                this.subType = value;
                }
            }

    }

    public abstract partial class BaseClass
        {
        private EnumType type;
        public BaseClass()
            {
            this.type = ((EnumType)(0));
            }
        public virtual EnumType Type
            {
            get
                {
                return this.type;
                }
            set
                {
                this.type = value;
                }
            }
        }
    }
