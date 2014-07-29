using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;
using Jasmine;
using System.Diagnostics;

public class JasmineTests : JasmineSuite
{
   public void SpecRunner()
   {      
      describe("Angular.Module",()=>
      {
         Constant();
         Value();
      });

      describe("Angular services",()=>
      {
         Parse();
         Locale();
         Interpolate();
      });

      Filters();

      Version();
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
}



