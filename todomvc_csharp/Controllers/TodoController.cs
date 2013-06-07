using System;

using System.Html;
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
   
   /**
    * The main controller for the app. The controller:
    * - retrieves and persists the model via the todoStorage service
    * - exposes the model to the template and provides event handlers
    */
   public class TodoCtrl : Scope
   {
      public TodoItem[] todos;
      public string newTodo;
      public TodoItem editedTodo;
      public object statusFilter;
      public int remainingCount;
      public int completedCount;
      public bool allChecked;
      
      // injected objects
      public AngularJS.Location location;
      public todoStorage Storage;      
      public filterFilter filter;           
      
      public TodoCtrl(Scope _scope, AngularJS.Location _location, todoStorage todoStorage, filterFilter filterFilter)
      {
	      this.Storage = todoStorage;
         this.filter = filterFilter;         
         this.location = _location;

         todos = Storage.get();      

	      newTodo = "";
	      editedTodo = null;

         Watch<object>(()=>todos, update, true);

	      if(location.Path == "") location.Path = "/";
	      	      
         Watch<string>(()=>location.Path, pathchanged);         
      }            

      public void update()
      {		           
         remainingCount = filter.Filter(todos, new { completed=false }).Length;
		   completedCount = todos.Length - remainingCount;
		   allChecked = remainingCount==0;
		   Storage.put(todos);
      }	

      public void pathchanged(string path, string oldpath)
      {
         statusFilter = (path == "/active")    ? new { completed=false } : 
                        (path == "/completed") ? new { completed=true  } : null;	
      }
      
      public void addTodo() 
      {		  
         string newTodo = this.newTodo.Trim();         
                  
		   if(newTodo.Length==0) 
         {
			   return;
         }                    
         todos.Push(new TodoItem() { title=newTodo, completed=false });         
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
         todos.Splice(todos.IndexOf(todo), 1);     
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
   
   public static class ArrayExtensions2
   {   		     
      [InlineCode("{array}.push({*items})")]      
		public static int Push<T>(this T[] array, params T[] items) { return -1; }
                             		
      [InlineCode("{array}.splice({index},{howmany})")]      
		public static T[] Splice<T>(this T[] array, int index, int howmany) { return null; }
		
      [InlineCode("{array}.splice({index},{howmany},{*items})")]      
		public static T[] Splice<T>(this T[] array, int index, int howmany, params T[] items) { return null; }
   }
}
   
/*
pop
   Removes the last element from an array and returns that element.
push
   Adds one or more elements to the end of an array and returns the new length of the array.
reverse
   Reverses the order of the elements of an array -- the first becomes the last, and the last becomes the first.
shift
   Removes the first element from an array and returns that element.
sort
   Sorts the elements of an array in place and returns the array.
splice
   Adds and/or removes elements from an array.
unshift
   Adds one or more elements to the front of an array and returns the new length of the array.
      

concat
   Returns a new array comprised of this array joined with other array(s) and/or value(s).
join
   Joins all elements of an array into a string.
slice
   Extracts a section of an array and returns a new array.
toSource Non-standard
   Returns an array literal representing the specified array; you can use this value to create a new array. Overrides the Object.prototype.toSource method.
toString
   Returns a string representing the array and its elements. Overrides the Object.prototype.toString method.
indexOf Requires JavaScript 1.6
   Returns the first (least) index of an element within the array equal to the specified value, or -1 if none is found.
lastIndexOf Requires JavaScript 1.6
   Returns the last (greatest) index of an element within the array equal to the specified value, or -1 if none is found.


concat
   Returns a new array comprised of this array joined with other array(s) and/or value(s).
join
   Joins all elements of an array into a string.
slice
   Extracts a section of an array and returns a new array.
toSource Non-standard
   Returns an array literal representing the specified array; you can use this value to create a new array. Overrides the Object.prototype.toSource method.
toString
   Returns a string representing the array and its elements. Overrides the Object.prototype.toString method.
indexOf Requires JavaScript 1.6
   Returns the first (least) index of an element within the array equal to the specified value, or -1 if none is found.
lastIndexOf Requires JavaScript 1.6
   Returns the last (greatest) index of an element within the array equal to the specified value, or -1 if none is found.

   }             
}

/*
public static class ArrayExtensions {
		[InlineCode("{$System.Script}.contains({array}, {item})")]
		public static bool Contains<T>(this T[] array, T item) { return false; }

		[InlineCode("{$System.Script}.arrayClone({array})")]
		public static T[] Clone<T>(this T[] array) { return null; }

		[InstanceMethodOnFirstArgument, IncludeGenericArguments(false)]
		public static T[] Concat<T>(this T[] array, params T[] items) { return null; }

		[InstanceMethodOnFirstArgument, IncludeGenericArguments(false)]
		public static bool Every<T>(this T[] array, Func<T, int, T[], bool> callback) { return false; }

		[InstanceMethodOnFirstArgument, IncludeGenericArguments(false)]
		public static bool Every<T>(this T[] array, Func<T, bool> callback) { return false; }

		[InlineCode("{$System.Script}.arrayExtract({array}, {start})")]
		public static T[] Extract<T>(this T[] array, int start) { return null; }

		[InlineCode("{$System.Script}.arrayExtract({array}, {start}, {count})")]
		public static T[] Extract<T>(this T[] array, int start, int count) { return null; }

		[InstanceMethodOnFirstArgument, IncludeGenericArguments(false)]
		public static T[] Slice<T>(this T[] array, int start) { return null; }

		[InstanceMethodOnFirstArgument, IncludeGenericArguments(false)]
		public static T[] Slice<T>(this T[] array, int start, int end) { return null; }

		[InstanceMethodOnFirstArgument, IncludeGenericArguments(false)]
		public static T[] Filter<T>(this T[] array, Func<T, int, T[], bool> callback) { return null; }

		[InstanceMethodOnFirstArgument, IncludeGenericArguments(false)]
		public static T[] Filter<T>(this T[] array, Func<T, bool> callback) { return null; }

		[InstanceMethodOnFirstArgument, IncludeGenericArguments(false)]
		public static void ForEach<T>(this T[] array, Action<T, int, T[]> callback) {}

		[InstanceMethodOnFirstArgument, IncludeGenericArguments(false)]
		public static void ForEach<T>(this T[] array, Action<T> callback) {}

		[InlineCode("{$System.Script}.indexOf({array}, {item})")]
		public static int IndexOf<T>(this T[] array, T item) { return 0; }

		[InlineCode("{$System.Script}.indexOfArray({array}, {item}, {startIndex})")]
		public static int IndexOf<T>(this T[] array, T item, int startIndex) { return 0; }

		[InstanceMethodOnFirstArgument, IncludeGenericArguments(false)]
		public static TResult[] Map<TSource, TResult>(this TSource[] array, Func<TSource, int, TSource[], TResult> callback) { return null; }

		[InstanceMethodOnFirstArgument, IncludeGenericArguments(false)]
		public static TResult[] Map<TSource, TResult>(this TSource[] array, Func<TSource, TResult> callback) { return null; }

		[InstanceMethodOnFirstArgument, IncludeGenericArguments(false)]
		public static bool Some<T>(this T[] array, Func<T, int, T[], bool> callback) { return false; }

		[InstanceMethodOnFirstArgument, IncludeGenericArguments(false)]
		public static bool Some<T>(this T[] array, Func<T, bool> callback) { return false; }

		[InstanceMethodOnFirstArgument, IncludeGenericArguments(false)]
		public static void Sort<T>(this T[] array) {}

		[InstanceMethodOnFirstArgument, IncludeGenericArguments(false)]
		public static void Sort<T>(this T[] array, Func<T, T, int> compareCallback) {}
	}

	/// <summary>
	/// Equivalent to the Array type in Javascript.
	/// </summary>
	[IgnoreNamespace]
	[Imported(ObeysTypeSystem = true)]
	public sealed class Array : IEnumerable {

		[IntrinsicProperty]
		public int Length {
			get {
				return 0;
			}
		}

		[IntrinsicProperty]
		public object this[int index] {
			get {
				return null;
			}
			set {
			}
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return null;
		}

		[InlineCode("new {$System.ArrayEnumerator}({this})")]
		public ArrayEnumerator GetEnumerator() {
			return null;
		}

		public string Join() {
			return null;
		}

		public string Join(string delimiter) {
			return null;
		}

		public void Reverse() {
		}

		[InlineCode("{$System.Script}.arrayGet2({this}, {indices})")]
		public object GetValue(params int[] indices) {
			return null;
		}

		[InlineCode("{$System.Script}.arraySet2({this}, {value}, {indices})")]
		public void SetValue(object value, params int[] indices) {
		}

		[InlineCode("{$System.Script}.arrayLength({this}, {dimension})")]
		public int GetLength(int dimension) {
			return 0;
		}

		public int Rank { [InlineCode("{$System.Script}.arrayRank({this})")] get { return 0; } }

		[InlineCode("0")]
		public int GetLowerBound(int dimension) {
			return 0;
		}

		[InlineCode("{$System.Script}.arrayLength({this}, {dimension}) - 1")]
		public int GetUpperBound(int dimension) {
			return 0;
		}

		[InlineCode("{$System.Script}.repeat({value}, {count})")]
		public static T[] Repeat<T>(T value, int count) {
			return null;
		}
	}
}

*/


