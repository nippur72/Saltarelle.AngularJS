using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

namespace TestAngularJS
{                        
   public class ShoppingCartExample
   {
      public static void Main()
      {
         Module app = new Module("myApp");
         app.RegisterFactory(typeof(ItemsFactory)); 
         app.RegisterFactory(typeof(LabelsFactory)); 
         app.RegisterFilter(typeof(Filters));        
         app.RegisterController(typeof(CartController));
      }   
   }
   
   public class CartItem
   {
      public string title;
      public double quantity;
      public double price;
   } 
   
   public class CartController : Scope
   {
      public List<CartItem> items;
      public double billDiscount;

      public CartController(Scope _scope, List<CartItem> Items)
      {
         zeroitems();
         items = Items;
         Watch<double>(totalCart, calculateDiscount);
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
        
   public class ItemsFactory 
   {                        
      public List<CartItem> Items()
      {
         var items = new List<CartItem>();
         items.Add( new CartItem() { title="AaAa", quantity= 1024, price= 44.95 } );
         items.Add( new CartItem() { title="BBBB", quantity= 2048, price= 55.95 } );
         items.Add( new CartItem() { title="CCCC", quantity= 4096, price= 66.95 } );
         items.Add( new CartItem() { title="dddd", quantity= 1024, price= 44.95 } );
         items.Add( new CartItem() { title="eeee", quantity= 2048, price= 55.95 } );
         items.Add( new CartItem() { title="ffff", quantity= 4096, price= 66.95 } );
         return items;
      }
   }
         
   public class LabelsFactory 
   {                  
      public string LabelEuro()
      {
         return "CHF";
      }
   }

   public class Filters
   {                  
      string le;

      public Filters(string LabelEuro)
      {         
         le = LabelEuro;
      }

      public string euro(double input)
      {
         return input.ToString() + " euros ("+le+")" ;
      }

      public string dracma(double input)
      {
         return input.ToString() + " dracmas " ;
      }
   }                                 
}

