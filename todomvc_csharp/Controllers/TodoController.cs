using System;

//using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

namespace Todo
{             
   public class TodoItem
   {
      public string title;
      public bool completed;
   }

   public delegate List<TodoItem> filterFilterDelegate(List<TodoItem> array, dynamic expression);  
   
   /**
    * The main controller for the app. The controller:
    * - retrieves and persists the model via the todoStorage service
    * - exposes the model to the template and provides event handlers
    */
   public class TodoCtrl : Scope
   {
      public List<TodoItem> todos;
      public string newTodo;
      public TodoItem editedTodo;

      public int remainingCount;
      public int completedCount;
      public bool allChecked;

      TodoStorage todoStorage;
      filterFilterDelegate filterFilter;
      Location location;

      public TodoCtrl(Scope _scope, Location _location, TodoStorage todoStorage, filterFilterDelegate filterFilter)
      {
	      this.todoStorage = todoStorage;
         this.filterFilter = filterFilter;
         this.location = _location;

         todos = todoStorage.get();

	      newTodo = "";
	      editedTodo = null;

         Watch<object>("todos", update, true);

	      if(location.Path == "") 
         {
		      location.Path = "/";
	      }	

	      Watch<string>("location.path()", pathchanged);
      }

      public void update()
      {
		   remainingCount = filterFilter(todos, new { completed=false }).Count;
		   completedCount = todos.Count - remainingCount;
		   allChecked = remainingCount==0;
		   todoStorage.put(todos);
      }	

      public void pathchanged(string path, string oldpath)
      {
      /*  ###
		$scope.statusFilter = (path === '/active') ?
			{ completed: false } : (path === '/completed') ?
			{ completed: true } : null;
	}    */
      }
      
      public void addTodo() 
      {
		   string newTodo = this.newTodo.Trim();
                  
		   if(newTodo.Length==0) 
         {
			   return;
         }

         todos.Add(new TodoItem() { title=newTodo, completed=false });
         this.newTodo = "";
		}

      public void editTodo(TodoItem todo) 
      {
		   editedTodo = todo;
	   }

      public void doneEditing(TodoItem todo) 
      {
		   editedTodo = null;
		   todo.title = todo.title.Trim();

   		if(todo.title=="") 
         {
			   removeTodo(todo);
		   }
	   }

	   public void removeTodo(TodoItem todo) 
      {
		   todos.Remove(todo);         
	   }

	   public void clearCompletedTodos() 
      {
		   todos = todos.Filter( (val)=> { return !val.completed; } );   
	   }

      public void markAll(bool completed) 
      {
		   foreach(var todo in todos)
         {
            todo.completed = completed;
         }
   	}
   }              
}


