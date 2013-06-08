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
      describe("Javascript variables",()=>
      {
         it("assigments should work",()=>
         {
            var a=5;
            expect(a).not.toBe(6);
         });   
      });    
   }
}



