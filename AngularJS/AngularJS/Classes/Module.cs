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

      /*
      #region Convenience Methods

      [InlineCode("{this}.config({func})")]
      public void Config(object func)
      {
      }    

      [InlineCode("{this}.controller({Name},{func})")]
      public void Controller(string Name, object func)
      {
      } 
      
      [InlineCode("{this}.directive({Name},{defob})")]
      public void Directive(string Name, object defob)
      {
      }

      [InlineCode("{this}.factory({Name},{func})")]
      public void Factory(string Name, object func)
      {
      }          

      [InlineCode("{this}.filter({FilterName},{ob})")]
      public void Filter(string FilterName, object ob)
      {
      }            

      [InlineCode("{this}.factory({Name},{func})")]
      public void Service(string Name, Type func)
      {
      }          

      #endregion
      */

      [InlineCode("{this}.{@FuncName}(function(){{debugger;}})")]
      public void Debug(string FuncName) {}       

      [InlineCode("{this}.{@FuncName}({pars},function(){{debugger;}})")]
      public void Debug(string FuncName, string pars) {}   
      
      /*
      var myInjector = angular.injector(["ng"]);
      var $http = myInjector.get("$http");
      */                
   }     
}




