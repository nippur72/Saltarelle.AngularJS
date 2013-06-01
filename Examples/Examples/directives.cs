using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

namespace TestAngularJS
{                           
   public class DirectivesExample
   {
      public static void Main()
      {
         Module app = new Module("myApp");
         
         app.RegisterDirective( new AccordionDefinition() );
         app.RegisterDirective( new ExpanderDefinition() );         
         app.RegisterDirective( new HelloDirective() );        
      }   
   }   
   
}
