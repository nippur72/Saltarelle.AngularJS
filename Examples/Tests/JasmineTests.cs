using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;
using AngularJS.Sanitize;

using Jasmine;
using System.Diagnostics;

public class JasmineTests : JasmineSuite
{
   public void SpecRunner()
   {           
      DependencyInjection();

      describe("Angular.Module",()=>
      {
         Constant();
         Value();
         Service();
         Factory();
         Provider();
      });

      describe("Angular services",()=>
      {
         Parse();
         Locale();
         Interpolate();
         CacheFactory();
      });

      Filters();

      Version();

      describe("ngSanitize",()=>
      {
         Sanitize();
      });
   }

   public void DependencyInjection()
   {
      describe("Dependecy injection",()=>
      {
         it("should work with implicit annotation in constructor parameter names", ()=>
         {
            Module M = new Module("test1");            
            M.Service<TestDIService1>();     // TestDIService1 is a service with an implicit injection named "injected_object"
            M.Constant("injected_object",42);  
            Injector injector = Angular.Injector("test1");                 
            var serv = injector.Get<TestDIService1>("TestDIService1");

            expect(serv.injected_value).toBe(42);
         });

         it("should work with explicit annotation", ()=>
         {
            Module M = new Module("test2");            
            M.Constant("injected_object",16); 
            M.Constant("explicit_injected_object",42);              
            M.Service<TestDIService1>("explicit_injected_object");  // TestDIService1 is a service with an implicit injection named "injected_object"
            
            Injector injector = Angular.Injector("test2");                 
            var serv = injector.Get<TestDIService1>("TestDIService1");

            expect(serv.injected_value).toBe(42);
         });
         
         it("should work with explicit annotation with [Inject] decorator", ()=>
         {
            Module M = new Module("test3");            
            M.Service<TestDIService2>();     // TestDIService2 is a service with an explicit attribute injection named "attribute_injected_object"
            M.Constant("attribute_injected_object",42);  
            Injector injector = Angular.Injector("test3");                 
            var serv = injector.Get<TestDIService1>("TestDIService2");

            expect(serv.injected_value).toBe(42);
         });

      });
   }

   public void Constant()
   {
      Module M = new Module("test");
      
      M.Constant("testconst",42);  
     
      Injector injector = Angular.Injector("test");                 

      describe("Constant",()=>
      {         
         object testconst = null;

         it("should be defined in the injector",()=>
         {           
            Action read = ()=> {testconst = injector.Get("testconst"); };
            expect(read).not.toThrow();            
         });            

         it("should return the expected value",()=>
         {            
            expect(testconst).toBe(42);
         });   
      });
   }

   public void Value()
   {
      Module M = new Module("test");

      M.Value("testvalue",42);     

      Injector injector = Angular.Injector("test");                 

      describe("Value",()=>
      {         
         object testvalue = null;

         it("should be defined in the injector",()=>
         {           
            Action read = ()=> {testvalue = injector.Get("testvalue"); };
            expect(read).not.toThrow();            
         });            

         it("should return the expected value",()=>
         {            
            expect(testvalue).toBe(42);
         });   
      });
   }

   public void Service()
   {
      Module M = new Module("testservice");
      M.Service<SimpleService>();

      var el = Window.Document.CreateElement("p");
      Injector injector = Angular.Bootstrap(el, M.Name);           

      describe("Service",()=>
      {         
         var simpleService = injector.Get<SimpleService>("SimpleService");

         it("should be defined in the injector",()=>
         {           
            expect(simpleService).not.toBeNull();
         });            

         it("should return the expected value",()=>
         {            
            expect(simpleService.testval).toBe(42);
         });   
      });
   }

   public void Factory()
   {
      Module M = new Module("testfactory");
      M.Factory<SimpleFactories>();

      var el = Window.Document.CreateElement("p");
      Injector injector = Angular.Bootstrap(el, M.Name);           

      describe("Factory",()=>
      {         
         var factory = injector.Get<string>("SimpleFactory1");

         it("should be defined in the injector",()=>
         {           
            expect(factory).not.toBeNull();
         });            

         it("should return the expected value",()=>
         {            
            expect(factory).toBe("fortytwo");
         });   
      });
   }

   public void Provider()
   {
      Module M = new Module("testprovider");     

      M.Provider<UnicornLauncherProvider>();      
      M.Config<UnicornConfig>();

      var el = Window.Document.CreateElement("p");
      Injector injector = Angular.Bootstrap(el, M.Name);           

      describe("Provider",()=>
      {         
         var launcher = injector.Get<UnicornLauncher>("UnicornLauncher");         
         var timeout  = injector.Get("$timeout");         

         it("should create service in the injector",()=>
         {           
            expect(launcher).not.toBeNull();
         });            
         
         it("should set parameters in service",()=>
         {           
            expect(launcher.shieldtype).toBe("tinfoil");
         });

         it("should create service with correct dependency injection",()=>
         {           
            expect(launcher.Timeout).toBe(timeout);
         });            
      });
   }

   public void Parse()
   {      
      describe("$parse",()=>
      {
         Injector injector = Angular.Injector("ng");                 
         Parse _parse = injector.Get<Parse>("$parse");

         var getter = _parse("user.name");
         var setter = getter.assign;
         var context = new {user=new {name="angular"}};
         var locals = new {user=new {name="local"}};

         it("should read and write context in a parsed expression",()=>
         {
            expect(getter.Call(context)).toEqual("angular");            
            setter(context, "newValue");
            expect(context.user.name).toEqual("newValue");
            expect(getter.Call(context, locals)).toEqual("local");
         });
      });
   }

   public void Locale()
   {      
      describe("$locale",()=>
      {
         Injector injector = Angular.Injector("ng");                 
         var loc = injector.Get<Locale>("$locale");

         it("should be set to english language/US by default",()=>
         {
            expect(loc.id).toEqual("en-us");            
         });
      });
   }

   public void Interpolate()
   {      
      describe("$interpolate",()=>
      {
         Injector injector = Angular.Injector("ng");                 
         var interpolate = injector.Get<Interpolate>("$interpolate");

         it("should interpolate strings with given context",()=>
         {            
            var exp = interpolate.Call("Hello {{name | uppercase}}!");
            var context = new {name="Angular"};
            expect(exp(context)).toEqual("Hello ANGULAR!");
         });

         it("should interpolate strings in 'forgiving' mode",()=>
         {            
            var context = new {greeting="Hello" /*, name: undefined*/ };            
            var exp = interpolate.Call("{{greeting}} {{name}}!");
            expect(exp(context)).toEqual("Hello !");
         });

         it("should interpolate strings in 'allOrNothing' mode",()=>
         {                      
            var context      = new {greeting="Hello", /*, name: undefined*/ };                        
            var context_full = new {greeting="Hello", name="Angular" };                        
            var exp = interpolate.Call("{{greeting}} {{name}}!", false, null, true);
            expect(exp(context     )).toBeUndefined();                        
            expect(exp(context_full)).toEqual("Hello Angular!");
         });
      });
   }

   public void CacheFactory()
   {      
      describe("$cacheFactory",()=>
      {
         Injector injector = Angular.Injector("ng");                 
         var cacheFactory = injector.Get<CacheFactory>("$cacheFactory");

         var cache = cacheFactory.Create("cacheId");

         it("should create a Cache object in the cache",()=>
         {
            expect(cacheFactory.get("cacheId")).toBe(cache);
         });

         it("should not find unexisting Cache objects",()=>
         {
            expect(cacheFactory.get("noSuchCacheId")).not.toBeDefined();
         });

         it("should write values to cache",()=>
         {
            cache.put("key", "value");
            cache.put("another key", "another value");
            
            expect(cache.info()).toEqual(new {id="cacheId", size=2});
            expect(cache.get("key")).toEqual("value");
            expect(cache.get("another key")).toEqual("another value");
         });

         it("should remove values from cache",()=>
         {
            cache.remove("another key");            
            expect(cache.info()).toEqual(new {id="cacheId", size=1});
         });

         it("should remove all values from cache",()=>
         {
            cache.removeAll();
            expect(cache.info()).toEqual(new {id="cacheId", size=0});
         });

         it("should destroy the cache",()=>
         {
            cache.destroy();
            expect(cacheFactory.get("cacheId")).not.toBeDefined();
         });
      });
   }


   public void Filters()
   {
      describe("Filters",()=>
      {
         describe("Currency filter",()=>
         {
            it("should format numbers to money amounts",()=>
            {
               currencyFilter f = Angular.BuiltinFilters.currencyFilter;
               expect(f.Filter(0))       .toBe("$0.00");
               expect(f.Filter(5.75))    .toBe("$5.75");
               expect(f.Filter(1000000)) .toBe("$1,000,000.00");
               expect(f.Filter(-5.75))   .toBe("($5.75)");
               expect(f.Filter(5.753))   .toBe("$5.75");
               expect(f.Filter(5.75,"€")).toBe("€5.75");
            });
         });

         describe("Date filter",()=>
         {
            dateFilter f = Angular.BuiltinFilters.dateFilter;
            JsDate d = new JsDate(1972,4,3);

            it("should format dates to U.S. format",()=>{ expect(f.Filter(d)).toBe("May 3, 1972"); });
            it("should format short dates",()=>{ expect(f.Filter(d,"dd/MM/yy")).toBe("03/05/72"); });
            it("should format long dates",()=>{ expect(f.Filter(d,"dd/MM/yyyy")).toBe("03/05/1972"); });
         });      
      });
   }

   public void Version()
   {
      describe("Angular.Version",()=>
      {
         it("should be at least 1.3 in this testing environment",()=>
         {
            expect(Angular.Version.major).not.toBeLessThan(1);
            expect(Angular.Version.minor).not.toBeLessThan(3);
         });
      });
   }

   public void Sanitize()
   {      
      describe("$sanitize",()=>
      {                                         
         Module M = new Module("testsanitize", ngSanitize.ModuleName);                  
         var el = Window.Document.CreateElement("p");
         Injector injector = Angular.Bootstrap(el, M.Name);
                  
         Sanitize sanitize = injector.Get<Sanitize>("$sanitize");
                          
         it("should sanitize an html string",()=>
         {
            expect(sanitize("<p>this is<b onmouseover=alert('oo')>dangerous</b>data</p>")).toEqual("<p>this is<b>dangerous</b>data</p>");            
         });
      });

      describe("linky Filter",()=>
      {
         Module M = new Module("testlinkyfilter", ngSanitize.ModuleName);                  
         var el = Window.Document.CreateElement("p");
         Injector injector = Angular.Bootstrap(el, M.Name);
         
         Filter Filter = injector.Get<Filter>("$filter");

         var linky = Filter("linky");

         it("should convert text into http link",()=>
         {
            expect(linky("http://www.hello.com")).toBe("<a href=\x22http://www.hello.com\x22>http://www.hello.com</a>");
         });
      });
   }
}



