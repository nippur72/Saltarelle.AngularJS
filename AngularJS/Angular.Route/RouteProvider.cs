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
   public sealed class RouteProvider
   {
      [InlineCode("{this}.otherwise({route})")]
      public RouteProvider otherwise(RouteMap route)
      {
         return this;
      }

      [InlineCode("{this}.when({path},{route})")]
      public RouteProvider when(string path, RouteMap route)
      {
         return this;
      }
   }
}

