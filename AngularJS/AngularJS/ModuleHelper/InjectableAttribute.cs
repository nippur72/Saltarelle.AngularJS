using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;
using System.Reflection;
using System.Diagnostics;

namespace AngularJS
{         
   /// <summary>
   /// Specify dependency injection for the class
   /// </summary>
   [AttributeUsage(AttributeTargets.Class,AllowMultiple=false)]   
   public class InjectAttribute : Attribute
   {
      public string[] Injectables;

      public InjectAttribute(params string[] annotations)
      {
         this.Injectables = annotations;            
      }
   }
}

