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
}

public class SimpleFactories
{
   public string SimpleFactory1()
   {
      return "fortytwo";   
   }
}




