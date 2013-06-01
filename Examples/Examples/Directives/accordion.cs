using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

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
         Template = @"<div><div ng-click='clickme()'>CLICCAMI</div><div ng-transclude></div></div>";
         //Template = @"<div ng-transclude></div>";
         SharedController = typeof(AccordionSharedController); 
         DirectiveController = typeof(AccordionController);        
      }           
   }   

   public class AccordionController 
   {      
      public AccordionController(Scope _scope, AngularJS.Element iElement, Attributes iAttrs, AccordionSharedController acontroller)
      {
         //System.Diagnostics.Debug.Break();
      }

      public void clickme()
      {
         Window.Alert("clicked");
      }
   }
   
   public class AccordionSharedController 
   {      
      public string pppp;
      public List<ExpanderController> expanders = new List<ExpanderController>();

      public AccordionSharedController()
      {         
         //Window.Alert("muuuu");
         pppp = "constructor ok";         
      }           
      
      public void clickme()
      {
         Window.Alert("clicked");
      }
      
      public void gotOpened(ExpanderController selectedExpander) 
      {
         //Window.Alert(pppp);

         foreach(var o in expanders)
         {
            if(selectedExpander!=o) o.showMe = false;            
         }
      }

      public void addExpander(ExpanderController expander) 
      {
         expanders.Add(expander);
      }
   }
}
