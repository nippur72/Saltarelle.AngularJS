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
    * Services that persists and retrieves TODOs from localStorage
    */

   public class todoStorageService
   {
      public static TodoStorage todoStorage()
      {
         return new TodoStorage();   
      }  
   }

   public class TodoStorage
   {
      private const string STORAGE_ID = "todos-angularjs";

      public List<TodoItem> get()
      {         
         return Json.Parse<List<TodoItem>>((string) Window.LocalStorage.GetItem(STORAGE_ID));
      }

      public void put(List<TodoItem> todos)
      {
         Window.LocalStorage.SetItem(STORAGE_ID, Json.Stringify(todos));
      }
   }
}

