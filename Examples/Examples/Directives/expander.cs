using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

namespace TestAngularJS
{                        
   public class ExpanderDefinition : DirectiveDefinition                                                                                        
   {
      public ExpanderDefinition()
      {
         Name = "expander";
         Restrict = RestrictFlags.Element;
         Replace = true;
         Transclude = true;
         Require = RequireDirective("accordion", LookParent:true, Optional:false);
         ScopeMode = ScopeModes.Isolate;
         ScopeAttributes.Add( new ScopeBindings("title", BindingStrategies.AsString, "expanderTitle") );
         Template = @"<div>
                         <div class='title' ng-click='toggle()'>{{title}}</div>
                         <div class='body' ng-show='showMe' ng-transclude></div>
                      </div>";
         
         DirectiveController = typeof(ExpanderController); 
      }
   }

   public class ExpanderController
   {   
      public string title;
      public bool showMe;
      public AccordionSharedController accordionController;      

      public void Link(ExpanderController _scope, AngularJS.Element iElement, Attributes iAttrs, AccordionSharedController acontroller)
      {
         accordionController = acontroller;
         showMe = false;
         
         accordionController.addExpander(this);
      }

      public void toggle()
      {
         showMe = !showMe;
         accordionController.gotOpened(this);
      }            
   }
}
