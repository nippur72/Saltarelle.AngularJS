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
   public class accordionDirective : IDirective
   {
      public string ppp;
      public List<CartItem> Items;
      
      public accordionDirective(List<CartItem> Items)
      {
         //Debug.Break();
         this.Items = Items;
      }

      public void Link(Scope _scope, AngularJS.Element iElement, Attributes iAttrs, object acontroller)      
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

      public DefinitionObject GetDefinition()
      {
         var def = new DirectiveDefinitionHelper();
                 
         def.Restrict = RestrictFlags.Element | RestrictFlags.Attribute;
         def.Replace = true;
         def.Transclude = true;
         def.ScopeMode = ScopeModes.Isolate;
         def.Template = @"<div><div ng-click='clickme()'>click me</div><div ng-transclude></div></div>";
         //def.//Template = @"<div ng-transclude></div>";
         def.Controller<AccordionSharedController>();
         def.Link = this.Link;

         return def.ToDefinitionObject();         
      }            
   }   

   
   public class AccordionSharedController 
   {      
      public string pppp;
      public List<expanderDirective> expanders = new List<expanderDirective>();

      public AccordionSharedController()
      {         
         //System.Diagnostics.Debug.Break();
         Window.Alert("Shared controller initialized");
         pppp = "constructor ok";         
      }                      
      
      public void gotOpened(expanderDirective selectedExpander) 
      {
       //  Window.Alert("gotOpened called ["+pppp+"]");

         foreach(var o in expanders)
         {
            if(selectedExpander!=o) o.showMe = false;            
         }
      }

      public void addExpander(expanderDirective expander) 
      {
       //  Window.Alert("addExpander called ["+pppp+"]");

         expanders.Add(expander);
      }
   }
}
