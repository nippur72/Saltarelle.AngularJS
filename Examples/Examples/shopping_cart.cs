using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

namespace TestAngularJS
{                        
   public class CartItem
   {
      public string title;
      public double quantity;
      public double price;
   }

   public class CartModel : Scope
   {
      public List<CartItem> items;
      public Action<int> remove;                 
      public Func<double> totalCart;
      public Func<double> subtotal;
      public double billDiscount;
   }      
   
   [Reflectable]
   public class CartControllers 
   {     
      [Reflectable]      
      public static void CartController(CartModel scope, List<CartItem> Items)
      {
         scope.items = Items;         

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
            return scope.totalCart() - scope.billDiscount;
         };

         WatchListener<double> calculateDiscount = (newValue,oldValue) =>
         {
            scope.billDiscount = (double) newValue > 100 ? 10 : 0;
         };

         scope.Watch<double>(scope.totalCart, calculateDiscount);
      }                                                                                      
   } 
   
   [Reflectable]
   public class CartFactory 
   {            
      [Reflectable]
      public static List<CartItem> Items()
      {
         var items = new List<CartItem>();
         items.Add( new CartItem() { title="AAAA", quantity= 1024, price= 44.95 } );
         items.Add( new CartItem() { title="BBBB", quantity= 2048, price= 55.95 } );
         items.Add( new CartItem() { title="CCCC", quantity= 4096, price= 66.95 } );
         items.Add( new CartItem() { title="dddd", quantity= 1024, price= 44.95 } );
         items.Add( new CartItem() { title="eeee", quantity= 2048, price= 55.95 } );
         items.Add( new CartItem() { title="ffff", quantity= 4096, price= 66.95 } );
         return items;
      }
   }    
   
   [Reflectable]
   public class CartFilters
   {            
      [Reflectable]
      public static string euro(double input)
      {
         return input.ToString() + " euros";
      }
   }                 

   public class PhoneScope : Scope
   {
      public string what;
      public int phoneId;
      public JsDictionary person;
   }

   public class PhoneRouteParams : RouteParams
   {
      public int phoneId;
   }

   [Reflectable]
   public class PhoneController
   {            
      [Reflectable]
      public static void PhoneListController(PhoneScope scope, Http http)
      {
         scope.what = "main";         

         /*
         http.Get("hello.html").Success((data,status)=> {
            Window.Alert(data.ToString());
         }).Error((data,status)=>{ 
            Window.Alert("errore!");
         });
         */

         var risp = http.Get("data.json");

         risp.Success((data,status,header)=> 
         {            
            scope.person = (JsDictionary) data;
            Window.Alert(scope.person["name"].ToString());
         });

         risp.Error((data,status)=>
         { 
            Window.Alert("errore!");
         });                
      }

      [Reflectable]
      public static void PhoneListControllerDetail(PhoneScope scope, PhoneRouteParams routeParams)
      {
         scope.what = "detail";
         scope.phoneId = routeParams.phoneId;
      }
   }                 

   [Reflectable]
   public class PhoneConfig
   {            
      [Reflectable]
      public static void InitRoute(RouteProvider routeProvider)
      {
         routeProvider.when("/phones"          , new RouteMap() { TemplateUrl = "phonemain.html"   })
                      .when("/phones/:phoneId" , new RouteMap() { TemplateUrl = "phonedetail.html" })
                      .otherwise(                new RouteMap() { RedirectTo  = "/phones"          });
      }
   }                 
}
