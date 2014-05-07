using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

namespace TestAngularJS
{                      
   public class helloDirective : IDirective
   {
      public DefinitionObject GetDefinition()
      {                  
         var def = new DirectiveDefinitionHelper();         
         def.Restrict = RestrictFlags.Element | RestrictFlags.Attribute | RestrictFlags.Class;
         def.Template = "<div>Hello <span ng-transclude></span>!</div>";
         def.Replace = true;         
         def.Transclude = true;         
         return def.ToDefinitionObject();
      }           
   }      
}
