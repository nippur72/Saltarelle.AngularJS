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
   public static class TypeExtensionMethods
   {
      public static List<string> GetInstanceMethodNames(this Type type)
      {
         List<string> result = new List<string>();
         foreach(string key in type.Prototype.Keys)
         {
            if(key!="constructor") result.Add(key);
         }   
         return result;
      }

      public static Injectable GetConstructorFunction(this Type type)
      {         
         return (Injectable) type.Prototype["constructor"];                 
      }              
      
      [InlineCode("{type}.prototype[{methodName}]")]
      public static Function GetMethodAsFunction(this Type type, string methodName)    
      {
         return null;
      }
   }
}

