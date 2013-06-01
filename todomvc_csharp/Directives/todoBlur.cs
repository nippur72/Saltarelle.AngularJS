using System;

using System.Html;
using System.Html.Data;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

namespace Todo
{
   /**
    * Directive that executes an expression when the element it is applied to loses focus
    */

   public class todoBlurDefinition : DirectiveDefinition
   {
      public todoBlurDefinition()
      {
         Name = "todoBlur";
         DirectiveController = typeof(todoBlurController);
      }
   }

   public class todoBlurController : Scope
   {
      Attributes attrs;

      public todoBlurController(Scope _scope, AngularJS.Element elem, Attributes attrs)
      {
         this.attrs = attrs;

         elem.bind("blur",Blur);         
      }

      public void Blur()
      {
         this.Apply(attrs["todoBlur"]);
      }
   }
}

/*
   todomvc.directive('todoBlur', function () {
	return function (scope, elem, attrs) {
		elem.bind('blur', function () {
			scope.$apply(attrs.todoBlur);
		});
	};
});
*/

