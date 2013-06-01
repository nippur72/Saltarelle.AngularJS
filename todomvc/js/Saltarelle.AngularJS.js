(function() {
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.AngularUtils
	var $AngularJS_AngularUtils = function() {
	};
	$AngularJS_AngularUtils.BuildFunction = function(type, this_is_scope, return_function) {
		var thisref = (this_is_scope ? '$scope' : 'this');
		var body = '';
		var consutructor = $AngularJS_TypeExtensionMethods.GetConstructorFunction(type);
		var parameters = angular.injector().annotate(consutructor);
		// verifies that "scope" is the first parameter in constructor
		if (this_is_scope) {
			if (parameters.length < 1 || parameters[0] !== '_scope') {
				throw new ss.Exception(ss.formatString('Controller {0} must specify \'_scope\' as first parameter', ss.getTypeName(type)));
			}
		}
		// takes method into $scope, binding "$scope" to "this"                 
		var $t1 = $AngularJS_TypeExtensionMethods.GetPublicInstanceMethodNames(type);
		for (var $t2 = 0; $t2 < $t1.length; $t2++) {
			var funcname = $t1[$t2];
			body += ss.formatString('{2}.{1} = {0}.prototype.{1}.bind({2});\r\n', ss.getTypeFullName(type), funcname, thisref);
		}
		// put call at the end so that methods are defined first
		body += ss.formatString('{0}.apply({1},arguments);\r\n', ss.getTypeFullName(type), thisref);
		if (ss.isValue(return_function)) {
			body += ss.formatString('return {1}.{0};\r\n', return_function, thisref);
			if (!ss.contains($AngularJS_TypeExtensionMethods.GetPublicInstanceMethodNames(type), return_function)) {
				throw new ss.Exception('function \'' + return_function + '\' not defined');
			}
		}
		// build controller function         
		if (this_is_scope) {
			return new Function('$scope', body);
		}
		else {
			return new Function(body);
		}
	};
	$AngularJS_AngularUtils.RegisterController = function(module, type) {
		// TODO
		// if(!type.IsSubClassOf(Scope)) throw new Exception("controller must be derived from Scope class");
		//Function cfun = AngularUtils.CreateControllerFromType(type);         
		var cfun = $AngularJS_AngularUtils.BuildFunction(type, true, null);
		// reads $inject previously added by CreateControllerFromType
		var inject = type.$inject;
		var inarr = $AngularJS_AngularUtils.$CreateInjectionArray(inject, cfun);
		module.controller(ss.getTypeName(type), inarr);
	};
	$AngularJS_AngularUtils.$CreateInjectionArray = function(parameters, fun) {
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
	$AngularJS_AngularUtils.RegisterFactory = function(module, type) {
		// scan class static methods (contained in Object.keys)
		var keys = Object.keys(type);
		for (var $t1 = 0; $t1 < keys.length; $t1++) {
			var funcname = keys[$t1];
			// skips reserved and private methods
			if (!ss.startsWithString(funcname, '__') && !ss.startsWithString(funcname, '$')) {
				var fun = type[funcname];
				// make sure it's a function
				if (ss.referenceEquals(ss.getInstanceType(fun), Function)) {
					var parameters = angular.injector().annotate(fun);
					var injarr = $AngularJS_AngularUtils.$CreateInjectionArray(parameters, fun);
					module.factory(funcname, injarr);
				}
			}
		}
	};
	$AngularJS_AngularUtils.RegisterFilter = function(module, type) {
		// annotates constructor
		var constructor = $AngularJS_TypeExtensionMethods.GetConstructorFunction(type);
		var parameters = angular.injector().annotate(constructor);
		// register all public instance methods as filters                       
		var $t1 = $AngularJS_TypeExtensionMethods.GetPublicInstanceMethodNames(type);
		for (var $t2 = 0; $t2 < $t1.length; $t2++) {
			var funcname = $t1[$t2];
			$AngularJS_AngularUtils.$RegisterFilter(module, type, funcname);
		}
	};
	$AngularJS_AngularUtils.$RegisterFilter = function(module, type, funcname) {
		var cfun = $AngularJS_AngularUtils.BuildFunction(type, false, funcname);
		var inject = type.$inject;
		var inarr = $AngularJS_AngularUtils.$CreateInjectionArray(inject, cfun);
		module.filter(funcname, inarr);
	};
	$AngularJS_AngularUtils.RegisterConfig = function(module, type) {
		var cfun = $AngularJS_AngularUtils.BuildFunction(type, false, null);
		var inject = type.$inject;
		var inarr = $AngularJS_AngularUtils.$CreateInjectionArray(inject, cfun);
		module.config(inarr);
	};
	$AngularJS_AngularUtils.DirectiveController = function(type) {
		var cfun = $AngularJS_AngularUtils.BuildFunction(type, false, null);
		var inject = type.$inject;
		if (inject.length === 0) {
			return cfun;
		}
		return $AngularJS_AngularUtils.$CreateInjectionArray(inject, cfun);
	};
	$AngularJS_AngularUtils.RegisterDirective = function(module, dirob) {
		var defob = dirob.CreateDefinitionObject();
		module.directive(dirob.Name, function() {
			return defob;
		});
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
		this.Restrict = 1;
		this.Priority = null;
		this.Template = null;
		this.TemplateUrl = null;
		this.Replace = false;
		this.Transclude = false;
		this.ScopeMode = 0;
		this.ScopeAttributes = [];
		this.Require = null;
		this.Compile = null;
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
				var contr = $AngularJS_AngularUtils.DirectiveController(this.SharedController);
				result['controller'] = contr;
			}
			// maps link function
			if (ss.isValue(this.DirectiveController)) {
				var contr1 = $AngularJS_AngularUtils.BuildFunction(this.DirectiveController, false, 'Link');
				result['link'] = contr1;
			}
			// maps require
			if (ss.isValue(this.Require)) {
				result['require'] = this.Require;
			}
			return result;
		}
	};
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
	// AngularJS.TypeExtensionMethods
	var $AngularJS_TypeExtensionMethods = function() {
	};
	$AngularJS_TypeExtensionMethods.GetPublicInstanceMethodNames = function(type) {
		var result = [];
		var $t1 = ss.getEnumerator(Object.keys(type.prototype));
		try {
			while ($t1.moveNext()) {
				var key = $t1.current();
				if (key !== 'constructor' && !ss.startsWithString(key, '$')) {
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
	ss.registerClass(global, 'AngularJS.AngularUtils', $AngularJS_AngularUtils);
	ss.registerEnum(global, 'AngularJS.BindingStrategies', $AngularJS_BindingStrategies);
	ss.registerClass(global, 'AngularJS.DirectiveDefinition', $AngularJS_DirectiveDefinition);
	ss.registerEnum(global, 'AngularJS.RestrictFlags', $AngularJS_RestrictFlags, { enumFlags: true });
	ss.registerClass(global, 'AngularJS.RouteParams', $AngularJS_RouteParams);
	ss.registerClass(global, 'AngularJS.Scope', $AngularJS_Scope);
	ss.registerClass(global, 'AngularJS.ScopeBindings', $AngularJS_ScopeBindings);
	ss.registerEnum(global, 'AngularJS.ScopeModes', $AngularJS_ScopeModes);
	ss.registerClass(global, 'AngularJS.TypeExtensionMethods', $AngularJS_TypeExtensionMethods);
})();
