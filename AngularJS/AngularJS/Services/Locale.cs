using System;

//using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;
using System.Reflection;
using System.Diagnostics;

namespace AngularJS
{       
   [Imported]
   public sealed class Locale
   {
      /// <summary>
      /// locale id formatted as languageId-countryId (e.g. en-us)
      /// </summary>
      [IntrinsicProperty]
      public string id
      {
          get { return ""; }         
      }
   }
}

