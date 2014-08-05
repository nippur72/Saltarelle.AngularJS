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
   /// keeps track of all its controls and nested forms as well as the state of them, such as being valid/invalid or dirty/pristine.
   /// Each form directive creates an instance of FormController.
   /// </summary>
   [Imported]
   public sealed class FormController
   {

      /// <summary>
      /// Rollback all form controls pending updates to the $modelValue.
      /// </summary>
      [ScriptName("$rollbackViewValue(")] public void rollbackViewValue() {}

      /// <summary>
      /// Commit all form controls pending updates to the $modelValue.
      /// </summary>
      [ScriptName("$commitViewValue")] public void commitViewValue() {}

      /// <summary>
      /// Register a control with the form.
      /// </summary>
      [ScriptName("$addControl")] public void addControl() {}

      /// <summary>
      // Deregister a control from the form.
      /// </summary>
      [ScriptName("$removeControl")] public void removeControl() {}

      /// <summary>
      /// Sets the validity of a form control.
      /// </summary>
      [ScriptName("$setValidity")] public void setValidity() {}

      /// <summary>
      /// Sets the form to a dirty state.
      /// </summary>
      [ScriptName("$setDirty(")] public void setDirty() {}

      /// <summary>
      /// Sets the form to its pristine state.
      /// </summary>
      [ScriptName("$setPristine")] public void setPristine() {}

      /// <summary>
      /// Sets the form to its submitted state.
      /// </summary>
      public void setSubmitted() {}

      /// <summary>
      /// True if user has not interacted with the form yet.
      /// </summary>
      [ScriptName("$pristine")] public bool pristine;

      /// <summary>
      /// True if user has already interacted with the form.
      /// </summary>
      [ScriptName("$dirty")] public bool dirty;

      /// <summary>
      /// True if all of the containing forms and controls are valid.
      /// </summary>
      [ScriptName("$valid")] public bool valid;

      /// <summary>
      /// True if at least one containing control or form is invalid.
      /// </summary>
      [ScriptName("$invalid")] public bool invalid;

      /// <summary>
      /// An object hash, containing references to all invalid controls or forms,
      /// </summary>
      [ScriptName("$error")] public JsDictionary error;
   }
}

