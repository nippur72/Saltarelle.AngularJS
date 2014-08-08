using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;
using Jasmine;
using System.Diagnostics;

// service for testing dependency injection

public class TestDIService1
{
   public object injected_value;
      
   public TestDIService1(object injected_object)
   {
      this.injected_value = injected_object;
   }
}

[Inject("attribute_injected_object")]
public class TestDIService2
{
   public object injected_value;

   public TestDIService2(object injected_object)
   {
      this.injected_value = injected_object;
   }
}



