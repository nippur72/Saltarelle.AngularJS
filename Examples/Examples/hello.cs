using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

namespace TestAngularJS
{                      
   public class HelloModel : Scope
   {
      public string greetings;      
   }   
   
   [Reflectable]
   public class HelloControllers 
   {     
      [Reflectable]
      public static void HelloController(HelloModel scope)
      {         
         scope.greetings = "Douglas Adams";
      }           	
   }                                                                                             
}
