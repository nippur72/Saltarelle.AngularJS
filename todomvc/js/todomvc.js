(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Todo.ArrayExtensions2
	var $Todo_ArrayExtensions2 = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// Todo.TodoApp
	var $Todo_TodoApp = function() {
	};
	$Todo_TodoApp.Main = function() {
		// The main TodoMVC app module
		var todoapp = angular.module('todomvc', []);
		// directives
		AngularJS.AngularUtils.Directive($Todo_todoBlurDefinition).call(null, todoapp);
		AngularJS.AngularUtils.Directive($Todo_todoFocusDefinition).call(null, todoapp);
		// services         
		AngularJS.AngularUtils.Service($Todo_todoStorage).call(null, todoapp);
		// controllers
		AngularJS.AngularUtils.Controller($Todo_TodoCtrl).call(null, todoapp);
	};
	////////////////////////////////////////////////////////////////////////////////
	// Todo.todoBlurController
	var $Todo_todoBlurController = function() {
		AngularJS.Scope.call(this);
	};
	$Todo_todoBlurController.prototype = {
		Link: function(_scope, elem, attrs) {
			elem.bind('blur', ss.mkdel(this, function() {
				this.$apply(attrs['todoBlur']);
			}));
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
		this.statusFilter = null;
		this.remainingCount = 0;
		this.completedCount = 0;
		this.allChecked = false;
		this.location = null;
		this.Storage = null;
		this.filter = null;
		AngularJS.Scope.call(this);
		this.Storage = todoStorage;
		this.filter = filterFilter;
		this.location = _location;
		this.todos = this.Storage.get();
		this.newTodo = '';
		this.editedTodo = null;
		this.$watch(ss.mkdel(this, function() {
			return this.todos;
		}), ss.mkdel(this, this.update), true);
		if (this.location.path() === '') {
			this.location.path('/');
		}
		this.$watch(ss.mkdel(this, function() {
			return this.location.path();
		}), ss.mkdel(this, this.pathchanged));
	};
	$Todo_TodoCtrl.prototype = {
		update: function() {
			this.remainingCount = this.filter(this.todos, { completed: false }).length;
			this.completedCount = this.todos.length - this.remainingCount;
			this.allChecked = this.remainingCount === 0;
			this.Storage.put(this.todos);
		},
		pathchanged: function(path, oldpath) {
			this.statusFilter = ((path === '/active') ? { completed: false } : ((path === '/completed') ? { completed: true } : null));
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
			$t2.push($t1);
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
			this.todos.splice(ss.indexOf(this.todos, todo), 1);
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
	var $Todo_todoFocusController = function(_timeout) {
		this.timeout = null;
		AngularJS.Scope.call(this);
		this.timeout = _timeout;
	};
	$Todo_todoFocusController.prototype = {
		Link: function(_scope, elem, attrs) {
			this.$watch(attrs['todoFocus'], ss.mkdel(this, function(newValue, oldValue) {
				if (newValue) {
					this.timeout(function() {
						elem[0].focus();
					}, 0, false);
				}
			}));
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
	// Todo.todoStorage
	var $Todo_todoStorage = function() {
	};
	$Todo_todoStorage.prototype = {
		get: function() {
			var items = JSON.parse(ss.cast(window.localStorage.getItem($Todo_todoStorage.$STORAGE_ID), String));
			if (ss.isNullOrUndefined(items)) {
				items = [];
			}
			return items;
		},
		put: function(todos) {
			window.localStorage.setItem($Todo_todoStorage.$STORAGE_ID, JSON.stringify(todos));
		}
	};
	ss.registerClass(global, 'Todo.ArrayExtensions2', $Todo_ArrayExtensions2);
	ss.registerClass(global, 'Todo.TodoApp', $Todo_TodoApp);
	ss.registerClass(global, 'Todo.todoBlurController', $Todo_todoBlurController, AngularJS.Scope);
	ss.registerClass(global, 'Todo.todoBlurDefinition', $Todo_todoBlurDefinition, AngularJS.DirectiveDefinition);
	ss.registerClass(global, 'Todo.TodoCtrl', $Todo_TodoCtrl, AngularJS.Scope);
	ss.registerClass(global, 'Todo.todoFocusController', $Todo_todoFocusController, AngularJS.Scope);
	ss.registerClass(global, 'Todo.todoFocusDefinition', $Todo_todoFocusDefinition, AngularJS.DirectiveDefinition);
	ss.registerClass(global, 'Todo.TodoItem', $Todo_TodoItem);
	ss.registerClass(global, 'Todo.todoStorage', $Todo_todoStorage);
	$Todo_todoStorage.$STORAGE_ID = 'todos-angularjs';
})();
