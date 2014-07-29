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
   /// Retrieves a filtering function by giving the filter name
   /// <summary>
   public delegate FilterFunction Filter(string filtername);   

   /// <summary>
   /// Filters a string
   /// <summary>
   public delegate string FilterFunction(string expr);   
}

