using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

namespace TestAngularJS
{                        
   public class expanderDirective : IDirective                                                                                      
   {
      public string title;
      public bool showMe;
      public AccordionSharedController accordionController;      

      public void Link(Scope _scope, AngularJS.Element iElement, Attributes iAttrs, object acontroller)
      {         
         accordionController = Script.Reinterpret<AccordionSharedController>(acontroller);
         showMe = false;
         
         accordionController.addExpander(this);
      }

      public void toggle()
      {
         showMe = !showMe;
         accordionController.gotOpened(this);
      } 
      
      public DefinitionObject GetDefinition()
      {
         var def = new DirectiveDefinitionHelper();
         
         def.Restrict = RestrictFlags.Element;
         def.Replace = true;
         def.Transclude = true;         
         def.RequireDirective("accordion", LookParent:true, Optional:false);
         def.ScopeMode = ScopeModes.Isolate;
         def.BindAttribute("title", "expanderTitle");
         def.Template = @"<div>
                         <div class='title' ng-click='toggle()'>{{title}}</div>
                         <div class='body' ng-show='showMe' ng-transclude></div>
                      </div>";
         
         def.Link = this.Link;

         return def.ToDefinitionObject();
      }
   }   
}
