(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Todo.TodoApp
	var $Todo_TodoApp = function() {
	};
	$Todo_TodoApp.Main = function() {
		// The main TodoMVC app module
		var todoapp = angular.module('todomvc', []);
		// directives
		AngularJS.AngularUtils.RegisterDirective(todoapp, new $Todo_todoBlurDefinition());
		AngularJS.AngularUtils.RegisterDirective(todoapp, new $Todo_todoFocusDefinition());
		// services
		AngularJS.AngularUtils.RegisterFactory(todoapp, $Todo_todoStorageService);
		// controllers
		AngularJS.AngularUtils.RegisterController(todoapp, $Todo_TodoCtrl);
	};
	////////////////////////////////////////////////////////////////////////////////
	// Todo.todoBlurController
	var $Todo_todoBlurController = function(_scope, elem, attrs) {
		this.$attrs = null;
		AngularJS.Scope.call(this);
		this.$attrs = attrs;
		elem.bind('blur', ss.mkdel(this, this.Blur));
	};
	$Todo_todoBlurController.prototype = {
		Blur: function() {
			this.$apply(this.$attrs['todoBlur']);
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Todo.todoBlurDefinition
	var $Todo_todoBlurDefinition = function() {
		AngularJS.DirectiveDefinition.call(this);
		this.Name = 'todoBlur';
		this.DirectiveController = $Todo_todoBlurController;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Todo.TodoCtrl
	var $Todo_TodoCtrl = function(_scope, _location, todoStorage, filterFilter) {
		this.todos = null;
		this.newTodo = null;
		this.editedTodo = null;
		this.remainingCount = 0;
		this.completedCount = 0;
		this.allChecked = false;
		this.$todoStorage = null;
		this.$filterFilter = null;
		this.$location = null;
		AngularJS.Scope.call(this);
		this.$todoStorage = todoStorage;
		this.$filterFilter = filterFilter;
		this.$location = _location;
		this.todos = todoStorage.get();
		this.newTodo = '';
		this.editedTodo = null;
		this.$watch('todos', ss.mkdel(this, this.update));
		if (this.$location.path() === '') {
			this.$location.path('/');
		}
		this.$watch('location.path()', ss.mkdel(this, this.pathchanged));
	};
	$Todo_TodoCtrl.prototype = {
		update: function() {
			this.remainingCount = this.$filterFilter(this.todos, { completed: false }).length;
			this.completedCount = this.todos.length - this.remainingCount;
			this.allChecked = this.remainingCount === 0;
			this.$todoStorage.put(this.todos);
		},
		pathchanged: function(path, oldpath) {
			//  ###
			//  $scope.statusFilter = (path === '/active') ?
			//  { completed: false } : (path === '/completed') ?
			//  { completed: true } : null;
			//  }
		},
		addTodo: function() {
			var newTodo = this.newTodo.trim();
			if (newTodo.length === 0) {
				return;
			}
			var $t2 = this.todos;
			var $t1 = new $Todo_TodoItem();
			$t1.title = newTodo;
			$t1.completed = false;
			ss.add($t2, $t1);
			this.newTodo = '';
		},
		editTodo: function(todo) {
			this.editedTodo = todo;
		},
		doneEditing: function(todo) {
			this.editedTodo = null;
			todo.title = todo.title.trim();
			if (todo.title === '') {
				this.removeTodo(todo);
			}
		},
		removeTodo: function(todo) {
			ss.remove(this.todos, todo);
		},
		clearCompletedTodos: function() {
			this.todos = this.todos.filter(function(val) {
				return !val.completed;
			});
		},
		markAll: function(completed) {
			for (var $t1 = 0; $t1 < this.todos.length; $t1++) {
				var todo = this.todos[$t1];
				todo.completed = completed;
			}
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Todo.todoFocusController
	var $Todo_todoFocusController = function(_scope, elem, attrs) {
		AngularJS.Scope.call(this);
		_scope.$watch(attrs['todoFocus'], ss.mkdel(this, this.FocusTimeout));
	};
	$Todo_todoFocusController.prototype = {
		FocusTimeout: function(newValue, oldValue) {
			// ###
			// if(newVal!=null)
			// {
			// $timeout(function ()
			// {
			// elem[0].focus();
			// }, 0, false);
			// }
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Todo.todoFocusDefinition
	var $Todo_todoFocusDefinition = function() {
		AngularJS.DirectiveDefinition.call(this);
		this.Name = 'todoFocus';
		this.DirectiveController = $Todo_todoFocusController;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Todo.TodoItem
	var $Todo_TodoItem = function() {
		this.title = null;
		this.completed = false;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Todo.TodoStorage
	var $Todo_TodoStorage = function() {
	};
	$Todo_TodoStorage.prototype = {
		get: function() {
			return JSON.parse(ss.cast(window.localStorage.getItem($Todo_TodoStorage.$STORAGE_ID), String));
		},
		put: function(todos) {
			window.localStorage.setItem($Todo_TodoStorage.$STORAGE_ID, JSON.stringify(todos));
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Todo.todoStorageService
	var $Todo_todoStorageService = function() {
	};
	$Todo_todoStorageService.todoStorage = function() {
		return new $Todo_TodoStorage();
	};
	ss.registerClass(global, 'Todo.TodoApp', $Todo_TodoApp);
	ss.registerClass(global, 'Todo.todoBlurController', $Todo_todoBlurController, AngularJS.Scope);
	ss.registerClass(global, 'Todo.todoBlurDefinition', $Todo_todoBlurDefinition, AngularJS.DirectiveDefinition);
	ss.registerClass(global, 'Todo.TodoCtrl', $Todo_TodoCtrl, AngularJS.Scope);
	ss.registerClass(global, 'Todo.todoFocusController', $Todo_todoFocusController, AngularJS.Scope);
	ss.registerClass(global, 'Todo.todoFocusDefinition', $Todo_todoFocusDefinition, AngularJS.DirectiveDefinition);
	ss.registerClass(global, 'Todo.TodoItem', $Todo_TodoItem);
	ss.registerClass(global, 'Todo.TodoStorage', $Todo_TodoStorage);
	ss.registerClass(global, 'Todo.todoStorageService', $Todo_todoStorageService);
	$Todo_TodoStorage.$STORAGE_ID = 'todos-angularjs';
})();
