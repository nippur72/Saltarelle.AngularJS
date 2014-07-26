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
   [Imported]
   public sealed class Module
   {
      [InlineCode("angular.module({Name},[])")] 
      public Module(string Name)
      {
      }

      [InlineCode("angular.module({ModuleName},{Requires})")]
      public Module(string ModuleName, params string[] Requires)
      {         
      }
      
      /// <summary>
      /// Name of the module
      /// </summary>
      public string Name
      {
         [InlineCode("{this}.name")] get { return null; }
      }

      /// <summary>
      /// List of module names which must be loaded before this module
      /// </summary>      
      public string[] Requires
      {
         [InlineCode("{this}.requires")] get { return null; }
      } 
   }     
}




