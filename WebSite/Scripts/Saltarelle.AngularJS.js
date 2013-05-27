(function() {
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.AngularUtils
	var $AngularJS_AngularUtils = function() {
	};
	$AngularJS_AngularUtils.$InjectionSyntax = function(module, mi, ct) {
		var miParameterNames = scanparms(ss.midel(mi));
		var NamedParameters = [];
		var services = $AngularJS_AngularUtils.Dict.get_item(module.name);
		for (var j = 0; j < mi.params.length; j++) {
			var t = mi.params[j];
			var found = false;
			for (var i = 0; i < services.length; i++) {
				if (ss.referenceEquals(t, services[i].type) || ss.isSubclassOf(t, services[i].type)) {
					if (ss.startsWithString(services[i].name, '$') || !ss.startsWithString(services[i].name, '$') && ss.referenceEquals(services[i].name, miParameterNames[j])) {
						ss.add(NamedParameters, services[i].name);
					}
					found = true;
					break;
				}
			}
			if (!found) {
				throw new ss.Exception('controller named parameter \'' + miParameterNames[j] + '\' of type \'' + t.toString() + '\' not recognized');
			}
		}
		var wr = [];
		for (var $t1 = 0; $t1 < NamedParameters.length; $t1++) {
			var s = NamedParameters[$t1];
			ss.add(wr, s);
		}
		var x = ss.midel(mi);
		ss.add(wr, x);
		return wr;
	};
	$AngularJS_AngularUtils.Register = function(module) {
		var serv = [];
		var $t1 = new $AngularJS_ServiceEntry();
		$t1.name = '$scope';
		$t1.type = $AngularJS_Scope;
		ss.add(serv, $t1);
		var $t2 = new $AngularJS_ServiceEntry();
		$t2.name = '$rootscope';
		$t2.type = $AngularJS_RootScope;
		ss.add(serv, $t2);
		var $t3 = new $AngularJS_ServiceEntry();
		$t3.name = '$http';
		$t3.type = $AngularJS_Http;
		ss.add(serv, $t3);
		var $t4 = new $AngularJS_ServiceEntry();
		$t4.name = '$location';
		$t4.type = $AngularJS_Location;
		ss.add(serv, $t4);
		var $t5 = new $AngularJS_ServiceEntry();
		$t5.name = '$routeProvider';
		$t5.type = $AngularJS_RouteProvider;
		ss.add(serv, $t5);
		var $t6 = new $AngularJS_ServiceEntry();
		$t6.name = '$routeParams';
		$t6.type = $AngularJS_RouteParams;
		ss.add(serv, $t6);
		$AngularJS_AngularUtils.Dict.add(module.name, serv);
	};
	$AngularJS_AngularUtils.RegisterControllers = function(module, controllers) {
		var ct = ss.getInstanceType(controllers);
		var bf = 24;
		var $t1 = ss.getMembers(ct, 8, bf);
		for (var $t2 = 0; $t2 < $t1.length; $t2++) {
			var mi = $t1[$t2];
			var wr = $AngularJS_AngularUtils.$InjectionSyntax(module, mi, ct);
			module.controller(mi.name, wr);
		}
	};
	$AngularJS_AngularUtils.RegisterFactory = function(module, factory) {
		var ft = ss.getInstanceType(factory);
		var bf = 24;
		var $t1 = ss.getMembers(ft, 8, bf);
		for (var $t2 = 0; $t2 < $t1.length; $t2++) {
			var mi = $t1[$t2];
			$AngularJS_AngularUtils.$RegisterSingleFactory(module, mi, ft);
		}
	};
	$AngularJS_AngularUtils.$RegisterSingleFactory = function(module, mi, ft) {
		var factoryname = mi.name;
		var returntype = mi.returnType;
		var services = $AngularJS_AngularUtils.Dict.get_item(module.name);
		var $t1 = new $AngularJS_ServiceEntry();
		$t1.name = factoryname;
		$t1.type = returntype;
		ss.add(services, $t1);
		var wr = $AngularJS_AngularUtils.$InjectionSyntax(module, mi, ft);
		module.factory(factoryname, wr);
	};
	$AngularJS_AngularUtils.RegisterFilters = function(module, filter) {
		var ft = ss.getInstanceType(filter);
		var bf = 24;
		var $t1 = ss.getMembers(ft, 8, bf);
		for (var $t2 = 0; $t2 < $t1.length; $t2++) {
			var mi = $t1[$t2];
			$AngularJS_AngularUtils.$RegisterFilter(module, mi, ft);
		}
	};
	$AngularJS_AngularUtils.$RegisterFilter = function(module, mi, ft) {
		var filtername = mi.name;
		var returntype = mi.returnType;
		//var wr = InjectionSyntax(module, mi, ft);
		// TODO: support injectable filters
		var wr = ss.midel(mi);
		module.filter(filtername, function() {
			var filter = wr;
			return filter;
		});
	};
	$AngularJS_AngularUtils.RegisterConfig = function(module, config) {
		var ct = ss.getInstanceType(config);
		var bf = 24;
		var $t1 = ss.getMembers(ct, 8, bf);
		for (var $t2 = 0; $t2 < $t1.length; $t2++) {
			var mi = $t1[$t2];
			var wr = $AngularJS_AngularUtils.$InjectionSyntax(module, mi, ct);
			module.config(wr);
		}
	};
	$AngularJS_AngularUtils.RegisterDirectives = function(module, directives) {
		var ct = ss.getInstanceType(directives);
		var bf = 24;
		var $t1 = ss.getMembers(ct, 8, bf);
		for (var $t2 = 0; $t2 < $t1.length; $t2++) {
			var mi = $t1[$t2];
			var wr = $AngularJS_AngularUtils.$InjectionSyntax(module, mi, ct);
			module.directive(mi.name, wr);
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.DirectiveDefinition
	var $AngularJS_DirectiveDefinition = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.Http
	var $AngularJS_Http = function() {
		this.defaults = null;
		this.pendingRequests = null;
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.HttpPromise
	var $AngularJS_HttpPromise = function() {
	};
	$AngularJS_HttpPromise.prototype = {
		then: function(success, error) {
			return this;
		},
		success: function(function1) {
			return this;
		},
		success: function(function1) {
			return this;
		},
		success: function(function1) {
			return this;
		},
		error: function(function1) {
			return this;
		},
		error: function(function1) {
			return this;
		},
		error: function(function1) {
			return this;
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.Location
	var $AngularJS_Location = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.Module
	var $AngularJS_Module = function(Name) {
		angular.module(Name, []);
		$AngularJS_AngularUtils.Register(this);
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.RootScope
	var $AngularJS_RootScope = function() {
		$AngularJS_Scope.call(this);
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.Route
	var $AngularJS_Route = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.RouteMap
	var $AngularJS_RouteMap = function() {
	};
	$AngularJS_RouteMap.createInstance = function() {
		return {};
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.RouteParams
	var $AngularJS_RouteParams = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.RouteProvider
	var $AngularJS_RouteProvider = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.RouteProviderExtension
	var $AngularJS_RouteProviderExtension = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.Scope
	var $AngularJS_Scope = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.ServiceEntry
	var $AngularJS_ServiceEntry = function() {
		this.name = null;
		this.type = null;
	};
	ss.registerClass(global, 'AngularJS.AngularUtils', $AngularJS_AngularUtils);
	ss.registerClass(global, 'AngularJS.DirectiveDefinition', $AngularJS_DirectiveDefinition);
	ss.registerClass(global, 'AngularJS.Http', $AngularJS_Http);
	ss.registerClass(global, 'AngularJS.HttpPromise', $AngularJS_HttpPromise);
	ss.registerClass(global, 'AngularJS.Location', $AngularJS_Location);
	ss.registerClass(global, 'AngularJS.Module', $AngularJS_Module);
	ss.registerClass(global, 'AngularJS.Scope', $AngularJS_Scope);
	ss.registerClass(global, 'AngularJS.RootScope', $AngularJS_RootScope, $AngularJS_Scope);
	ss.registerClass(global, 'AngularJS.Route', $AngularJS_Route);
	ss.registerClass(global, 'AngularJS.RouteMap', $AngularJS_RouteMap);
	ss.registerClass(global, 'AngularJS.RouteParams', $AngularJS_RouteParams);
	ss.registerClass(global, 'AngularJS.RouteProvider', $AngularJS_RouteProvider);
	ss.registerClass(global, 'AngularJS.RouteProviderExtension', $AngularJS_RouteProviderExtension);
	ss.registerClass(global, 'AngularJS.ServiceEntry', $AngularJS_ServiceEntry);
	$AngularJS_AngularUtils.Dict = new (ss.makeGenericType(ss.Dictionary$2, [String, Array]))();
})();
