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
   public void CacheFactory()
   {      
      describe("$cacheFactory",()=>
      {
         Injector injector = Angular.Injector("ng");                 
         var cacheFactory = injector.Get<CacheFactory>("$cacheFactory");

         var cache = cacheFactory.Create("cacheId");

         it("should create a Cache object in the cache",()=>
         {
            expect(cacheFactory.get("cacheId")).toBe(cache);
         });

         it("should not find unexisting Cache objects",()=>
         {
            expect(cacheFactory.get("noSuchCacheId")).not.toBeDefined();
         });

         it("should write values to cache",()=>
         {
            cache.put("key", "value");
            cache.put("another key", "another value");
            
            expect(cache.info()).toEqual(new {id="cacheId", size=2});
            expect(cache.get("key")).toEqual("value");
            expect(cache.get("another key")).toEqual("another value");
         });

         it("should remove values from cache",()=>
         {
            cache.remove("another key");            
            expect(cache.info()).toEqual(new {id="cacheId", size=1});
         });

         it("should remove all values from cache",()=>
         {
            cache.removeAll();
            expect(cache.info()).toEqual(new {id="cacheId", size=0});
         });

         it("should destroy the cache",()=>
         {
            cache.destroy();
            expect(cacheFactory.get("cacheId")).not.toBeDefined();
         });
      });
   } 
}
