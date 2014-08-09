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

public class SimpleService
{   
   public int testval = 42;

   public SimpleService()
   {
   }
}

public class SimpleFactories
{
   public string SimpleFactory1()
   {
      return "fortytwo";   
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
      Get = UnicornLauncher();
   }

   public void useTinfoilShielding(bool flag)
   {
      shield_flag = flag;
   }

   // this is the $$get property
   [ScriptName("$get")]
   public object[] Get;

   // this is the $$get 
   public object[] UnicornLauncher()
   {                  
      Func<Timeout,UnicornLauncher> func = (t) => { return new UnicornLauncher(t,shield_flag); };

      object[] inj = new object[] { "$timeout", func };

      return inj;
   }   
}

public class UnicornConfig
{
   public UnicornConfig(UnicornLauncherProvider UnicornLauncherProvider)
   {      
      UnicornLauncherProvider.useTinfoilShielding(true);   
   }
}
