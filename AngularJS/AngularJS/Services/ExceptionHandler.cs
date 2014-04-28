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
   public sealed class AngularException
   {      
      public string Message { [InlineCode("{this}.message")] get { return null;} }
   }  

   [Imported]
   public sealed class ExceptionHandler
   {
      [InlineCode("{this}({exception})")]          public void Throw(AngularException exception) {  }
      [InlineCode("{this}({exception},{cause})")]  public void Throw(AngularException exception, string cause) {  }      
   }  
}

