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
   public sealed class CacheFactory 
   {                       
      /// </summary>
      /// Constructs a Cache object 
      /// <summary>
      [InlineCode("{this}({chacheId})")]
      public Cache Create(string chacheId) { return null; }

      /// </summary>
      /// Constructs a Cache object 
      /// <summary>
      [InlineCode("{this}({chacheId}{options})")]
      public Cache Create(string chacheId, object options) { return null; }

      /// </summary>
      /// Get access to a cache object by the cacheId used when it was created.
      /// <summary>      
      JsDictionary<string, CacheInfo> info() { return null; }

      /// </summary>
      /// Get access to a cache object by the cacheId used when it was created.      
      /// <summary>
      public Cache get(string cacheId) { return null; }
   }  
}

