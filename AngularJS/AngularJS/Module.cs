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
   public delegate string Filter<T>(T input);

   [Imported]
   public sealed class Module
   {
      [InlineCode("angular.module({Name},[])")] 
      public Module(string Name)
      {
      }
      
      /// <summary>
      /// Name of the module
      /// </summary>
      public string Name
      {
         [InlineCode("{this}.name")]
         get
         {
            return "";
         }
      }

      /// <summary>
      /// List of module names which must be loaded before this module
      /// </summary>      
      public string[] Requires
      {
         [InlineCode("{this}.requires")]
         get
         {
            return null;
         }
      }

      [InlineCode("{this}.controller({Name},{func})")]
      public void Controller(string Name, List<object> func)
      {
      } 
      
      [InlineCode("{this}.factory({Name},{func})")]
      public void Factory(string Name, object func)
      {
      }

      [InlineCode("{this}.filter({FilterName},function() {{ var {@FilterName} = {func}; return {@FilterName}; }})")]
      public void Filter<T>(string FilterName, Filter<T> func)
      {
      }      

      [InlineCode("{this}.filter({FilterName},{ob})")]
      public void Filter(string FilterName, object ob)
      {
      }      

      [InlineCode("{this}.filter({FilterName},function() {{ var filter = {func}; return filter; }})")]
      public void FilterAll(string FilterName, object func)
      {
      }            
      
      [InlineCode("{this}.config({func})")]
      public void Config(object func)
      {
      }    

      [InlineCode("{this}.directive({Name},function() {{ return {func}; }})")]
      public void Directive(string Name, object func)
      {
      }
   }     
}

