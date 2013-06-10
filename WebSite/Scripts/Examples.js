(function() {
	////////////////////////////////////////////////////////////////////////////////
	// AngularTests
	var $AngularTests = function() {
	};
	$AngularTests.prototype = {
		runTests: function() {
			test('OneIsOne', ss.mkdel(this, function() {
				deepEqual(1, 1, 'one is one');
				ok(true, 'one is still one');
				ok(!false, 'one is not two');
			}));
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// JasmineTests
	var $JasmineTests = function() {
		ss.shallowCopy(null, this);
	};
	$JasmineTests.prototype = {
		SpecRunner: function() {
			describe('Currency filter', ss.mkdel(this, function() {
				it('should format numbers to dollar amounts', ss.mkdel(this, function() {
					var f = angular.injector(['ng']).get('$filter')('currency');
					expect(f(0)).toBe('$0.00');
					expect(f(5.75)).toBe('$5.75');
					expect(f(1000000)).toBe('$1,000,000.00');
					expect(f(-5.75)).toBe('($5.75)');
					expect(f(5.753)).toBe('$5.75');
					expect(f(5.75, '€')).toBe('€5.75');
				}));
			}));
			describe('Date filter', ss.mkdel(this, function() {
				var f1 = angular.injector(['ng']).get('$filter')('date');
				var d = new Date(1972, 4, 3);
				it('should format dates to U.S. format', ss.mkdel(this, function() {
					expect(f1(d)).toBe('May 3, 1972');
				}));
				it('should format short dates', ss.mkdel(this, function() {
					expect(f1(d, 'dd/MM/yy')).toBe('03/05/72');
				}));
				it('should format long dates', ss.mkdel(this, function() {
					expect(f1(d, 'dd/MM/yyyy')).toBe('03/05/1972');
				}));
			}));
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.AccordionController
	var $TestAngularJS_AccordionController = function(Items) {
		this.ppp = null;
		this.Items = null;
		//Debug.Break();
		this.Items = Items;
	};
	$TestAngularJS_AccordionController.prototype = {
		Link: function(_scope, iElement, iAttrs, acontroller) {
			//Debug.Break();
			this.ppp = 'fissa';
		},
		clickme: function() {
			//Debug.Break();
			//Http h = Angular.InjectorRead("$http");
			// System.Diagnostics.Debug.Break();
			window.alert('clicked to ' + this.ppp);
			window.alert('Items[0] is ' + this.Items[0].title);
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.AccordionDefinition
	var $TestAngularJS_AccordionDefinition = function() {
		AngularJS.DirectiveDefinition.call(this);
		this.Name = 'accordion';
		this.Restrict = 3;
		this.Replace = true;
		this.Transclude = true;
		this.ScopeMode = 2;
		this.Template = '<div><div ng-click=\'clickme()\'>click me</div><div ng-transclude></div></div>';
		//Template = @"<div ng-transclude></div>";
		this.SharedController = $TestAngularJS_AccordionSharedController;
		this.DirectiveController = $TestAngularJS_AccordionController;
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.AccordionSharedController
	var $TestAngularJS_AccordionSharedController = function() {
		this.pppp = null;
		this.expanders = [];
		//System.Diagnostics.Debug.Break();
		window.alert('Shared controller initialized');
		this.pppp = 'constructor ok';
	};
	$TestAngularJS_AccordionSharedController.prototype = {
		gotOpened: function(selectedExpander) {
			//  Window.Alert("gotOpened called ["+pppp+"]");
			for (var $t1 = 0; $t1 < this.expanders.length; $t1++) {
				var o = this.expanders[$t1];
				if (!ss.referenceEquals(selectedExpander, o)) {
					o.showMe = false;
				}
			}
		},
		addExpander: function(expander) {
			//  Window.Alert("addExpander called ["+pppp+"]");
			ss.add(this.expanders, expander);
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.CartController
	var $TestAngularJS_CartController = function(_scope, Items) {
		this.items = null;
		this.billDiscount = 0;
		AngularJS.Scope.call(this);
		this.zeroitems();
		this.items = Items;
		this.$watch(ss.mkdel(this, this.totalCart), ss.mkdel(this, this.calculateDiscount));
	};
	$TestAngularJS_CartController.prototype = {
		zeroitems: function() {
			this.items = null;
		},
		remove: function(index) {
			ss.removeAt(this.items, index);
		},
		totalCart: function() {
			var total = 0;
			for (var i = 0; i < this.items.length; i++) {
				total = total + this.items[i].price * this.items[i].quantity;
			}
			return total;
		},
		subtotal: function() {
			return this.totalCart() - this.billDiscount;
		},
		calculateDiscount: function(newValue, oldValue) {
			this.billDiscount = ((newValue > 100) ? 10 : 0);
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.CartItem
	var $TestAngularJS_CartItem = function() {
		this.title = null;
		this.quantity = 0;
		this.price = 0;
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.DirectivesExample
	var $TestAngularJS_DirectivesExample = function() {
	};
	$TestAngularJS_DirectivesExample.Main = function() {
		var app = angular.module('myApp', []);
		//app.Debug("service","pippo");                  
		//app.RegisterController( typeof(TestController) );         
		//app.RegisterFactory( typeof(ItemsFactory) );
		//app.RegisterDirectiveAsFactory("testdirective",typeof(testdirective));
		AngularJS.AngularUtils.Factory($TestAngularJS_ItemsFactory).call(null, app);
		AngularJS.AngularUtils.Directive($TestAngularJS_AccordionDefinition).call(null, app);
		AngularJS.AngularUtils.Directive($TestAngularJS_ExpanderDefinition).call(null, app);
		AngularJS.AngularUtils.Directive($TestAngularJS_HelloDirective).call(null, app);
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.ExampleService
	var $TestAngularJS_ExampleService = function(Items, _http) {
		this.$Items = null;
		this.$Items = Items;
	};
	$TestAngularJS_ExampleService.prototype = {
		DoAlert: function() {
			window.alert(this.$Items[0].title);
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.ExpanderController
	var $TestAngularJS_ExpanderController = function() {
		this.title = null;
		this.showMe = false;
		this.accordionController = null;
	};
	$TestAngularJS_ExpanderController.prototype = {
		Link: function(_scope, iElement, iAttrs, acontroller) {
			this.accordionController = acontroller;
			this.showMe = false;
			this.accordionController.addExpander(this);
		},
		toggle: function() {
			this.showMe = !this.showMe;
			this.accordionController.gotOpened(this);
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.ExpanderDefinition
	var $TestAngularJS_ExpanderDefinition = function() {
		AngularJS.DirectiveDefinition.call(this);
		this.Name = 'expander';
		this.Restrict = 1;
		this.Replace = true;
		this.Transclude = true;
		this.Require = this.RequireDirective('accordion', true, false);
		this.ScopeMode = 2;
		ss.add(this.ScopeAttributes, new AngularJS.ScopeBindings.$ctor2('title', 0, 'expanderTitle'));
		this.Template = '<div>\r\n                         <div class=\'title\' ng-click=\'toggle()\'>{{title}}</div>\r\n                         <div class=\'body\' ng-show=\'showMe\' ng-transclude></div>\r\n                      </div>';
		this.DirectiveController = $TestAngularJS_ExpanderController;
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.Filters
	var $TestAngularJS_Filters = function(LabelEuro) {
		this.$le = null;
		this.$le = LabelEuro;
	};
	$TestAngularJS_Filters.prototype = {
		euro: function(input) {
			return input.toString() + ' euros (' + this.$le + ')';
		},
		dracma: function(input) {
			return input.toString() + ' dracmas ';
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.FundingExample
	var $TestAngularJS_FundingExample = function() {
	};
	$TestAngularJS_FundingExample.Main = function() {
		var app = angular.module('myApp', []);
		AngularJS.AngularUtils.Factory($TestAngularJS_ItemsFactory).call(null, app);
		AngularJS.AngularUtils.Service($TestAngularJS_ExampleService).call(null, app);
		AngularJS.AngularUtils.Controller($TestAngularJS_StartUpController).call(null, app);
		window.alert('\'' + ss.cast(eval('typeof new Date()'), String) + '\'');
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.HelloDirective
	var $TestAngularJS_HelloDirective = function() {
		AngularJS.DirectiveDefinition.call(this);
		this.Name = 'hello';
		this.Restrict = 7;
		this.Template = '<div>Hello <span ng-transclude></span>!</div>';
		this.Replace = true;
		this.Transclude = true;
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.ItemsFactory
	var $TestAngularJS_ItemsFactory = function() {
	};
	$TestAngularJS_ItemsFactory.prototype = {
		Items: function() {
			var items = [];
			var $t1 = new $TestAngularJS_CartItem();
			$t1.title = 'AaAa';
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
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.LabelsFactory
	var $TestAngularJS_LabelsFactory = function() {
	};
	$TestAngularJS_LabelsFactory.prototype = {
		LabelEuro: function() {
			return 'CHF';
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.Person
	var $TestAngularJS_Person = function() {
		this.id = 0;
		this.name = null;
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.PhoneConfig
	var $TestAngularJS_PhoneConfig = function(_routeProvider) {
		var $t1 = {};
		$t1.templateUrl = 'phonemain.html';
		var $t3 = _routeProvider.when('/phones', $t1);
		var $t2 = {};
		$t2.templateUrl = 'phonedetail.html';
		var $t5 = $t3.when('/phones/:phoneId', $t2);
		var $t4 = {};
		$t4.redirectTo = '/phones';
		$t5.otherwise($t4);
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.PhoneExample
	var $TestAngularJS_PhoneExample = function() {
	};
	$TestAngularJS_PhoneExample.Main = function() {
		var app = angular.module('myApp', []);
		AngularJS.AngularUtils.Config($TestAngularJS_PhoneConfig).call(null, app);
		AngularJS.AngularUtils.Controller($TestAngularJS_PhoneListController).call(null, app);
		AngularJS.AngularUtils.Controller($TestAngularJS_PhoneListControllerDetail).call(null, app);
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.PhoneListController
	var $TestAngularJS_PhoneListController = function(_scope, _http) {
		this.what = null;
		this.person = null;
		this.what = 'main';
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
		var risp = _http.get('data.json');
		risp.success(ss.mkdel(this, function(data, status, header) {
			this.person = data;
			window.alert(this.person['name'].toString());
		}));
		risp.error(function(data1, status1) {
			window.alert('errore!');
		});
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.PhoneListControllerDetail
	var $TestAngularJS_PhoneListControllerDetail = function(_scope, _routeParams) {
		this.what = null;
		this.phoneId = 0;
		this.what = 'detail';
		this.phoneId = _routeParams.phoneId;
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.PhoneRouteParams
	var $TestAngularJS_PhoneRouteParams = function() {
		this.phoneId = 0;
		AngularJS.RouteParams.call(this);
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.ResourceExample
	var $TestAngularJS_ResourceExample = function() {
	};
	$TestAngularJS_ResourceExample.Main = function() {
		var app = angular.module('myApp', ['ngResource']);
		AngularJS.AngularUtils.Controller($TestAngularJS_ResourceExampleController).call(null, app);
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.ResourceExampleController
	var $TestAngularJS_ResourceExampleController = function(_scope, _resource) {
		this.resource = null;
		this.all_is_ok = null;
		this.persona = null;
		this.myres = null;
		// save injectables
		this.resource = _resource;
		var parms = { userId: '@id' };
		var actions = {};
		actions['fetch'] = { method: 'GET', isArray: false };
		this.myres = this.resource('/api/person/:userId', null, actions);
		this.all_is_ok = 'OK!';
	};
	$TestAngularJS_ResourceExampleController.prototype = {
		prova: function() {
			//persona = myres.Get<Person>(new {userId=10}, succ, err);
			this.persona = this.myres.fetch({ userId: 10 }, ss.mkdel(this, this.succ), ss.mkdel(this, this.err));
			this.persona.$fetch();
		},
		getok: function() {
			debugger;
		},
		succ: function(p, rh) {
			window.alert(p.name);
		},
		err: function(rh) {
			window.alert(rh.status);
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.ShoppingCartExample
	var $TestAngularJS_ShoppingCartExample = function() {
	};
	$TestAngularJS_ShoppingCartExample.Main = function() {
		var app = angular.module('myApp', []);
		AngularJS.AngularUtils.Factory($TestAngularJS_ItemsFactory).call(null, app);
		AngularJS.AngularUtils.Factory($TestAngularJS_LabelsFactory).call(null, app);
		AngularJS.AngularUtils.Filter($TestAngularJS_Filters).call(null, app);
		AngularJS.AngularUtils.Controller($TestAngularJS_CartController).call(null, app);
	};
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.StartUpController
	var $TestAngularJS_StartUpController = function(_scope, ExampleService) {
		this.fundingStartingEstimate = 0;
		this.fundingNeeded = 0;
		AngularJS.Scope.call(this);
		this.fundingStartingEstimate = 0;
		this.$watch(ss.mkdel(this, function() {
			return this.fundingStartingEstimate;
		}), ss.mkdel(this, this.compneeded));
		ExampleService.DoAlert();
	};
	$TestAngularJS_StartUpController.prototype = {
		computeNeeded: function() {
			this.fundingNeeded = this.fundingStartingEstimate * 10;
		},
		requestFunding: function() {
			window.alert('Sorry, please get more customers first.');
		},
		reset: function() {
			this.fundingStartingEstimate = 0;
		},
		compneeded: function(newval, oldval) {
			this.fundingNeeded = this.fundingStartingEstimate * 10;
		}
	};
	ss.registerClass(global, 'AngularTests', $AngularTests);
	ss.registerClass(global, 'JasmineTests', $JasmineTests, Object);
	ss.registerClass(global, 'TestAngularJS.AccordionController', $TestAngularJS_AccordionController);
	ss.registerClass(global, 'TestAngularJS.AccordionDefinition', $TestAngularJS_AccordionDefinition, AngularJS.DirectiveDefinition);
	ss.registerClass(global, 'TestAngularJS.AccordionSharedController', $TestAngularJS_AccordionSharedController);
	ss.registerClass(global, 'TestAngularJS.CartController', $TestAngularJS_CartController, AngularJS.Scope);
	ss.registerClass(global, 'TestAngularJS.CartItem', $TestAngularJS_CartItem);
	ss.registerClass(global, 'TestAngularJS.DirectivesExample', $TestAngularJS_DirectivesExample);
	ss.registerClass(global, 'TestAngularJS.ExampleService', $TestAngularJS_ExampleService);
	ss.registerClass(global, 'TestAngularJS.ExpanderController', $TestAngularJS_ExpanderController);
	ss.registerClass(global, 'TestAngularJS.ExpanderDefinition', $TestAngularJS_ExpanderDefinition, AngularJS.DirectiveDefinition);
	ss.registerClass(global, 'TestAngularJS.Filters', $TestAngularJS_Filters);
	ss.registerClass(global, 'TestAngularJS.FundingExample', $TestAngularJS_FundingExample);
	ss.registerClass(global, 'TestAngularJS.HelloDirective', $TestAngularJS_HelloDirective, AngularJS.DirectiveDefinition);
	ss.registerClass(global, 'TestAngularJS.ItemsFactory', $TestAngularJS_ItemsFactory);
	ss.registerClass(global, 'TestAngularJS.LabelsFactory', $TestAngularJS_LabelsFactory);
	ss.registerClass(global, 'TestAngularJS.Person', $TestAngularJS_Person, null, [AngularJS.IResourceObject]);
	ss.registerClass(global, 'TestAngularJS.PhoneConfig', $TestAngularJS_PhoneConfig);
	ss.registerClass(global, 'TestAngularJS.PhoneExample', $TestAngularJS_PhoneExample);
	ss.registerClass(global, 'TestAngularJS.PhoneListController', $TestAngularJS_PhoneListController);
	ss.registerClass(global, 'TestAngularJS.PhoneListControllerDetail', $TestAngularJS_PhoneListControllerDetail);
	ss.registerClass(global, 'TestAngularJS.PhoneRouteParams', $TestAngularJS_PhoneRouteParams, AngularJS.RouteParams);
	ss.registerClass(global, 'TestAngularJS.ResourceExample', $TestAngularJS_ResourceExample);
	ss.registerClass(global, 'TestAngularJS.ResourceExampleController', $TestAngularJS_ResourceExampleController);
	ss.registerClass(global, 'TestAngularJS.ShoppingCartExample', $TestAngularJS_ShoppingCartExample);
	ss.registerClass(global, 'TestAngularJS.StartUpController', $TestAngularJS_StartUpController, AngularJS.Scope);
})();
