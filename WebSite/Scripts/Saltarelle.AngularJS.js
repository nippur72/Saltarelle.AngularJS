(function() {
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.AngularControllers
	var $AngularJS_AngularControllers = function() {
	};
	$AngularJS_AngularControllers.RegisterControllers = function(App, contrs) {
		var ct = ss.getInstanceType(contrs);
		var bf = 24;
		var mis = ss.getMembers(ct, 8, bf);
		for (var $t1 = 0; $t1 < mis.length; $t1++) {
			var mi = mis[$t1];
			$AngularJS_AngularControllers.RegisterController(App, mi, ct);
		}
	};
	$AngularJS_AngularControllers.RegisterController = function(App, mi, ct) {
		var NamedParameters = [];
		for (var j = 0; j < mi.params.length; j++) {
			var t = mi.params[j];
			var found = false;
			for (var i = 0; i < $AngularJS_AngularControllers.$types.length; i++) {
				if (ss.referenceEquals(t, $AngularJS_AngularControllers.$types[i]) || ss.isSubclassOf(t, $AngularJS_AngularControllers.$types[i])) {
					ss.add(NamedParameters, $AngularJS_AngularControllers.$names[i]);
					found = true;
					break;
				}
			}
			if (!found) {
				throw new ss.Exception('controller named parameter[' + j.toString() + '] of type \'' + t.toString() + '\' not recognized');
			}
		}
		var wr = [];
		for (var $t1 = 0; $t1 < NamedParameters.length; $t1++) {
			var s = NamedParameters[$t1];
			ss.add(wr, s);
		}
		var x = ss.midel(mi);
		// wr.Add(ct.FullName+"."+mi.ScriptName);                          
		ss.add(wr, x);
		App.controller(mi.name, wr);
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.Http
	var $AngularJS_Http = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.IScope
	var $AngularJS_IScope = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.Location
	var $AngularJS_Location = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.RootScope
	var $AngularJS_RootScope = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// AngularJS.Scope
	var $AngularJS_Scope = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.CartModel
	var $TestAngularJS_CartModel = function() {
		this.items = null;
		this.remove = null;
		this.totalCart = null;
		this.subtotal = null;
		this.billDiscount = 0;
		$AngularJS_Scope.call(this);
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.CartModel.CartItem
	var $TestAngularJS_CartModel$CartItem = function() {
		this.title = null;
		this.quantity = 0;
		this.price = 0;
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.Controllers
	var $TestAngularJS_Controllers = function() {
		$AngularJS_AngularControllers.call(this);
	};
	$TestAngularJS_Controllers.HelloController = function(scope) {
		scope.greetings = 'Douglas Adams';
	};
	$TestAngularJS_Controllers.CartController = function(scope) {
		scope.items = [];
		var $t2 = scope.items;
		var $t1 = new $TestAngularJS_CartModel$CartItem();
		$t1.title = 'Paint pots';
		$t1.quantity = 8;
		$t1.price = 3.95;
		ss.add($t2, $t1);
		var $t4 = scope.items;
		var $t3 = new $TestAngularJS_CartModel$CartItem();
		$t3.title = 'Polka dots';
		$t3.quantity = 17;
		$t3.price = 12.95;
		ss.add($t4, $t3);
		var $t6 = scope.items;
		var $t5 = new $TestAngularJS_CartModel$CartItem();
		$t5.title = 'Pebbles';
		$t5.quantity = 5;
		$t5.price = 6.95;
		ss.add($t6, $t5);
		scope.remove = function(index) {
			ss.removeAt(scope.items, index);
		};
		scope.totalCart = function() {
			var total = 0;
			for (var i = 0; i < scope.items.length; i++) {
				total = total + scope.items[i].price * scope.items[i].quantity;
			}
			return total;
		};
		scope.subtotal = function() {
			return ss.Nullable.unbox(ss.cast(scope.totalCart(), Number)) - scope.billDiscount;
		};
		var calculateDiscount = function(newValue, oldValue) {
			scope.billDiscount = ((ss.Nullable.unbox(ss.cast(newValue, Number)) > 100) ? 10 : 0);
		};
		scope.$watch(scope.totalCart, calculateDiscount);
	};
	$TestAngularJS_Controllers.StartUpController = function(scope) {
		scope.fundingStartingEstimate = 0;
		scope.computeNeeded = function() {
			scope.fundingNeeded = scope.fundingStartingEstimate * 10;
		};
		scope.requestFunding = function() {
			window.alert('Sorry, please get more customers first.');
		};
		scope.reset = function() {
			scope.fundingStartingEstimate = 0;
		};
		var compneeded = function(newval, oldval) {
			scope.fundingNeeded = scope.fundingStartingEstimate * 10;
		};
		scope.$watch('fundingStartingEstimate', compneeded);
		var pippo = function(sc) {
			return 33;
		};
		scope.$watch($TestAngularJS_FundingModel.check, compneeded);
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.FundingModel
	var $TestAngularJS_FundingModel = function() {
		this.fundingStartingEstimate = 0;
		this.fundingNeeded = 0;
		this.computeNeeded = null;
		this.requestFunding = null;
		this.reset = null;
		$AngularJS_Scope.call(this);
	};
	$TestAngularJS_FundingModel.check = function() {
		return 6;
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.HelloModel
	var $TestAngularJS_HelloModel = function() {
		this.greetings = null;
		$AngularJS_Scope.call(this);
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.TestApplication
	var $TestAngularJS_TestApplication = function() {
	};
	$TestAngularJS_TestApplication.Main = function() {
		var app = angular.module('myApp', []);
		$AngularJS_AngularControllers.RegisterControllers(app, new $TestAngularJS_Controllers());
	};
	ss.registerClass(global, 'AngularJS.AngularControllers', $AngularJS_AngularControllers);
	ss.registerClass(global, 'AngularJS.Http', $AngularJS_Http);
	ss.registerInterface(global, 'AngularJS.IScope', $AngularJS_IScope);
	ss.registerClass(global, 'AngularJS.Location', $AngularJS_Location);
	ss.registerClass(global, 'AngularJS.RootScope', $AngularJS_RootScope);
	ss.registerClass(global, 'AngularJS.Scope', $AngularJS_Scope, null, [$AngularJS_IScope]);
	ss.registerClass(global, 'TestAngularJS.CartModel', $TestAngularJS_CartModel, $AngularJS_Scope, [$AngularJS_IScope]);
	ss.registerClass(global, 'TestAngularJS.CartModel$CartItem', $TestAngularJS_CartModel$CartItem);
	ss.registerClass(global, 'TestAngularJS.Controllers', $TestAngularJS_Controllers, $AngularJS_AngularControllers, [], { members: [{ name: 'CartController', isStatic: true, type: 8, sname: 'CartController', returnType: Object, params: [$TestAngularJS_CartModel] }, { name: 'HelloController', isStatic: true, type: 8, sname: 'HelloController', returnType: Object, params: [$TestAngularJS_HelloModel] }, { name: 'StartUpController', isStatic: true, type: 8, sname: 'StartUpController', returnType: Object, params: [$TestAngularJS_FundingModel] }] });
	ss.registerClass(global, 'TestAngularJS.FundingModel', $TestAngularJS_FundingModel, $AngularJS_Scope, [$AngularJS_IScope]);
	ss.registerClass(global, 'TestAngularJS.HelloModel', $TestAngularJS_HelloModel, $AngularJS_Scope, [$AngularJS_IScope]);
	ss.registerClass(global, 'TestAngularJS.TestApplication', $TestAngularJS_TestApplication);
	$AngularJS_AngularControllers.$names = ['$scope', '$rootscope', '$http', '$location'];
	$AngularJS_AngularControllers.$types = [$AngularJS_Scope, $AngularJS_RootScope, $AngularJS_Http, $AngularJS_Location];
})();
