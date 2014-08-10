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
   public void DependencyInjection()
   {
      describe("Dependecy injection",()=>
      {
         it("should work with implicit annotation in constructor parameter names", ()=>
         {
            Module M = new Module("test1");            
            M.Service<TestDIService1>();     // TestDIService1 is a service with an implicit injection named "injected_object"
            M.Constant("injected_object",42);  
            Injector injector = Angular.Injector("test1");                 
            var serv = injector.Get<TestDIService1>("TestDIService1");

            expect(serv.injected_value).toBe(42);
         });

         it("should work with explicit annotation", ()=>
         {
            Module M = new Module("test2");            
            M.Constant("injected_object",16); 
            M.Constant("explicit_injected_object",42);              
            M.Service<TestDIService1>("explicit_injected_object");  // TestDIService1 is a service with an implicit injection named "injected_object"
            
            Injector injector = Angular.Injector("test2");                 
            var serv = injector.Get<TestDIService1>("TestDIService1");

            expect(serv.injected_value).toBe(42);
         });
         
         it("should work with explicit annotation with [Inject] decorator", ()=>
         {
            Module M = new Module("test3");            
            M.Service<TestDIService2>();     // TestDIService2 is a service with an explicit attribute injection named "attribute_injected_object"
            M.Constant("attribute_injected_object",42);  
            Injector injector = Angular.Injector("test3");                 
            var serv = injector.Get<TestDIService1>("TestDIService2");

            expect(serv.injected_value).toBe(42);
         });
      });
   }
}

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


