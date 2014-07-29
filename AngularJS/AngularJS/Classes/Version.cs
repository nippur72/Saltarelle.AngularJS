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
   public sealed class Version
   {
      public string full;     // – {string} – Full version string, such as "0.9.18".
      public int major;       // – {number} – Major version number, such as "0".
      public int minor;       // – {number} – Minor version number, such as "9".
      public int dot;         // – {number} – Dot version number, such as "18".
      public string codeName; // – {string} – Code name of the release, such as "jiggling-armfat".
   }
}

