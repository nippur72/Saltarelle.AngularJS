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
   public class ShoppingCartExample
   {
      public static void Main()
      {
         Module app = new Module("myApp");
         app.Factory<ItemsFactory>(); 
         app.Factory<LabelsFactory>(); 
         app.Filter<Filters>();        
         app.Controller<CartController>();
      }   
   }
   
   public class CartItem
   {
      public string title;
      public double quantity;
      public double price;
   } 
   
   public class CartController 
   {
      public List<CartItem> items;
      public double billDiscount;

      public CartController(Scope _scope, List<CartItem> Items)
      {
         zeroitems();
         items = Items;
         _scope.Watch<double>(totalCart, calculateDiscount);
      }

      public void zeroitems()
      {
         items = null;
      }

      public void remove(int index)
      {
         items.RemoveAt(index);
      }      

      public double totalCart()
      {
         double total = 0;
         for(int i=0; i<items.Count; i++) 
         {
            total = total + items[i].price * items[i].quantity;
         }
         return total;
      }

      public double subtotal()
      {
         return totalCart() - billDiscount;
      }

      public void calculateDiscount(double newValue, double oldValue)
      {
         billDiscount = newValue > 100 ? 10 : 0;
      }      
   }      
   
   // this factory creates an injectable object called "Items" whose value is an array of CartItem objects
   public class ItemsFactory 
   {                        
      public List<CartItem> Items()
      {
         var items = new List<CartItem>();
         items.Add( new CartItem() { title="AaAa", quantity=1024, price=44.95 } );
         items.Add( new CartItem() { title="BBBB", quantity=2048, price=55.95 } );
         items.Add( new CartItem() { title="CCCC", quantity=4096, price=66.95 } );
         items.Add( new CartItem() { title="dddd", quantity=1024, price=44.95 } );
         items.Add( new CartItem() { title="eeee", quantity=2048, price=55.95 } );
         items.Add( new CartItem() { title="ffff", quantity=4096, price=66.95 } );
         return items;
      }
   }
   
   // this factory creates an injectable object called "LabelPounds" whose value is "GBP"
   public class LabelsFactory 
   {                  
      public string LabelPounds()
      {        
         return "GBP";
      }
   }

   public class Filters
   {                  
      string label_pounds;

      public Filters(string LabelPounds)
      {         
         label_pounds = LabelPounds;
      }

      public string euro(double input)
      {         
         return input.ToString() + " euros " ;
      }

      public string pounds(double input)
      {
         return (input*1.25).ToString() + " "+label_pounds ;
      }
   }                                 
}

