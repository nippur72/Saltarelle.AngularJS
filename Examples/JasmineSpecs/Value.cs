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
}
