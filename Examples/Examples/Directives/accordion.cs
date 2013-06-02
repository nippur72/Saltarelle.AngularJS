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
   public class AccordionDefinition : DirectiveDefinition                                                                                        
   {
      public AccordionDefinition()
      {
         Name = "accordion";
         Restrict = RestrictFlags.Element | RestrictFlags.Attribute;
         Replace = true;
         Transclude = true;
         ScopeMode = ScopeModes.Isolate;
         Template = @"<div><div ng-click='clickme()'>click me</div><div ng-transclude></div></div>";
         //Template = @"<div ng-transclude></div>";
         SharedController = typeof(AccordionSharedController); 
         DirectiveController = typeof(AccordionController);        
      }           
   }   

   public class AccordionController 
   {      
      public string ppp;
      public List<CartItem> Items;

      public AccordionController(List<CartItem> Items)
      {
         //Debug.Break();
         this.Items = Items;
      }

      public void Link(Scope _scope, AngularJS.Element iElement, Attributes iAttrs, AccordionSharedController acontroller)      
      {
         //Debug.Break();
         ppp = "fissa";
      }

      public void clickme()
      {
         //Debug.Break();
         //Http h = Angular.InjectorRead("$http");
        // System.Diagnostics.Debug.Break();
         Window.Alert("clicked to "+ppp);
         Window.Alert("Items[0] is "+Items[0].title);         
      }
   }
   
   public class AccordionSharedController 
   {      
      public string pppp;
      public List<ExpanderController> expanders = new List<ExpanderController>();

      public AccordionSharedController()
      {         
         //System.Diagnostics.Debug.Break();
         Window.Alert("Shared controller initialized");
         pppp = "constructor ok";         
      }                      
      
      public void gotOpened(ExpanderController selectedExpander) 
      {
       //  Window.Alert("gotOpened called ["+pppp+"]");

         foreach(var o in expanders)
         {
            if(selectedExpander!=o) o.showMe = false;            
         }
      }

      public void addExpander(ExpanderController expander) 
      {
       //  Window.Alert("addExpander called ["+pppp+"]");

         expanders.Add(expander);
      }
   }
}
