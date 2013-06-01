using System;
using System.Html;
using System.Html.Data;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

[assembly: PreserveMemberCase]

namespace Todo
{
   public class TodoApp
   {
      public static void Main()
      {
         // The main TodoMVC app module
         Module todoapp = new Module("todomvc");
         
         // directives
         todoapp.RegisterDirective( new todoBlurDefinition() );         
         todoapp.RegisterDirective( new todoFocusDefinition() );
                  
         // services
         todoapp.RegisterFactory(typeof(todoStorageService));

         // controllers
         todoapp.RegisterController(typeof(TodoCtrl));
      }
   }
}
