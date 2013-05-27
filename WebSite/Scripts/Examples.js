(function() {
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.CartControllers
	var $TestAngularJS_CartControllers = function() {
	};
	$TestAngularJS_CartControllers.CartController = function(scope, Items) {
		scope.items = Items;
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
			return scope.totalCart() - scope.billDiscount;
		};
		var calculateDiscount = function(newValue, oldValue) {
			scope.billDiscount = ((newValue > 100) ? 10 : 0);
		};
		scope.$watch(scope.totalCart, calculateDiscount);
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.CartFactory
	var $TestAngularJS_CartFactory = function() {
	};
	$TestAngularJS_CartFactory.Items = function() {
		var items = [];
		var $t1 = new $TestAngularJS_CartItem();
		$t1.title = 'AAAA';
		$t1.quantity = 1024;
		$t1.price = 44.95;
		ss.add(items, $t1);
		var $t2 = new $TestAngularJS_CartItem();
		$t2.title = 'BBBB';
		$t2.quantity = 2048;
		$t2.price = 55.95;
		ss.add(items, $t2);
		var $t3 = new $TestAngularJS_CartItem();
		$t3.title = 'CCCC';
		$t3.quantity = 4096;
		$t3.price = 66.95;
		ss.add(items, $t3);
		var $t4 = new $TestAngularJS_CartItem();
		$t4.title = 'dddd';
		$t4.quantity = 1024;
		$t4.price = 44.95;
		ss.add(items, $t4);
		var $t5 = new $TestAngularJS_CartItem();
		$t5.title = 'eeee';
		$t5.quantity = 2048;
		$t5.price = 55.95;
		ss.add(items, $t5);
		var $t6 = new $TestAngularJS_CartItem();
		$t6.title = 'ffff';
		$t6.quantity = 4096;
		$t6.price = 66.95;
		ss.add(items, $t6);
		return items;
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.CartFilters
	var $TestAngularJS_CartFilters = function() {
	};
	$TestAngularJS_CartFilters.euro = function(input) {
		return input.toString() + ' euros';
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.CartItem
	var $TestAngularJS_CartItem = function() {
		this.title = null;
		this.quantity = 0;
		this.price = 0;
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.CartModel
	var $TestAngularJS_CartModel = function() {
		this.items = null;
		this.remove = null;
		this.totalCart = null;
		this.subtotal = null;
		this.billDiscount = 0;
		AngularJS.Scope.call(this);
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.FundingControllers
	var $TestAngularJS_FundingControllers = function() {
	};
	$TestAngularJS_FundingControllers.StartUpController = function(scope) {
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
		scope.$watch(function() {
			return scope.fundingStartingEstimate;
		}, compneeded);
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.FundingModel
	var $TestAngularJS_FundingModel = function() {
		this.fundingStartingEstimate = 0;
		this.fundingNeeded = 0;
		this.computeNeeded = null;
		this.requestFunding = null;
		this.reset = null;
		AngularJS.Scope.call(this);
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.HelloControllers
	var $TestAngularJS_HelloControllers = function() {
	};
	$TestAngularJS_HelloControllers.HelloController = function(scope) {
		scope.greetings = 'Douglas Adams';
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.HelloModel
	var $TestAngularJS_HelloModel = function() {
		this.greetings = null;
		AngularJS.Scope.call(this);
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.PhoneConfig
	var $TestAngularJS_PhoneConfig = function() {
	};
	$TestAngularJS_PhoneConfig.InitRoute = function(routeProvider) {
		var $t1 = {};
		$t1.templateUrl = 'phonemain.html';
		var $t3 = routeProvider.when('/phones', $t1);
		var $t2 = {};
		$t2.templateUrl = 'phonedetail.html';
		var $t5 = $t3.when('/phones/:phoneId', $t2);
		var $t4 = {};
		$t4.redirectTo = '/phones';
		$t5.otherwise($t4);
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.PhoneController
	var $TestAngularJS_PhoneController = function() {
	};
	$TestAngularJS_PhoneController.PhoneListController = function(scope, http) {
		scope.what = 'main';
		//
		//         http.Get("hello.html").Success((data,status)=> {
		//
		//         Window.Alert(data.ToString());
		//
		//         }).Error((data,status)=>{
		//
		//         Window.Alert("errore!");
		//
		//         });
		var risp = http.get('data.json');
		risp.success(function(data, status, header) {
			scope.person = data;
			window.alert(scope.person['name'].toString());
		});
		risp.error(function(data1, status1) {
			window.alert('errore!');
		});
	};
	$TestAngularJS_PhoneController.PhoneListControllerDetail = function(scope, routeParams) {
		scope.what = 'detail';
		scope.phoneId = routeParams.phoneId;
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.PhoneRouteParams
	var $TestAngularJS_PhoneRouteParams = function() {
		this.phoneId = 0;
		AngularJS.RouteParams.call(this);
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.PhoneScope
	var $TestAngularJS_PhoneScope = function() {
		this.what = null;
		this.phoneId = 0;
		this.person = null;
		AngularJS.Scope.call(this);
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.TestApplication
	var $TestAngularJS_TestApplication = function() {
	};
	$TestAngularJS_TestApplication.Main = function() {
		var app = new AngularJS.Module('myApp');
		AngularJS.AngularUtils.RegisterConfig(app, new $TestAngularJS_PhoneConfig());
		AngularJS.AngularUtils.RegisterControllers(app, new $TestAngularJS_PhoneController());
		//
		//         app.RegisterFactory(new CartFactory());
		//
		//         app.RegisterFilters(new CartFilters());
		//
		//         app.RegisterControllers(new CartControllers());
		//AngularControllers.RegisterControllers(app, new FundingControllers());                  
		//AngularControllers.RegisterControllers(app, new HelloControllers());         
	};
	ss.registerClass(global, 'TestAngularJS.CartControllers', $TestAngularJS_CartControllers, null, [], { members: [{ name: 'CartController', isStatic: true, type: 8, sname: 'CartController', returnType: Object, params: [$TestAngularJS_CartModel, Array] }] });
	ss.registerClass(global, 'TestAngularJS.CartFactory', $TestAngularJS_CartFactory, null, [], { members: [{ name: 'Items', isStatic: true, type: 8, sname: 'Items', returnType: Array, params: [] }] });
	ss.registerClass(global, 'TestAngularJS.CartFilters', $TestAngularJS_CartFilters, null, [], { members: [{ name: 'euro', isStatic: true, type: 8, sname: 'euro', returnType: String, params: [Number] }] });
	ss.registerClass(global, 'TestAngularJS.CartItem', $TestAngularJS_CartItem);
	ss.registerClass(global, 'TestAngularJS.CartModel', $TestAngularJS_CartModel, AngularJS.Scope);
	ss.registerClass(global, 'TestAngularJS.FundingControllers', $TestAngularJS_FundingControllers, null, [], { members: [{ name: 'StartUpController', isStatic: true, type: 8, sname: 'StartUpController', returnType: Object, params: [$TestAngularJS_FundingModel] }] });
	ss.registerClass(global, 'TestAngularJS.FundingModel', $TestAngularJS_FundingModel, AngularJS.Scope);
	ss.registerClass(global, 'TestAngularJS.HelloControllers', $TestAngularJS_HelloControllers, null, [], { members: [{ name: 'HelloController', isStatic: true, type: 8, sname: 'HelloController', returnType: Object, params: [$TestAngularJS_HelloModel] }] });
	ss.registerClass(global, 'TestAngularJS.HelloModel', $TestAngularJS_HelloModel, AngularJS.Scope);
	ss.registerClass(global, 'TestAngularJS.PhoneConfig', $TestAngularJS_PhoneConfig, null, [], { members: [{ name: 'InitRoute', isStatic: true, type: 8, sname: 'InitRoute', returnType: Object, params: [AngularJS.RouteProvider] }] });
	ss.registerClass(global, 'TestAngularJS.PhoneController', $TestAngularJS_PhoneController, null, [], { members: [{ name: 'PhoneListController', isStatic: true, type: 8, sname: 'PhoneListController', returnType: Object, params: [$TestAngularJS_PhoneScope, AngularJS.Http] }, { name: 'PhoneListControllerDetail', isStatic: true, type: 8, sname: 'PhoneListControllerDetail', returnType: Object, params: [$TestAngularJS_PhoneScope, $TestAngularJS_PhoneRouteParams] }] });
	ss.registerClass(global, 'TestAngularJS.PhoneRouteParams', $TestAngularJS_PhoneRouteParams, AngularJS.RouteParams);
	ss.registerClass(global, 'TestAngularJS.PhoneScope', $TestAngularJS_PhoneScope, AngularJS.Scope);
	ss.registerClass(global, 'TestAngularJS.TestApplication', $TestAngularJS_TestApplication);
})();
