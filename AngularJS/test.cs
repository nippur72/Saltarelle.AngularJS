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
         Module app = Angular.Module("myApp");              
         AngularControllers.RegisterControllers(app, new Controllers());         
      }
   }
   
   public class HelloModel : Scope
   {
      public string greetings;      
   }

   public class CartModel : Scope
   {
      public class CartItem
      {
         public string title;
         public double quantity;
         public double price;
      }

      public List<CartItem> items;
      public Action<int> remove;                 
      public Func<object> totalCart;
      public Func<double> subtotal;
      public double billDiscount;
   }

   public class FundingModel : Scope
   {      
      public double fundingStartingEstimate;
      public double fundingNeeded;

      public Action computeNeeded;
      public Action requestFunding;
      public Action reset;      

      public static object check()
      {
         return 3*2;
      }
   }
   
   [Reflectable]
   public class Controllers : AngularControllers
   {     
      [Reflectable]
      public static void HelloController(HelloModel scope)
      {         
         scope.greetings = "Douglas Adams";
      }           	     

      [Reflectable]
      public static void CartController(CartModel scope)
      {
         scope.items = new List<CartModel.CartItem>();
         scope.items.Add( new CartModel.CartItem() { title="Paint pots", quantity= 8, price= 3.95} );
         scope.items.Add( new CartModel.CartItem() { title="Polka dots", quantity=17, price=12.95} );
         scope.items.Add( new CartModel.CartItem() { title="Pebbles",    quantity= 5, price= 6.95} );

         scope.remove = (index) => 
         {
            scope.items.RemoveAt(index);
         };

         scope.totalCart = delegate() 
         {
            double total = 0;
            for(int i=0; i<scope.items.Count; i++) 
            {
               total = total + scope.items[i].price * scope.items[i].quantity;
            }
            return total;
         };

         scope.subtotal = delegate() 
         {
            return (double)scope.totalCart() - scope.billDiscount;
         };

         WatchListener calculateDiscount = delegate(object newValue,object oldValue) 
         {
            scope.billDiscount = (double) newValue > 100 ? 10 : 0;
         };

         scope.Watch(scope.totalCart, calculateDiscount);
      }                                                                                      

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

         WatchListener compneeded = (newval,oldval) => 
         {
            scope.fundingNeeded = scope.fundingStartingEstimate * 10;
         };

         scope.Watch("fundingStartingEstimate", compneeded);

         Func<FundingModel,object> pippo = (sc)=>
         {
            return 33;
         };

         scope.Watch( FundingModel.check, compneeded);
      }

   }   
}
