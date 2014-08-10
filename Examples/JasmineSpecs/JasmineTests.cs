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
   public void SpecRunner()
   {           
      DependencyInjection();

      describe("Angular.Module",()=>
      {
         Constant();
         Value();
         Service();
         Factory();
         Provider();
      });

      describe("Angular services",()=>
      {
         Parse();
         Locale();
         Interpolate();
         CacheFactory();
      });

      Filters();

      Version();

      describe("ngSanitize",()=>
      {
         Sanitize();
      });
   }  
}
