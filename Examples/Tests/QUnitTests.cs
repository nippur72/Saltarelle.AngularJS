using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using QUnit;

using AngularJS;
  
[TestFixture]
public class AngularTests
{       
   [Test]
   public void OneIsOne()
   {
      Assert.AreEqual(1,1,"one is one");         
      Assert.IsTrue(1==1,"one is still one");
      Assert.IsFalse(1==2,"one is not two");
   }
}   
