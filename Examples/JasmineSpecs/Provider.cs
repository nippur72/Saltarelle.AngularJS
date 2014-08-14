using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;
using Jasmine;
using System.Diagnostics;

public partial class JasmineTests : JasmineSuite
{
   public void Provider()
   {
      Module M = new Module("testprovider");     

      M.Provider<UnicornLauncherProvider>();      
      M.Config<UnicornConfig>();

      var el = Window.Document.CreateElement("p");
      Injector injector = Angular.Bootstrap(el, M.Name);           

      describe("Provider",()=>
      {         
         var launcher = injector.Get<UnicornLauncher>("UnicornLauncher");         
         var timeout  = injector.Get("$timeout");         

         it("should create service in the injector",()=>
         {           
            expect(launcher).not.toBeNull();
         });            
         
         it("should set parameters in service",()=>
         {           
            expect(launcher.shieldtype).toBe("tinfoil");
         });

         it("should create service with correct dependency injection",()=>
         {           
            expect(launcher.Timeout).toBe(timeout);
         });            
      });
   }
}

public class UnicornLauncher
{
   public int launchedCount = 0; 
   public string shieldtype = "none";  
   public Timeout Timeout;

   public UnicornLauncher(Timeout _timeout, bool useTinfoilShielding)
   {
      Timeout = _timeout;

      if(useTinfoilShielding)
      {
         shieldtype = "tinfoil";
      }
   }

   public void launch()
   {
      this.launchedCount++;
   } 
}

public class UnicornLauncherProvider 
{
   private bool shield_flag = false;  
   
   public UnicornLauncherProvider()
   {      
   }

   public void useTinfoilShielding(bool flag)
   {
      shield_flag = flag;
   }
   
   [Inject("$timeout")]
   public UnicornLauncher UnicornLauncher(Timeout _timeout)
   {
      return new UnicornLauncher(_timeout, shield_flag);
   }   
}


public class UnicornConfig
{
   public UnicornConfig(UnicornLauncherProvider UnicornLauncherProvider)
   {      
      UnicornLauncherProvider.useTinfoilShielding(true);   
   }
}
