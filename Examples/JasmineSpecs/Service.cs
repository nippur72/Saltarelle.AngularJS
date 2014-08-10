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
}

public class SimpleService
{   
   public int testval = 42;

   public SimpleService()
   {
   }
}

