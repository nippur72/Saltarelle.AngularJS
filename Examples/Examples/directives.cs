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
   public class DirectivesExample
   {      
      public static void Main()
      {
         Module app = new Module("myApp");   

         app.Directive<accordionDirective>();
         app.Directive<expanderDirective>();         
         app.Directive<helloDirective>();        

         app.Controller<TestDirectiveController>();
      }   
   }   

   public class TestDirectiveController
   {
      public TestDirectiveController(Scope _scope)
      {         
      }      
   }

   #region accordion directive

   public class accordionDirective : IDirective
   {            
      public DefinitionObject GetDefinition()
      {
         var def = new DirectiveDefinitionHelper();
                 
         def.Restrict = RestrictFlags.Element | RestrictFlags.Attribute;
         def.Replace = true;
         def.Transclude = true;
         def.ScopeMode = ScopeModes.Existing;
         def.Template = @"<div><div ng-click='acc.clickme()'>[{{acc.accordiontitle}}] you can click me</div><div ng-transclude></div>[end]</div>";                  
         def.Controller<AccordionController>();
         def.ControllerAs = "acc";         

         return def.ToDefinitionObject();         
      }            
   }   
   
   public class AccordionController 
   {      
      public string accordiontitle = "This is an accordion";

      public List<ExpanderController> expanders = new List<ExpanderController>();                     

      public void clickme()
      {        
         Window.Alert("clicked!");         
      }
      
      public void gotOpened(ExpanderController selectedExpander) 
      {
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

   #endregion

   #region expander directive

   public class expanderDirective : IDirective                                                                                      
   {
      public void Link(Scope _scope, AngularJS.jElement iElement, Attributes iAttrs, AccordionController acontroller)
      {                                    
         ExpanderController ctrl = _scope.ControllerAs<ExpanderController>("ccc");
         
         ctrl.accordionController = acontroller;      
         ctrl.accordionController.addExpander(ctrl);                           
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
                             <div class='title' ng-click='ccc.toggle()'>{{title}}</div>
                             <div style='margin-left: 1em;' class='body' ng-show='ccc.showMe' ng-transclude></div>
                          </div>";                                           

         def.LinkFunction<AccordionController>(this.Link);
         
         def.Controller<ExpanderController>();
         def.ControllerAs = "ccc";

         return def.ToDefinitionObject();
      }
   }   

   public class ExpanderController
   {
      public Scope Scope;
      
      public bool showMe = false;
      public AccordionController accordionController;  
      
      public ExpanderController(Scope _scope)
      {
         Scope = _scope;
      }          
           
      public void toggle()
      {                                   
         showMe = !showMe;
         accordionController.gotOpened(this);
      }    
   }

   #endregion
   
   #region hello directive

   // this simple directive shows the usage of transclusion

   public class helloDirective : IDirective
   {
      public DefinitionObject GetDefinition()
      {                  
         var def = new DirectiveDefinitionHelper();         
         def.Restrict = RestrictFlags.Element | RestrictFlags.Attribute | RestrictFlags.Class;
         def.Template = "<div>Hello, <span ng-transclude></span>!</div>";
         def.Replace = true;         
         def.Transclude = true;         
         return def.ToDefinitionObject();
      }           
   } 
   #endregion 
}
