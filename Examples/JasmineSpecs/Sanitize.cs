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
   public void Sanitize()
   {      
      describe("$sanitize",()=>
      {                                         
         Module M = new Module("testsanitize", ngSanitize.ModuleName);                  
         var el = Window.Document.CreateElement("p");
         Injector injector = Angular.Bootstrap(el, M.Name);
                  
         Sanitize sanitize = injector.Get<Sanitize>("$sanitize");
                          
         it("should sanitize an html string",()=>
         {
            expect(sanitize("<p>this is<b onmouseover=alert('oo')>dangerous</b>data</p>")).toEqual("<p>this is<b>dangerous</b>data</p>");            
         });
      });

      describe("linky Filter",()=>
      {
         Module M = new Module("testlinkyfilter", ngSanitize.ModuleName);                  
         var el = Window.Document.CreateElement("p");
         Injector injector = Angular.Bootstrap(el, M.Name);
         
         Filter Filter = injector.Get<Filter>("$filter");

         var linky = Filter("linky");

         it("should convert text into http link",()=>
         {
            expect(linky("http://www.hello.com")).toBe("<a href=\x22http://www.hello.com\x22>http://www.hello.com</a>");
         });
      });
   }
}
