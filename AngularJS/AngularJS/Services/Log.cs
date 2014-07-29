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
   public sealed class Log
   {
      /// <summary>
      /// Write a log message
      /// </summary>
      public void log(string message) {}
      
      /// <summary>
      /// Write an information message
      /// </summary>
      public void info(string message){}
      
      /// <summary>
      /// Write a warning message
      /// </summary>
      public void warn(string message){}
      
      /// <summary>
      /// Write an error message
      /// </summary>
      public void error(string message){}
      
      /// <summary>
      /// Write a debug message
      /// </summary>
      public void debug(string message){}
   }      
}

