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
   //
   // This class adds Getter and Setter javascript properties ("get" and "set")
   // to type class function, to overcome Saltarelle syntax of "get_prop()" and "set_prop()".
   //
   // It is called automatically on every registered controller and service and is meant to be
   // called from HTML templates, making templates more readable.
   //
   // Once this feature will be added to the Saltarelle compiler, this class will become obsolete.
   //
   public static class FixGetterSetterExtension
   {
      public static void FixGetterSetter(this Type type)
      {         
         var methods = type.GetInstanceMethodNames(); 

         foreach(string methname in methods)
         {
            if(methname.StartsWith("get_"))
            {
               string propname = methname.Substring(4);
               bool has_setter = methods.Contains("set_"+propname);

               Function fget = new Function("",string.Format("return this.get_{0}();",propname));
               Function fset = new Function("value",string.Format("this.set_{0}(value);",propname));
               
               if(has_setter)
               {
                  defineprop(type, propname,fget,fset);
               }
               else
               {
                  definepropreadonly(type, propname, fget);
               }
            }
         }
      }
      
      [InlineCode("Object.defineProperty({type}.prototype, {propname}, {{get: {fget}, set: {fset}, enumerable: true, configurable: true}})")]
      public static void defineprop(Type type, string propname, Function fget, Function fset)
      {
      }
            
      [InlineCode("Object.defineProperty({type}.prototype, {propname}, {{get: {fget}, enumerable: true, configurable: true}})")]
      public static void definepropreadonly(Type type, string propname, Function fget)
      {
      }
   }
}

