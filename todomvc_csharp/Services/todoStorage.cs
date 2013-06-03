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
   
   /* we don't need the factory class, we can register directly the service "todoStorage"

   public class todoStorageService
   {
      public todoStorage todoStorage()
      {
         return new todoStorage();   
      }  
   }
   */

   public class todoStorage
   {
      private const string STORAGE_ID = "todos-angularjs";

      public List<TodoItem> get()
      {         
         List<TodoItem> items = Json.Parse<List<TodoItem>>((string) Window.LocalStorage.GetItem(STORAGE_ID));
         if(items==null) items = new List<TodoItem>();
         return items;
      }

      public void put(List<TodoItem> todos)
      {
         Window.LocalStorage.SetItem(STORAGE_ID, Json.Stringify(todos));
      }
   }
}

