using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;
using System.Reflection;
using System.Diagnostics;

namespace AngularJS.Cookies 
{          
   [Imported]
   public sealed class CookieStore
   {
      /// </summary>
      /// Returns the value of given cookie key
      /// <summary>
      public object get(string key) { return null; }
      
      /// </summary>
      /// Returns the value of given cookie key
      /// <summary>
      public T get<T>(string key) { return default(T); }
    
      /// </summary>
      /// Sets a value for given cookie key
      /// <summary>
      public void put(string key, object value) { }

      /// </summary>
      /// Remove given cookie
      /// <summary>
      public void remove(string key) { }
   }   
}




