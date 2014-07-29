(function() {
	'use strict';
	var $asm = {};
	global.TestAngularJS = global.TestAngularJS || {};
	ss.initAssembly($asm, 'Examples');
	////////////////////////////////////////////////////////////////////////////////
	// JasmineTests
	var $JasmineTests = function() {
		ss.shallowCopy({}, this);
	};
	$JasmineTests.__typeName = 'JasmineTests';
	global.JasmineTests = $JasmineTests;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.AccordionController
	var $TestAngularJS_AccordionController = function() {
		this.accordiontitle = 'This is an accordion';
		this.expanders = [];
	};
	$TestAngularJS_AccordionController.__typeName = 'TestAngularJS.AccordionController';
	global.TestAngularJS.AccordionController = $TestAngularJS_AccordionController;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.accordionDirective
	var $TestAngularJS_accordionDirective = function() {
	};
	$TestAngularJS_accordionDirective.__typeName = 'TestAngularJS.accordionDirective';
	global.TestAngularJS.accordionDirective = $TestAngularJS_accordionDirective;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.AnimationController
	var $TestAngularJS_AnimationController = function(_scope) {
		this.Checked = false;
		this.bodytext = null;
		this.items = null;
		this.filter = null;
		this.runAnimation = false;
		this.Checked = false;
		this.bodytext = 'This text is animated when shown on/off';
		this.items = ['Rome', 'Tokyo', 'New York', 'London', 'Paris', 'Moscow', 'Berlin'];
		this.runAnimation = false;
	};
	$TestAngularJS_AnimationController.__typeName = 'TestAngularJS.AnimationController';
	global.TestAngularJS.AnimationController = $TestAngularJS_AnimationController;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.AnimationExample
	var $TestAngularJS_AnimationExample = function() {
	};
	$TestAngularJS_AnimationExample.__typeName = 'TestAngularJS.AnimationExample';
	$TestAngularJS_AnimationExample.Main = function() {
		var app = angular.module('myApp', ['ngAnimate']);
		AngularJS.ModuleBuilder.Animation($TestAngularJS_SpecialAnimation).call(null, app, '.special-animation');
		AngularJS.ModuleBuilder.Controller($TestAngularJS_AnimationController).call(null, app);
	};
	global.TestAngularJS.AnimationExample = $TestAngularJS_AnimationExample;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.CartController
	var $TestAngularJS_CartController = function(_scope, Items) {
		this.items = null;
		this.billDiscount = 0;
		this.zeroitems();
		this.items = Items;
		_scope.$watch(ss.mkdel(this, this.totalCart), ss.mkdel(this, this.calculateDiscount));
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
	// TestAngularJS.DirectivesExample
	var $TestAngularJS_DirectivesExample = function() {
	};
	$TestAngularJS_DirectivesExample.__typeName = 'TestAngularJS.DirectivesExample';
	$TestAngularJS_DirectivesExample.Main = function() {
		var app = angular.module('myApp', []);
		AngularJS.ModuleBuilder.Directive($TestAngularJS_accordionDirective).call(null, app);
		AngularJS.ModuleBuilder.Directive($TestAngularJS_expanderDirective).call(null, app);
		AngularJS.ModuleBuilder.Directive($TestAngularJS_helloDirective).call(null, app);
		AngularJS.ModuleBuilder.Controller($TestAngularJS_TestDirectiveController).call(null, app);
	};
	global.TestAngularJS.DirectivesExample = $TestAngularJS_DirectivesExample;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.ExpanderController
	var $TestAngularJS_ExpanderController = function(_scope) {
		this.Scope = null;
		this.showMe = false;
		this.accordionController = null;
		this.Scope = _scope;
	};
	$TestAngularJS_ExpanderController.__typeName = 'TestAngularJS.ExpanderController';
	global.TestAngularJS.ExpanderController = $TestAngularJS_ExpanderController;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.expanderDirective
	var $TestAngularJS_expanderDirective = function() {
	};
	$TestAngularJS_expanderDirective.__typeName = 'TestAngularJS.expanderDirective';
	global.TestAngularJS.expanderDirective = $TestAngularJS_expanderDirective;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.Filters
	var $TestAngularJS_Filters = function(LabelPounds) {
		this.$label_pounds = null;
		this.$label_pounds = LabelPounds;
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
		AngularJS.ModuleBuilder.Controller($TestAngularJS_StartUpController).call(null, app);
	};
	global.TestAngularJS.FundingExample = $TestAngularJS_FundingExample;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.helloDirective
	var $TestAngularJS_helloDirective = function() {
	};
	$TestAngularJS_helloDirective.__typeName = 'TestAngularJS.helloDirective';
	global.TestAngularJS.helloDirective = $TestAngularJS_helloDirective;
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
		AngularJS.ModuleBuilder.Config($TestAngularJS_PhoneConfig).call(null, app);
		AngularJS.ModuleBuilder.Controller($TestAngularJS_PhoneListController).call(null, app);
		AngularJS.ModuleBuilder.Controller($TestAngularJS_PhoneListControllerDetail).call(null, app);
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
		AngularJS.ModuleBuilder.Controller($TestAngularJS_ResourceExampleController).call(null, app);
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
		AngularJS.ModuleBuilder.Factory($TestAngularJS_ItemsFactory).call(null, app);
		AngularJS.ModuleBuilder.Factory($TestAngularJS_LabelsFactory).call(null, app);
		AngularJS.ModuleBuilder.Filter($TestAngularJS_Filters).call(null, app);
		AngularJS.ModuleBuilder.Controller($TestAngularJS_CartController).call(null, app);
	};
	global.TestAngularJS.ShoppingCartExample = $TestAngularJS_ShoppingCartExample;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.SpecialAnimation
	var $TestAngularJS_SpecialAnimation = function(_interval) {
		this.$scrolltext = "*** CBM BASIC V2 *** 3583 BYTES FREE READY. 10 PRINT 'HELLO' 20 GOTO 10 RUN";
		this.$Interval = null;
		this.$Interval = _interval;
	};
	$TestAngularJS_SpecialAnimation.__typeName = 'TestAngularJS.SpecialAnimation';
	global.TestAngularJS.SpecialAnimation = $TestAngularJS_SpecialAnimation;
	////////////////////////////////////////////////////////////////////////////////
	// TestAngularJS.StartUpController
	var $TestAngularJS_StartUpController = function(_scope) {
		this.fundingStartingEstimate = 0;
		this.fundingNeeded = 0;
		this.fundingStartingEstimate = 0;
		_scope.$watch(ss.mkdel(this, function() {
			return this.fundingStartingEstimate;
		}), ss.mkdel(this, this.compneeded));
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
	// TestAngularJS.TestDirectiveController
	var $TestAngularJS_TestDirectiveController = function(_scope) {
	};
	$TestAngularJS_TestDirectiveController.__typeName = 'TestAngularJS.TestDirectiveController';
	global.TestAngularJS.TestDirectiveController = $TestAngularJS_TestDirectiveController;
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
		AngularJS.ModuleBuilder.Config($TestAngularJS_UiRouterConfig).call(null, app);
		AngularJS.ModuleBuilder.Controller($TestAngularJS_MyController).call(null, app);
		AngularJS.ModuleBuilder.Controller($TestAngularJS_State1Controller).call(null, app);
	};
	global.TestAngularJS.UiRouterExample = $TestAngularJS_UiRouterExample;
	ss.initClass($JasmineTests, $asm, {
		SpecRunner: function() {
			this.Constant();
			this.Value();
			this.Parse();
			this.Filters();
		},
		Constant: function() {
			var M = angular.module('test', []);
			M.constant('testconst', 42);
			var injector = angular.injector(['test']);
			describe('Constant', ss.mkdel(this, function() {
				var testconst = null;
				it('should be defined in the injector', ss.mkdel(this, function() {
					var read = function() {
						testconst = injector.get('testconst');
					};
					expect(read).not.toThrow();
				}));
				it('should return the expected value', ss.mkdel(this, function() {
					expect(testconst).toBe(42);
				}));
			}));
		},
		Value: function() {
			var M = angular.module('test', []);
			M.value('testvalue', 42);
			var injector = angular.injector(['test']);
			describe('Value', ss.mkdel(this, function() {
				var testvalue = null;
				it('should be defined in the injector', ss.mkdel(this, function() {
					var read = function() {
						testvalue = injector.get('testvalue');
					};
					expect(read).not.toThrow();
				}));
				it('should return the expected value', ss.mkdel(this, function() {
					expect(testvalue).toBe(42);
				}));
			}));
		},
		Parse: function() {
			describe('$parse', ss.mkdel(this, function() {
				var injector = angular.injector(['ng']);
				var _parse = injector.get('$parse');
				var getter = _parse('user.name');
				var setter = getter.assign;
				var context = { user: { name: 'angular' } };
				var locals = { user: { name: 'local' } };
				it('should read and write context in a parsed expression', ss.mkdel(this, function() {
					expect(getter(context)).toEqual('angular');
					setter(context, 'newValue');
					expect(context.user.name).toEqual('newValue');
					expect(getter(context, locals)).toEqual('local');
				}));
			}));
		},
		Filters: function() {
			describe('Filters', ss.mkdel(this, function() {
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
			}));
		}
	}, Object);
	ss.initClass($TestAngularJS_AccordionController, $asm, {
		clickme: function() {
			window.alert('clicked!');
		},
		gotOpened: function(selectedExpander) {
			for (var $t1 = 0; $t1 < this.expanders.length; $t1++) {
				var o = this.expanders[$t1];
				if (!ss.referenceEquals(selectedExpander, o)) {
					o.showMe = false;
				}
			}
		},
		addExpander: function(expander) {
			ss.add(this.expanders, expander);
		}
	});
	ss.initClass($TestAngularJS_accordionDirective, $asm, {
		Link: function(_scope, iElement, iAttrs, acontroller) {
		},
		GetDefinition: function() {
			var def = new AngularJS.DirectiveDefinitionHelper();
			def.Restrict = 3;
			def.Replace = true;
			def.Transclude = true;
			def.ScopeMode = 0;
			def.Template = "<div><div ng-click='acc.clickme()'>[{{acc.accordiontitle}}] you can click me</div><div ng-transclude></div>[end]</div>";
			def.Controller($TestAngularJS_AccordionController).call(def);
			def.ControllerAs = 'acc';
			return def.ToDefinitionObject();
		}
	}, null, [AngularJS.IDirective]);
	ss.initClass($TestAngularJS_AnimationController, $asm, {
		startAnimation: function() {
			this.runAnimation = !this.runAnimation;
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
	});
	ss.initClass($TestAngularJS_CartItem, $asm, {});
	ss.initClass($TestAngularJS_DirectivesExample, $asm, {});
	ss.initClass($TestAngularJS_ExpanderController, $asm, {
		toggle: function() {
			this.showMe = !this.showMe;
			this.accordionController.gotOpened(this);
		}
	});
	ss.initClass($TestAngularJS_expanderDirective, $asm, {
		Link: function(_scope, iElement, iAttrs, acontroller) {
			var ctrl = _scope.ccc;
			ctrl.accordionController = acontroller;
			ctrl.accordionController.addExpander(ctrl);
		},
		GetDefinition: function() {
			var def = new AngularJS.DirectiveDefinitionHelper();
			def.Restrict = 1;
			def.Replace = true;
			def.Transclude = true;
			def.RequireDirective('accordion', true, false);
			def.ScopeMode = 2;
			def.BindAttribute$2('title', 'expanderTitle');
			def.Template = "<div>\r\n                             <div class='title' ng-click='ccc.toggle()'>{{title}}</div>\r\n                             <div style='margin-left: 1em;' class='body' ng-show='ccc.showMe' ng-transclude></div>\r\n                          </div>";
			def.Link = ss.mkdel(this, this.Link);
			def.Controller($TestAngularJS_ExpanderController).call(def);
			def.ControllerAs = 'ccc';
			return def.ToDefinitionObject();
		}
	}, null, [AngularJS.IDirective]);
	ss.initClass($TestAngularJS_Filters, $asm, {
		euro: function(input) {
			return input.toString() + ' euros ';
		},
		pounds: function(input) {
			return (input * 1.25).toString() + ' ' + this.$label_pounds;
		}
	});
	ss.initClass($TestAngularJS_FundingExample, $asm, {});
	ss.initClass($TestAngularJS_helloDirective, $asm, {
		GetDefinition: function() {
			var def = new AngularJS.DirectiveDefinitionHelper();
			def.Restrict = 7;
			def.Template = '<div>Hello, <span ng-transclude></span>!</div>';
			def.Replace = true;
			def.Transclude = true;
			return def.ToDefinitionObject();
		}
	}, null, [AngularJS.IDirective]);
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
		LabelPounds: function() {
			return 'GBP';
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
	ss.initClass($TestAngularJS_SpecialAnimation, $asm, {
		GetDefinition: function() {
			var removeClass = ss.mkdel(this, function(element, className, doneCallback) {
				// keep tracks of the timer
				var timerPromise = null;
				// the cancel/end animation funcion
				var cancelCallback = ss.mkdel(this, function() {
					this.$Interval.cancel(timerPromise);
				});
				// the function that updated the control
				var OnTick = ss.mkdel(this, function(el) {
					var l = el.textContent.length;
					if (l < this.$scrolltext.length) {
						el.textContent = this.$scrolltext.substr(0, l + 1);
					}
					else {
						cancelCallback();
						// stops the animation
						doneCallback();
					}
				});
				if (className === 'ng-hide') {
					// We're unhiding the element, i.e. showing the element
					var el1 = element[0];
					el1.textContent = '*';
					timerPromise = this.$Interval(function() {
						OnTick(el1);
					}, 100);
				}
				else {
					doneCallback();
				}
				return cancelCallback;
			});
			// Action<bool> addClass(element, string className, Action done)
			var addClass = function(element1, className1, done) {
				if (className1 === 'ng-hide') {
					// We're hiding the element
					done();
				}
				else {
					done();
				}
			};
			return { addClass: addClass, removeClass: removeClass };
		}
	}, null, [AngularJS.Animate.IAnimation]);
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
	});
	ss.initClass($TestAngularJS_State1Controller, $asm, {});
	ss.initClass($TestAngularJS_TestDirectiveController, $asm, {});
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
