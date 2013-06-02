using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

namespace TestAngularJS
{                           
   /*
   public class TestController : Scope
   {
      public string zzz;

      public TestController(Scope _scope, object _timeout)
      {  
         zzz = "ok";
         System.Diagnostics.Debug.Break();
      }
   }
   */
   
   /*
   public class testdirective
   {
      public string a;

      public testdirective(List<CartItem> Items)
      {
         System.Diagnostics.Debug.Break();
         a="55";
      }

      public void Link(Scope _scope, AngularJS.Element iElement, Attributes iAttrs)
      {
         Window.Alert("Link");
         System.Diagnostics.Debug.Break();
      }

      public void remove(int a)
      {
      }
   }
   */

   public class DirectivesExample
   {      
      public static void Main()
      {
         Module app = new Module("myApp");
                
         //app.Debug("service","pippo");                  
         //app.RegisterController( typeof(TestController) );         
         //app.RegisterFactory( typeof(ItemsFactory) );
         //app.RegisterDirectiveAsFactory("testdirective",typeof(testdirective));
         app.RegisterFactory( typeof(ItemsFactory) );
                 
         app.RegisterDirective( new AccordionDefinition() );
         app.RegisterDirective( new ExpanderDefinition() );         
         app.RegisterDirective( new HelloDirective() );        
      }   
   }   
   
}
