(function() {
	'use strict';
	var $asm = {};
	global.Test = global.Test || {};
	global.TestAngularJS = global.TestAngularJS || {};
	ss.initAssembly($asm, 'Examples');
	////////////////////////////////////////////////////////////////////////////////
	// AngularTests
	var $AngularTests = function() {
	};
	$AngularTests.__typeName = 'AngularTests';
	global.AngularTests = $AngularTests;
	////////////////////////////////////////////////////////////////////////////////
	// JasmineTests
	var $JasmineTests = function() {
		ss.shallowCopy(null, this);
	};
	$JasmineTests.__typeName = 'JasmineTests';
	global.JasmineTests = $JasmineTests;
	////////////////////////////////////////////////////////////////////////////////
	// Test.BaseClass
	var $Test_BaseClass = function() {
		this.$type = 0;
		this.$type = 0;
	};
	$Test_BaseClass.__typeName = 'Test.BaseClass';
	global.Test.BaseClass = $Test_BaseClass;
	////////////////////////////////////////////////////////////////////////////////
	// Test.EnumType
	var $Test_EnumType = function() {
	};
	$Test_EnumType.__typeName = 'Test.EnumType';
	global.Test.EnumType = $Test_EnumType;
	////////////////////////////////////////////////////////////////////////////////
	// Test.SubClass
	var $Test_SubClass = function() {
		$Test_BaseClass.call(this);
		$Test_BaseClass.prototype.get_Type.call(this).toString();
		$Test_BaseClass.prototype.set_Type.call(this, 0);
	};
	$Test_SubClass.__typeName = 'Test.SubClass';
	global.Test.SubClass = $Test_SubClass;
	////////////////////////////////////////////////////////////////////////////////
	// Test.SubClass2
	var $Test_SubClass2 = function() {
		this.$subType = 0;
		$Test_BaseClass.call(this);
	};
	$Test_SubClass2.__typeName = 'Test.SubClass2';
	global.Test.SubClass2 = $Test_SubClass2;
	////////////////////////////////////////////////////////////////////////////////
	// Test.TestMain
	var $Test_TestMain = function() {
	};
	$Test_TestMain.__typeName = 'Test.TestMain';
	$Test_TestMain.Main = function() {
		new $Test_SubClass();
		(new $Test_SubClass2()).set_Type(0);
	};
	global.Test.TestMain = $Test_TestMain;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.AccordionController
	var $TestAngularJS_AccordionController = function(Items) {
		this.ppp = null;
		this.Items = null;
		//Debug.Break();
		this.Items = Items;
	};
	$TestAngularJS_AccordionController.__typeName = 'TestAngularJS.AccordionController';
	global.TestAngularJS.AccordionController = $TestAngularJS_AccordionController;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.AccordionDefinition
	var $TestAngularJS_AccordionDefinition = function() {
		AngularJS.DirectiveDefinition.call(this);
		this.Name = 'accordion';
		this.Restrict = 3;
		this.Replace = true;
		this.Transclude = true;
		this.ScopeMode = 2;
		this.Template = "<div><div ng-click='clickme()'>click me</div><div ng-transclude></div></div>";
		//Template = @"<div ng-transclude></div>";
		this.SharedController = $TestAngularJS_AccordionSharedController;
		this.DirectiveController = $TestAngularJS_AccordionController;
	};
	$TestAngularJS_AccordionDefinition.__typeName = 'TestAngularJS.AccordionDefinition';
	global.TestAngularJS.AccordionDefinition = $TestAngularJS_AccordionDefinition;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.AccordionSharedController
	var $TestAngularJS_AccordionSharedController = function() {
		this.pppp = null;
		this.expanders = [];
		//System.Diagnostics.Debug.Break();
		window.alert('Shared controller initialized');
		this.pppp = 'constructor ok';
	};
	$TestAngularJS_AccordionSharedController.__typeName = 'TestAngularJS.AccordionSharedController';
	global.TestAngularJS.AccordionSharedController = $TestAngularJS_AccordionSharedController;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.AnimationController
	var $TestAngularJS_AnimationController = function(_scope) {
		this.show_block = true;
		this.names = null;
		this.names = [];
		ss.add(this.names, 'pippo');
		ss.add(this.names, 'pluto');
		ss.add(this.names, angular.uppercase(angular.injector(['ng']).get('$filter')('json')(angular.version)));
	};
	$TestAngularJS_AnimationController.__typeName = 'TestAngularJS.AnimationController';
	global.TestAngularJS.AnimationController = $TestAngularJS_AnimationController;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.AnimationExample
	var $TestAngularJS_AnimationExample = function() {
	};
	$TestAngularJS_AnimationExample.__typeName = 'TestAngularJS.AnimationExample';
	$TestAngularJS_AnimationExample.Main = function() {
		var app = angular.module('myApp', []);
		AngularJS.AngularBuilder.Animation($TestAngularJS_CoolAnimation).call(null, app, 'cool-animation-show');
		AngularJS.AngularBuilder.Controller($TestAngularJS_AnimationController).call(null, app);
	};
	global.TestAngularJS.AnimationExample = $TestAngularJS_AnimationExample;
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
	$TestAngularJS_CartController.__typeName = 'TestAngularJS.CartController';
	global.TestAngularJS.CartController = $TestAngularJS_CartController;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.CartItem
	var $TestAngularJS_CartItem = function() {
		this.title = null;
		this.quantity = 0;
		this.price = 0;
	};
	$TestAngularJS_CartItem.__typeName = 'TestAngularJS.CartItem';
	global.TestAngularJS.CartItem = $TestAngularJS_CartItem;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.CoolAnimation
	var $TestAngularJS_CoolAnimation = function(_rootScope) {
		//System.Diagnostics.Debug.Break();
	};
	$TestAngularJS_CoolAnimation.__typeName = 'TestAngularJS.CoolAnimation';
	global.TestAngularJS.CoolAnimation = $TestAngularJS_CoolAnimation;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.DirectivesExample
	var $TestAngularJS_DirectivesExample = function() {
	};
	$TestAngularJS_DirectivesExample.__typeName = 'TestAngularJS.DirectivesExample';
	$TestAngularJS_DirectivesExample.Main = function() {
		var app = angular.module('myApp', []);
		//app.Debug("service","pippo");                  
		//app.RegisterController( typeof(TestController) );         
		//app.RegisterFactory( typeof(ItemsFactory) );
		//app.RegisterDirectiveAsFactory("testdirective",typeof(testdirective));
		AngularJS.AngularBuilder.Factory($TestAngularJS_ItemsFactory).call(null, app);
		AngularJS.AngularBuilder.Directive($TestAngularJS_AccordionDefinition).call(null, app);
		AngularJS.AngularBuilder.Directive($TestAngularJS_ExpanderDefinition).call(null, app);
		AngularJS.AngularBuilder.Directive($TestAngularJS_HelloDirective).call(null, app);
	};
	global.TestAngularJS.DirectivesExample = $TestAngularJS_DirectivesExample;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.ExampleService
	var $TestAngularJS_ExampleService = function(Items, _http) {
		this.$Items = null;
		this.$Items = Items;
	};
	$TestAngularJS_ExampleService.__typeName = 'TestAngularJS.ExampleService';
	global.TestAngularJS.ExampleService = $TestAngularJS_ExampleService;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.ExpanderController
	var $TestAngularJS_ExpanderController = function() {
		this.title = null;
		this.showMe = false;
		this.accordionController = null;
	};
	$TestAngularJS_ExpanderController.__typeName = 'TestAngularJS.ExpanderController';
	global.TestAngularJS.ExpanderController = $TestAngularJS_ExpanderController;
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
		this.Template = "<div>\r\n                         <div class='title' ng-click='toggle()'>{{title}}</div>\r\n                         <div class='body' ng-show='showMe' ng-transclude></div>\r\n                      </div>";
		this.DirectiveController = $TestAngularJS_ExpanderController;
	};
	$TestAngularJS_ExpanderDefinition.__typeName = 'TestAngularJS.ExpanderDefinition';
	global.TestAngularJS.ExpanderDefinition = $TestAngularJS_ExpanderDefinition;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.Filters
	var $TestAngularJS_Filters = function(LabelEuro) {
		this.$le = null;
		this.$le = LabelEuro;
	};
	$TestAngularJS_Filters.__typeName = 'TestAngularJS.Filters';
	global.TestAngularJS.Filters = $TestAngularJS_Filters;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.FundingExample
	var $TestAngularJS_FundingExample = function() {
	};
	$TestAngularJS_FundingExample.__typeName = 'TestAngularJS.FundingExample';
	$TestAngularJS_FundingExample.Main = function() {
		var app = angular.module('myApp', []);
		AngularJS.AngularBuilder.Factory($TestAngularJS_ItemsFactory).call(null, app);
		AngularJS.AngularBuilder.Service($TestAngularJS_ExampleService).call(null, app);
		AngularJS.AngularBuilder.Controller($TestAngularJS_StartUpController).call(null, app);
		window.alert("'" + ss.cast(eval('typeof new Date()'), String) + "'");
	};
	global.TestAngularJS.FundingExample = $TestAngularJS_FundingExample;
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
	$TestAngularJS_HelloDirective.__typeName = 'TestAngularJS.HelloDirective';
	global.TestAngularJS.HelloDirective = $TestAngularJS_HelloDirective;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.ItemsFactory
	var $TestAngularJS_ItemsFactory = function() {
	};
	$TestAngularJS_ItemsFactory.__typeName = 'TestAngularJS.ItemsFactory';
	global.TestAngularJS.ItemsFactory = $TestAngularJS_ItemsFactory;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.LabelsFactory
	var $TestAngularJS_LabelsFactory = function() {
	};
	$TestAngularJS_LabelsFactory.__typeName = 'TestAngularJS.LabelsFactory';
	global.TestAngularJS.LabelsFactory = $TestAngularJS_LabelsFactory;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.MyController
	var $TestAngularJS_MyController = function(_scope, _state) {
		this.$state = null;
		this.$state = _state;
	};
	$TestAngularJS_MyController.__typeName = 'TestAngularJS.MyController';
	global.TestAngularJS.MyController = $TestAngularJS_MyController;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.Person
	var $TestAngularJS_Person = function() {
		this.id = 0;
		this.name = null;
	};
	$TestAngularJS_Person.__typeName = 'TestAngularJS.Person';
	global.TestAngularJS.Person = $TestAngularJS_Person;
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
	$TestAngularJS_PhoneConfig.__typeName = 'TestAngularJS.PhoneConfig';
	global.TestAngularJS.PhoneConfig = $TestAngularJS_PhoneConfig;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.PhoneExample
	var $TestAngularJS_PhoneExample = function() {
	};
	$TestAngularJS_PhoneExample.__typeName = 'TestAngularJS.PhoneExample';
	$TestAngularJS_PhoneExample.Main = function() {
		var app = angular.module('myApp', []);
		AngularJS.AngularBuilder.Config($TestAngularJS_PhoneConfig).call(null, app);
		AngularJS.AngularBuilder.Controller($TestAngularJS_PhoneListController).call(null, app);
		AngularJS.AngularBuilder.Controller($TestAngularJS_PhoneListControllerDetail).call(null, app);
	};
	global.TestAngularJS.PhoneExample = $TestAngularJS_PhoneExample;
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
			// Window.Alert(person["name"].ToString());
		}));
		risp.error(function(data1, status1) {
			//   Window.Alert("errore!");
		});
	};
	$TestAngularJS_PhoneListController.__typeName = 'TestAngularJS.PhoneListController';
	global.TestAngularJS.PhoneListController = $TestAngularJS_PhoneListController;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.PhoneListControllerDetail
	var $TestAngularJS_PhoneListControllerDetail = function(_scope, _routeParams) {
		this.what = null;
		this.phoneId = 0;
		this.what = 'detail';
		this.phoneId = _routeParams.phoneId;
	};
	$TestAngularJS_PhoneListControllerDetail.__typeName = 'TestAngularJS.PhoneListControllerDetail';
	global.TestAngularJS.PhoneListControllerDetail = $TestAngularJS_PhoneListControllerDetail;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.PhoneRouteParams
	var $TestAngularJS_PhoneRouteParams = function() {
		this.phoneId = 0;
		AngularJS.RouteParams.call(this);
	};
	$TestAngularJS_PhoneRouteParams.__typeName = 'TestAngularJS.PhoneRouteParams';
	global.TestAngularJS.PhoneRouteParams = $TestAngularJS_PhoneRouteParams;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.ResourceExample
	var $TestAngularJS_ResourceExample = function() {
	};
	$TestAngularJS_ResourceExample.__typeName = 'TestAngularJS.ResourceExample';
	$TestAngularJS_ResourceExample.Main = function() {
		var app = angular.module('myApp', ['ngResource']);
		AngularJS.AngularBuilder.Controller($TestAngularJS_ResourceExampleController).call(null, app);
	};
	global.TestAngularJS.ResourceExample = $TestAngularJS_ResourceExample;
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
	$TestAngularJS_ResourceExampleController.__typeName = 'TestAngularJS.ResourceExampleController';
	global.TestAngularJS.ResourceExampleController = $TestAngularJS_ResourceExampleController;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.ShoppingCartExample
	var $TestAngularJS_ShoppingCartExample = function() {
	};
	$TestAngularJS_ShoppingCartExample.__typeName = 'TestAngularJS.ShoppingCartExample';
	$TestAngularJS_ShoppingCartExample.Main = function() {
		var app = angular.module('myApp', []);
		AngularJS.AngularBuilder.Factory($TestAngularJS_ItemsFactory).call(null, app);
		AngularJS.AngularBuilder.Factory($TestAngularJS_LabelsFactory).call(null, app);
		AngularJS.AngularBuilder.Filter($TestAngularJS_Filters).call(null, app);
		AngularJS.AngularBuilder.Controller($TestAngularJS_CartController).call(null, app);
	};
	global.TestAngularJS.ShoppingCartExample = $TestAngularJS_ShoppingCartExample;
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
	$TestAngularJS_StartUpController.__typeName = 'TestAngularJS.StartUpController';
	global.TestAngularJS.StartUpController = $TestAngularJS_StartUpController;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.State1Controller
	var $TestAngularJS_State1Controller = function(_scope, _stateParams) {
		this.MyValue = null;
		this.id = null;
		this.MyValue = 'hjhh';
		this.id = _stateParams['id'];
	};
	$TestAngularJS_State1Controller.__typeName = 'TestAngularJS.State1Controller';
	global.TestAngularJS.State1Controller = $TestAngularJS_State1Controller;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.TestPromises
	var $TestAngularJS_TestPromises = function(_q) {
		this.$Q = null;
		this.$Q = _q;
	};
	$TestAngularJS_TestPromises.__typeName = 'TestAngularJS.TestPromises';
	global.TestAngularJS.TestPromises = $TestAngularJS_TestPromises;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.UiRouterConfig
	var $TestAngularJS_UiRouterConfig = function(_stateProvider, _urlRouterProvider, _locationProvider) {
		_urlRouterProvider.otherwise('state1');
		var $t1 = {};
		$t1.name = 'state1';
		$t1.url = '/state1/{id}';
		$t1.templateUrl = 'state1.html';
		_stateProvider.state($t1);
		var $t2 = {};
		$t2.name = 'state2';
		$t2.url = '/state2';
		$t2.templateUrl = 'state2.html';
		_stateProvider.state($t2);
		var $t3 = {};
		$t3.name = 'state2.inner';
		$t3.url = '/state2inner';
		$t3.templateUrl = 'state2.inner.html';
		_stateProvider.state($t3);
	};
	$TestAngularJS_UiRouterConfig.__typeName = 'TestAngularJS.UiRouterConfig';
	global.TestAngularJS.UiRouterConfig = $TestAngularJS_UiRouterConfig;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.UiRouterExample
	var $TestAngularJS_UiRouterExample = function() {
	};
	$TestAngularJS_UiRouterExample.__typeName = 'TestAngularJS.UiRouterExample';
	$TestAngularJS_UiRouterExample.Main = function() {
		var app = angular.module('UiRouterExample', ['ui.router']);
		AngularJS.AngularBuilder.Config($TestAngularJS_UiRouterConfig).call(null, app);
		AngularJS.AngularBuilder.Controller($TestAngularJS_MyController).call(null, app);
		AngularJS.AngularBuilder.Controller($TestAngularJS_State1Controller).call(null, app);
	};
	global.TestAngularJS.UiRouterExample = $TestAngularJS_UiRouterExample;
	ss.initClass($AngularTests, $asm, {
		runTests: function() {
			test('OneIsOne', ss.mkdel(this, function() {
				deepEqual(1, 1, 'one is one');
				ok(true, 'one is still one');
				ok(!false, 'one is not two');
			}));
		}
	});
	ss.initClass($JasmineTests, $asm, {
		SpecRunner: function() {
			describe('Currency filter', ss.mkdel(this, function() {
				it('should format numbers to money amounts', ss.mkdel(this, function() {
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
	}, Object);
	ss.initClass($Test_BaseClass, $asm, {
		get_Type: function() {
			return this.$type;
		},
		set_Type: function(value) {
			this.$type = value;
		}
	});
	ss.initEnum($Test_EnumType, $asm, { Zero: 0, One: 1 });
	ss.initClass($Test_SubClass, $asm, {}, $Test_BaseClass);
	ss.initClass($Test_SubClass2, $asm, {
		get_Type: function() {
			return this.$subType;
		},
		set_Type: function(value) {
			this.$subType = value;
		}
	}, $Test_BaseClass);
	ss.initClass($Test_TestMain, $asm, {});
	ss.initClass($TestAngularJS_AccordionController, $asm, {
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
	});
	ss.initClass($TestAngularJS_AccordionDefinition, $asm, {}, AngularJS.DirectiveDefinition);
	ss.initClass($TestAngularJS_AccordionSharedController, $asm, {
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
	});
	ss.initClass($TestAngularJS_AnimationController, $asm, {
		switch_show: function() {
			this.show_block = !this.show_block;
		},
		add: function() {
			ss.insert(this.names, 0, 'item ' + this.names.length.toString());
		},
		remove: function(index) {
			ss.removeAt(this.names, index);
		}
	});
	ss.initClass($TestAngularJS_AnimationExample, $asm, {});
	ss.initClass($TestAngularJS_CartController, $asm, {
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
	}, AngularJS.Scope);
	ss.initClass($TestAngularJS_CartItem, $asm, {});
	ss.initClass($TestAngularJS_CoolAnimation, $asm, {
		Setup: function(element) {
			//this is called before the animation
			//jQuery.FromElement(element).CSS("opacity",0);
		},
		Start: function(element, done, memo) {
			var ob = ss.mkdict(['opacity', 1]);
			//jQuery.FromElement(element).Animate(ob, new TypeOption<int,EffectDuration>(), EffectEasing.Linear, ()=>{done();});
		},
		Cancel: function(element, done) {
		}
	});
	ss.initClass($TestAngularJS_DirectivesExample, $asm, {});
	ss.initClass($TestAngularJS_ExampleService, $asm, {
		DoAlert: function() {
			window.alert(this.$Items[0].title);
		}
	});
	ss.initClass($TestAngularJS_ExpanderController, $asm, {
		Link: function(_scope, iElement, iAttrs, acontroller) {
			this.accordionController = acontroller;
			this.showMe = false;
			this.accordionController.addExpander(this);
		},
		toggle: function() {
			this.showMe = !this.showMe;
			this.accordionController.gotOpened(this);
		}
	});
	ss.initClass($TestAngularJS_ExpanderDefinition, $asm, {}, AngularJS.DirectiveDefinition);
	ss.initClass($TestAngularJS_Filters, $asm, {
		euro: function(input) {
			return input.toString() + ' euros (' + this.$le + ')';
		},
		dracma: function(input) {
			return input.toString() + ' dracmas ';
		}
	});
	ss.initClass($TestAngularJS_FundingExample, $asm, {});
	ss.initClass($TestAngularJS_HelloDirective, $asm, {}, AngularJS.DirectiveDefinition);
	ss.initClass($TestAngularJS_ItemsFactory, $asm, {
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
	});
	ss.initClass($TestAngularJS_LabelsFactory, $asm, {
		LabelEuro: function() {
			return 'CHF';
		}
	});
	ss.initClass($TestAngularJS_MyController, $asm, {
		VaiStato2: function() {
			//Window.Alert("KK");
			this.$state.go('state2.inner');
		}
	});
	ss.initClass($TestAngularJS_Person, $asm, {}, null, [AngularJS.IResourceObject]);
	ss.initClass($TestAngularJS_PhoneConfig, $asm, {});
	ss.initClass($TestAngularJS_PhoneExample, $asm, {});
	ss.initClass($TestAngularJS_PhoneListController, $asm, {});
	ss.initClass($TestAngularJS_PhoneListControllerDetail, $asm, {});
	ss.initClass($TestAngularJS_PhoneRouteParams, $asm, {}, AngularJS.RouteParams);
	ss.initClass($TestAngularJS_ResourceExample, $asm, {});
	ss.initClass($TestAngularJS_ResourceExampleController, $asm, {
		Prova: function() {
			var $state = 0, $tcs = new ss.TaskCompletionSource(), $t1, z;
			var $sm = ss.mkdel(this, function() {
				try {
					$sm1:
					for (;;) {
						switch ($state) {
							case 0: {
								$state = -1;
								$t1 = this.dostuff();
								$state = 1;
								$t1.continueWith($sm);
								return;
							}
							case 1: {
								$state = -1;
								z = $t1.getAwaitedResult();
								$tcs.setResult(z);
								return;
							}
							default: {
								break $sm1;
							}
						}
					}
				}
				catch ($t2) {
					$tcs.setException(ss.Exception.wrap($t2));
				}
			});
			$sm();
			return $tcs.task;
		},
		dostuff: function() {
			var $state = 0, $tcs = new ss.TaskCompletionSource();
			var $sm = function() {
				try {
					$sm1:
					for (;;) {
						switch ($state) {
							case 0: {
								$state = -1;
								$tcs.setResult(55);
								return;
							}
							default: {
								break $sm1;
							}
						}
					}
				}
				catch ($t1) {
					$tcs.setException(ss.Exception.wrap($t1));
				}
			};
			$sm();
			return $tcs.task;
		},
		prova: function() {
			//persona = myres.Get<Person>(new {userId=10}, succ, err);
			//persona = myres.Action<Person>("fetch", new {userId=10}, succ, err);
			//persona.Action("fetch");
			var r = new (ss.makeGenericType(AngularJS.ResourceRequest$1, [$TestAngularJS_Person]))(this.myres);
			r.Action = 'fetch';
			r.Parameters['userId'] = 10;
			r.PostData = null;
			r.Success = ss.mkdel(this, this.succ);
			r.Error = ss.mkdel(this, this.err);
			this.persona = r.ExecuteRequest();
			this.persona.$save();
		},
		getok: function() {
			debugger;
		},
		succ: function(p, rh) {
			window.alert(p.name);
		},
		err: function(rh) {
			window.alert(rh.status.toString());
		}
	});
	ss.initClass($TestAngularJS_ShoppingCartExample, $asm, {});
	ss.initClass($TestAngularJS_StartUpController, $asm, {
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
	}, AngularJS.Scope);
	ss.initClass($TestAngularJS_State1Controller, $asm, {});
	ss.initClass($TestAngularJS_TestPromises, $asm, {
		UsePromise: function() {
			var p = this.CreatePromise();
		},
		CreatePromise: function() {
			var d = this.$Q.defer();
			// somewhere else:  d.Resolve(); or d.Reject();
			return d.promise;
		}
	});
	ss.initClass($TestAngularJS_UiRouterConfig, $asm, {});
	ss.initClass($TestAngularJS_UiRouterExample, $asm, {});
})();
