using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;
using Jasmine;

public class JasmineTests : JasmineSuite
{
   public void SpecRunner()
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
   }
}



