using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

namespace TestAngularJS
{                      
   public class HelloDirective : DirectiveDefinition
   {
      public HelloDirective()
      {                  
         Name = "hello";
         Restrict = RestrictFlags.Element | RestrictFlags.Attribute | RestrictFlags.Class;
         Template = "<div>Hello <span ng-transclude></span>!</div>";
         Replace = true;
         ScopeMode = ScopeModes.Isolate;
         Transclude = true;
         ScopeAttributes.Add( new ScopeBindings("title", BindingStrategies.AsFunction) );
      }
      
      public void Link(dynamic scope, AngularJS.Element iElement, Attributes iAttrs)
      {
         //System.Diagnostics.Debug.Break();
      } 
   }      
}
