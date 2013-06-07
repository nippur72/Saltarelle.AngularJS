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
      Assert.IsTrue(1==1,"uno è uno");
      Assert.IsTrue(1==2,"uno è due");
   }
}   

