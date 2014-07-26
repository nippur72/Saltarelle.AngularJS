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
      Constant();
      Value();

      Filters();
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
}



