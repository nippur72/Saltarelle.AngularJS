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
   public class ngModelControllerExample
   {      
      public static void Main()
      {
         Module app = new Module("myApp", "ngSanitize");   
         
         app.Directive<contenteditableDirective>();
         app.Controller<TestDirectiveController>();
      }   
   }   

   public class contenteditableDirective : IDirective
   {
      dynamic _sce; // there are no metadata (yet) for $sce, we treat is as dynamic

      public contenteditableDirective(dynamic _sce)
      {
         // save the injectable
         this._sce = _sce;
      }

      public DefinitionObject GetDefinition()
      {
         var def = new DirectiveDefinitionHelper();

         def.Restrict = RestrictFlags.Attribute;
         def.RequireDirective("ngModel", false, true);
         def.LinkFunction<NgModelController>(this.Link);         
                                          
         return def.ToDefinitionObject();
      }      

      public void Link(Scope scope, AngularJS.Element el, Attributes attrs, NgModelController ngModel)      
      {
         dynamic element = el;

         if(ngModel==null) return; // do nothing if no ng-model

         // Write data to the model
         Action read = ()=>                 
         {
            var html = element.html();
            // When we clear the content editable the browser leaves a <br> behind
            // If strip-br attribute is provided then we strip this out
            string stripBr = attrs["stripBr"];
            if( stripBr!="" && html == "<br>" ) html = "";            
            ngModel.setViewValue(html);
         };

         // Specify how UI should be updated
         ngModel.render = ()=> {
            element.html(_sce.getTrustedHtml(ngModel.viewValue));
         };

         // Listen for change events to enable binding
         element.on("blur keyup change", (Action) delegate() {
            scope.Apply(read);
         });
         read(); // initialize
      }
   }
}
