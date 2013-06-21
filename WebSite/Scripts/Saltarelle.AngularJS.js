(function() {
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.Angular.BuiltinFilters
	var $angular$BuiltinFilters = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.AngularUtils
	var $AngularJS_AngularUtils = function() {
	};
	$AngularJS_AngularUtils.Controller = function(T) {
		return function(module) {
			var type = T;
			// TODO
			// if(!type.IsSubClassOf(Scope)) throw new Exception("controller must be derived from Scope class");
			var fun = $AngularJS_TypeExtensionMethods.BuildControllerFunction(type, 0, null, false);
			var parameters = type.$inject;
			var fcall = $AngularJS_FunctionExtensionMethods.CreateFunctionCall(fun, parameters);
			module.controller(ss.getTypeName(type), fcall);
		};
	};
	$AngularJS_AngularUtils.Service = function(T) {
		return function(module) {
			var type = T;
			var parameters = angular.injector().annotate($AngularJS_TypeExtensionMethods.GetConstructorFunction(type));
			$AngularJS_FunctionExtensionMethods.CreateFunctionCall(type, parameters);
			// only used to fix the "_" to "$" in type.$inject
			var servicename = ss.getTypeName(T);
			module.service(servicename, type);
		};
	};
	$AngularJS_AngularUtils.Factory = function(T) {
		return function(module) {
			var type = T;
			// register all public instance methods as filters                       
			var $t1 = $AngularJS_TypeExtensionMethods.GetInstanceMethodNames(type);
			for (var $t2 = 0; $t2 < $t1.length; $t2++) {
				var funcname = $t1[$t2];
				$AngularJS_AngularUtils.$RegisterFactory(module, type, funcname);
			}
		};
	};
	$AngularJS_AngularUtils.$RegisterFactory = function(module, type, funcname) {
		var fun = $AngularJS_TypeExtensionMethods.BuildControllerFunction(type, 2, funcname, true);
		var parameters = type.$inject;
		var fcall = $AngularJS_FunctionExtensionMethods.CreateFunctionCall(fun, parameters);
		module.factory(funcname, fcall);
	};
	$AngularJS_AngularUtils.Filter = function(T) {
		return function(module) {
			var type = T;
			// register all public instance methods as filters                       
			var $t1 = $AngularJS_TypeExtensionMethods.GetInstanceMethodNames(type);
			for (var $t2 = 0; $t2 < $t1.length; $t2++) {
				var funcname = $t1[$t2];
				$AngularJS_AngularUtils.$RegisterFilter(module, type, funcname);
			}
		};
	};
	$AngularJS_AngularUtils.$RegisterFilter = function(module, type, funcname) {
		var fun = $AngularJS_TypeExtensionMethods.BuildControllerFunction(type, 3, funcname, false);
		var parameters = type.$inject;
		var fcall = $AngularJS_FunctionExtensionMethods.CreateFunctionCall(fun, parameters);
		module.filter(funcname, fcall);
	};
	$AngularJS_AngularUtils.Config = function(T) {
		return function(module) {
			var type = T;
			var fun = $AngularJS_TypeExtensionMethods.BuildControllerFunction(type, 3, null, false);
			var parameters = type.$inject;
			var fcall = $AngularJS_FunctionExtensionMethods.CreateFunctionCall(fun, parameters);
			module.config(fcall);
		};
	};
	$AngularJS_AngularUtils.Directive = function(T) {
		return function(module) {
			var type = T;
			// TODO when there will be IsSubClassOf
			//if(!type.IsSubclassOf(DirectiveDefinition)) throw new Exception(String.Format("{0} is not sub class of {1}",type.Name,typeof(DirectiveDefinition).Name);
			var dirob = ss.cast(ss.createInstance(type), $AngularJS_DirectiveDefinition);
			var fun = $AngularJS_AngularUtils.$CreateDirectiveFunction(dirob);
			var parameters = angular.injector().annotate(fun);
			var fcall = $AngularJS_FunctionExtensionMethods.CreateFunctionCall(fun, parameters);
			module.directive(dirob.Name, fcall);
		};
	};
	$AngularJS_AngularUtils.$CreateDirectiveFunction = function(def) {
		var defob = def.CreateDefinitionObject();
		var parameters = [];
		var fnames = [];
		var type = def.DirectiveController;
		var SharedController = defob.controller;
		if (ss.isValue(type)) {
			parameters = angular.injector().annotate($AngularJS_TypeExtensionMethods.GetConstructorFunction(type));
			fnames = $AngularJS_TypeExtensionMethods.GetInstanceMethodNames(type);
		}
		var body = '';
		body += 'var $obdef = ' + JSON.stringify(defob) + ';\r\n';
		if (ss.isValue(type) && ss.contains(fnames, 'Link')) {
			body += 'var $outer_arguments = arguments;\r\n';
			body += '$obdef.link = function(_scope) { \r\n';
			// save isolated scope bindings that would be overwritten by constructor initialization
			for (var $t1 = 0; $t1 < def.ScopeAttributes.length; $t1++) {
				var sb = def.ScopeAttributes[$t1];
				body += ss.formatString('var $$saved_{0} = _scope.{0};\r\n', sb.AttributeName);
			}
			for (var $t2 = 0; $t2 < fnames.length; $t2++) {
				var funcname = fnames[$t2];
				body += ss.formatString('   _scope.{1} = {0}.prototype.{1}.bind(_scope);\r\n', ss.getTypeFullName(type), funcname);
			}
			body += ss.formatString('   {0}.apply(_scope,$outer_arguments);\r\n', ss.getTypeFullName(type));
			// retrieves back saved isolated scope bindings
			for (var $t3 = 0; $t3 < def.ScopeAttributes.length; $t3++) {
				var sb1 = def.ScopeAttributes[$t3];
				body += ss.formatString('_scope.{0} = $$saved_{0};\r\n', sb1.AttributeName);
			}
			body += '   _scope.Link.apply(_scope,arguments);\r\n';
			body += '}\r\n';
		}
		if (ss.isValue(SharedController)) {
			body += '$obdef.controller = ' + SharedController.toString() + ';';
		}
		body += 'return $obdef;\r\n';
		return new Function(parameters, body);
	};
	$AngularJS_AngularUtils.Animation = function(T) {
		return function(module, name) {
			var type = T;
			// TODO when there will be IsSubClassOf
			//if(!type.IsSubclassOf(DirectiveDefinition)) throw new Exception(String.Format("{0} is not sub class of {1}",type.Name,typeof(DirectiveDefinition).Name);
			var fun = $AngularJS_AngularUtils.$CreateAnimationFunction(type);
			var parameters = angular.injector().annotate(fun);
			var fcall = $AngularJS_FunctionExtensionMethods.CreateFunctionCall(fun, parameters);
			module.animation((ss.isNullOrUndefined(name) ? ss.getTypeName(type) : name), fcall);
		};
	};
	$AngularJS_AngularUtils.$CreateAnimationFunction = function(type) {
		var body = '';
		var thisref = 'this';
		body += 'var $animob = {};\r\n';
		// gets and annotate constructor parameter; annotations are stored in type.$inject                                             
		var parameters = angular.injector().annotate($AngularJS_TypeExtensionMethods.GetConstructorFunction(type));
		// takes method into $scope, binding "$scope" to "this"                 
		var $t1 = $AngularJS_TypeExtensionMethods.GetInstanceMethodNames(type);
		for (var $t2 = 0; $t2 < $t1.length; $t2++) {
			var funcname = $t1[$t2];
			body += ss.formatString('{2}.{1} = {0}.prototype.{1}.bind({2});\r\n', ss.getTypeFullName(type), funcname, thisref);
			if (funcname === 'Start' || funcname === 'Setup' || funcname === 'Cancel') {
				body += ss.formatString('$animob.{0} = {2}.{1};\r\n', funcname.toLowerCase(), funcname, thisref);
			}
		}
		// put call at the end so that methods are defined first
		body += ss.formatString('{0}.apply({1},arguments);\r\n', ss.getTypeFullName(type), thisref);
		body += ss.formatString('return $animob;\r\n');
		return new Function(parameters, body);
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.BindingStrategies
	var $AngularJS_BindingStrategies = function() {
	};
	$AngularJS_BindingStrategies.prototype = { AsString: 0, AsProperty: 1, AsFunction: 2 };
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.DirectiveDefinition
	var $AngularJS_DirectiveDefinition = function() {
		this.Name = null;
		this.Restrict = 2;
		this.Priority = null;
		this.Template = null;
		this.TemplateUrl = null;
		this.Replace = false;
		this.Transclude = false;
		this.ScopeMode = 0;
		this.ScopeAttributes = [];
		this.Require = null;
		this.SharedController = null;
		this.DirectiveController = null;
	};
	$AngularJS_DirectiveDefinition.prototype = {
		$RestrictString: function() {
			var s = '';
			if ((this.Restrict & 1) === 1) {
				s += 'E';
			}
			if ((this.Restrict & 2) === 2) {
				s += 'A';
			}
			if ((this.Restrict & 4) === 4) {
				s += 'C';
			}
			if ((this.Restrict & 8) === 8) {
				s += 'M';
			}
			return s;
		},
		RequireDirective: function(ControllerName, LookParent, Optional) {
			var s = ControllerName;
			if (Optional) {
				s = '?' + s;
			}
			if (LookParent) {
				s = '^' + s;
			}
			return s;
		},
		CreateDefinitionObject: function() {
			var result = {};
			// maps name
			if (ss.isValue(this.Name)) {
				result['name'] = this.Name;
			}
			// maps priority
			if (ss.Nullable.ne(this.Priority, null)) {
				result['priority'] = this.Priority;
			}
			// maps restrict
			result['restrict'] = this.$RestrictString();
			// maps template and templateUrl
			if (ss.isValue(this.Template)) {
				result['template'] = this.Template;
			}
			else if (ss.isValue(this.TemplateUrl)) {
				result['templateUrl'] = this.TemplateUrl;
			}
			// maps replace
			result['replace'] = this.Replace;
			// maps transclude
			result['transclude'] = this.Transclude;
			// maps scope
			if (this.ScopeMode === 0) {
				result['scope'] = false;
			}
			else if (this.ScopeMode === 1) {
				result['scope'] = true;
			}
			else if (this.ScopeMode === 2) {
				var scope = {};
				for (var $t1 = 0; $t1 < this.ScopeAttributes.length; $t1++) {
					var sb = this.ScopeAttributes[$t1];
					scope[sb.AttributeName] = sb.ScopeBindingString();
				}
				result['scope'] = scope;
			}
			// maps compile function
			// maps (shared) controller         
			if (ss.isValue(this.SharedController)) {
				var scontr = $AngularJS_TypeExtensionMethods.BuildControllerFunction(this.SharedController, 2, null, false);
				result['controller'] = scontr;
			}
			// directive controller ('link' function) is managed during the registration process
			// maps require
			if (ss.isValue(this.Require)) {
				result['require'] = this.Require;
			}
			return result;
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.Event
	var $AngularJS_Event = function() {
		this.targetScope = null;
		this.currentScope = null;
		this.name = null;
		this.stopPropagation = null;
		this.preventDefault = null;
		this.defaultPrevented = false;
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.FunctionExtensionMethods
	var $AngularJS_FunctionExtensionMethods = function() {
	};
	$AngularJS_FunctionExtensionMethods.CreateFunctionCall = function(fun, parameters) {
		// if no parameters, takes function out of the array
		if (parameters.length === 0) {
			return fun;
		}
		// builds array, but also FIX $injection in the type
		var result = [];
		for (var t = 0; t < parameters.length; t++) {
			if (ss.startsWithString(parameters[t], '_')) {
				parameters[t] = '$' + parameters[t].substring(1);
			}
			ss.add(result, parameters[t]);
		}
		ss.add(result, fun);
		return result;
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.IResourceObject
	var $AngularJS_IResourceObject = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.ResourceObjectExtensions
	var $AngularJS_ResourceObjectExtensions = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.ResourceRequest
	var $AngularJS_ResourceRequest$1 = function(T) {
		var $type = function(resob) {
			this.resource = null;
			this.Action = null;
			this.Parameters = null;
			this.PostData = null;
			this.Success = null;
			this.Error = null;
			this.resource = resob;
		};
		$type.prototype = {
			ExecuteRequest: function() {
				return ss.getDefaultValue(T);
			},
			ExecuteRequestArray: function() {
				return null;
			}
		};
		ss.registerGenericClassInstance($type, $AngularJS_ResourceRequest$1, [T], function() {
			return null;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'AngularJS.ResourceRequest$1', $AngularJS_ResourceRequest$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.RestrictFlags
	var $AngularJS_RestrictFlags = function() {
	};
	$AngularJS_RestrictFlags.prototype = { Element: 1, Attribute: 2, Class: 4, Comment: 8 };
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.RouteParams
	var $AngularJS_RouteParams = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.Scope
	var $AngularJS_Scope = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.ScopeBindings
	var $AngularJS_ScopeBindings = function(AttributeName) {
		this.AttributeName = null;
		this.Strategy = 0;
		this.TemplateAttributeName = null;
		this.AttributeName = AttributeName;
		this.Strategy = 0;
	};
	$AngularJS_ScopeBindings.prototype = {
		ScopeBindingString: function() {
			var s = '';
			if (this.Strategy === 0) {
				s = '@';
			}
			else if (this.Strategy === 1) {
				s = '=';
			}
			else if (this.Strategy === 2) {
				s = '&';
			}
			if (ss.isValue(this.TemplateAttributeName)) {
				s += this.TemplateAttributeName;
			}
			return s;
		}
	};
	$AngularJS_ScopeBindings.$ctor1 = function(AttributeName, Strategy) {
		this.AttributeName = null;
		this.Strategy = 0;
		this.TemplateAttributeName = null;
		this.AttributeName = AttributeName;
		this.Strategy = Strategy;
	};
	$AngularJS_ScopeBindings.$ctor2 = function(AttributeAlias, Strategy, TemplateAttributeName) {
		this.AttributeName = null;
		this.Strategy = 0;
		this.TemplateAttributeName = null;
		this.AttributeName = AttributeAlias;
		this.Strategy = Strategy;
		this.TemplateAttributeName = TemplateAttributeName;
	};
	$AngularJS_ScopeBindings.$ctor1.prototype = $AngularJS_ScopeBindings.$ctor2.prototype = $AngularJS_ScopeBindings.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.ScopeModes
	var $AngularJS_ScopeModes = function() {
	};
	$AngularJS_ScopeModes.prototype = { Existing: 0, New: 1, Isolate: 2 };
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.ThisMode
	var $AngularJS_ThisMode = function() {
	};
	$AngularJS_ThisMode.prototype = { ScopeStrict: 0, Scope: 1, This: 2, NewObject: 3 };
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.TypeExtensionMethods
	var $AngularJS_TypeExtensionMethods = function() {
	};
	$AngularJS_TypeExtensionMethods.GetInstanceMethodNames = function(type) {
		var result = [];
		var $t1 = ss.getEnumerator(Object.keys(type.prototype));
		try {
			while ($t1.moveNext()) {
				var key = $t1.current();
				if (key !== 'constructor') {
					ss.add(result, key);
				}
			}
		}
		finally {
			$t1.dispose();
		}
		return result;
	};
	$AngularJS_TypeExtensionMethods.GetConstructorFunction = function(type) {
		return ss.cast(type.prototype['constructor'], Function);
	};
	$AngularJS_TypeExtensionMethods.BuildControllerFunction = function(type, this_mode, return_function, return_function_call) {
		var body = '';
		var thisref = '';
		if (this_mode === 3) {
			thisref = '$self';
		}
		else if (this_mode === 0) {
			thisref = '_scope';
		}
		else if (this_mode === 1) {
			thisref = '_scope';
		}
		else if (this_mode === 2) {
			thisref = 'this';
		}
		if (this_mode === 3) {
			body += 'var $self = new Object();';
		}
		// gets and annotate constructor parameter; annotations are stored in type.$inject                                             
		var parameters = angular.injector().annotate($AngularJS_TypeExtensionMethods.GetConstructorFunction(type));
		if (this_mode === 0) {
			// verifies that "scope" is the first parameter in constructor
			if (parameters.length < 1 || parameters[0] !== '_scope') {
				throw new ss.Exception(ss.formatString('Controller {0} must specify \'_scope\' as first parameter in its constructor', ss.getTypeName(type)));
			}
		}
		// takes method into $scope, binding "$scope" to "this"                 
		var $t1 = $AngularJS_TypeExtensionMethods.GetInstanceMethodNames(type);
		for (var $t2 = 0; $t2 < $t1.length; $t2++) {
			var funcname = $t1[$t2];
			body += ss.formatString('{2}.{1} = {0}.prototype.{1}.bind({2});\r\n', ss.getTypeFullName(type), funcname, thisref);
		}
		// put call at the end so that methods are defined first
		body += ss.formatString('{0}.apply({1},arguments);\r\n', ss.getTypeFullName(type), thisref);
		if (ss.isValue(return_function)) {
			if (return_function_call) {
				body += ss.formatString('return {1}.{0}();\r\n', return_function, thisref);
			}
			else {
				body += ss.formatString('return {1}.{0}  ;\r\n', return_function, thisref);
			}
			if (!ss.contains($AngularJS_TypeExtensionMethods.GetInstanceMethodNames(type), return_function)) {
				throw new ss.Exception('function \'' + return_function + '\' not defined in controller \'' + ss.getTypeName(type) + '\'');
			}
		}
		return new Function(parameters, body);
	};
	ss.registerClass(global, 'angular$BuiltinFilters', $angular$BuiltinFilters);
	ss.registerClass(global, 'AngularJS.AngularUtils', $AngularJS_AngularUtils);
	ss.registerEnum(global, 'AngularJS.BindingStrategies', $AngularJS_BindingStrategies);
	ss.registerClass(global, 'AngularJS.DirectiveDefinition', $AngularJS_DirectiveDefinition);
	ss.registerClass(global, 'AngularJS.Event', $AngularJS_Event);
	ss.registerClass(global, 'AngularJS.FunctionExtensionMethods', $AngularJS_FunctionExtensionMethods);
	ss.registerInterface(global, 'AngularJS.IResourceObject', $AngularJS_IResourceObject);
	ss.registerClass(global, 'AngularJS.ResourceObjectExtensions', $AngularJS_ResourceObjectExtensions);
	ss.registerEnum(global, 'AngularJS.RestrictFlags', $AngularJS_RestrictFlags, { enumFlags: true });
	ss.registerClass(global, 'AngularJS.RouteParams', $AngularJS_RouteParams);
	ss.registerClass(global, 'AngularJS.Scope', $AngularJS_Scope);
	ss.registerClass(global, 'AngularJS.ScopeBindings', $AngularJS_ScopeBindings);
	ss.registerEnum(global, 'AngularJS.ScopeModes', $AngularJS_ScopeModes);
	ss.registerEnum(global, 'AngularJS.ThisMode', $AngularJS_ThisMode);
	ss.registerClass(global, 'AngularJS.TypeExtensionMethods', $AngularJS_TypeExtensionMethods);
})();
