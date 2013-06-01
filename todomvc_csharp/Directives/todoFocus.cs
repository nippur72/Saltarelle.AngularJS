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
    * Directive that places focus on the element it is applied to when the expression it binds to evaluates to true
    */
   public class todoFocusDefinition : DirectiveDefinition
   {
      public todoFocusDefinition()
      {
         Name = "todoFocus";
         DirectiveController = typeof(todoFocusController);
      }        
   }

   public class todoFocusController : Scope
   {
      public todoFocusController(Scope _scope, AngularJS.Element elem, Attributes attrs)
      {
         _scope.Watch<string>(attrs["todoFocus"], FocusTimeout);         
      }

      public void FocusTimeout(string newValue, string oldValue)
      {
			/* ###
         if(newVal!=null) 
         {
				$timeout(function () 
            {
					elem[0].focus();
				}, 0, false);
			}
         */         
      }
   }
}


/*
todomvc.directive('todoFocus', function todoFocus($timeout) {
	return function (scope, elem, attrs) {
		scope.$watch(attrs.todoFocus, function (newVal) {
			if (newVal) {
				$timeout(function () {
					elem[0].focus();
				}, 0, false);
			}
		});
	};
});
}
*/
