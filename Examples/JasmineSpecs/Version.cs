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
