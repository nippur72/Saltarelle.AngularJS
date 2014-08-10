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
}
