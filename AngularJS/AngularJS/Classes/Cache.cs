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
   public sealed class Cache
   {      
      /// <summary>
      /// Inserts a named entry into the Cache object to be retrieved later, and incrementing the size of the cache if the key was not already present in the cache. 
      /// </summary>
      public object put(string key, object value) { return null; }

      /// <summary>
      /// Retrieves named data stored in the Cache object.
      /// </summary>
      public object get(string key) { return null; }

      /// <summary>
      /// Retrieves named data stored in the Cache object.
      /// </summary>
      public T get<T>(string key) { return default(T); }

      /// <summary>
      /// Removes an entry from the Cache object.
      /// </summary>
      public void remove(string key) { }

      /// <summary>
      /// Clears the cache object of any entries.
      /// </summary>
      public void removeAll() { }

      /// <summary>
      /// Destroys the Cache object entirely, removing it from the $cacheFactory set.
      /// </summary>
      public void destroy() {}

      /// <summary>
      /// Retrieve information regarding a particular Cache.
      /// </summary>
      public CacheInfo info() { return null; }
   }

   [Imported]
   public class CacheInfo
   {
      public string id;   
      public int size;
      
      public object this[string prop] 
      { 
         [InlineCode("{this}[{prop}]")]
         get { return null; }
      }      
   }
}

