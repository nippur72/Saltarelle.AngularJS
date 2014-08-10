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
}



