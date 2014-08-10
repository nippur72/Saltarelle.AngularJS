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

public partial class JasmineTests : JasmineSuite
{
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
}



