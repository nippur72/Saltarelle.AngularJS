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
   public void Parse()
   {      
      describe("$parse",()=>
      {
         Injector injector = Angular.Injector("ng");                 
         Parse _parse = injector.Get<Parse>("$parse");

         var getter = _parse("user.name");
         var setter = getter.assign;
         var context = new {user=new {name="angular"}};
         var locals = new {user=new {name="local"}};

         it("should read and write context in a parsed expression",()=>
         {
            expect(getter.Call(context)).toEqual("angular");            
            setter(context, "newValue");
            expect(context.user.name).toEqual("newValue");
            expect(getter.Call(context, locals)).toEqual("local");
         });
      });
   }
}



