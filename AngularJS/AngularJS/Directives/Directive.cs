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
   public interface IDirective
   {
      DefinitionObject GetDefinition();
   }

   public class DefinitionObject
   {
   }   
}



