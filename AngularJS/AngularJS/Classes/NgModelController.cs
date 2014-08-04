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
   /// Provides API for the `ng-model` directive.
   /// </summary>
   [Imported]
   public sealed class NgModelController
   {
      /// <summary>
      /// Called when the view needs to be updated. It is expected that the user of the ng-model directive will implement this method.
      /// </summary>
      [ScriptName("$render")] public Action render;

      /// <summary>
      /// This is called when we need to determine if the value of the input is empty.
      /// </summary>
      [ScriptName("$isEmpty")] Func<object,bool> isEmpty;

      /// <summary>
      /// Change the validity state, and notifies the form when the control changes validity. 
      /// </summary>
      [ScriptName("$setValidity")] public void setValidity(string validationErrorKey, bool isValid) { }

      /// <summary>
      /// Sets the control to its pristine state.
      /// </summary>
      [ScriptName("$setPristine")] public void setPristine() {}

      /// <summary>
      /// Sets the control to its untouched state.
      /// </summary>
      [ScriptName("$setUntouched")] public void setUntouched() {}

      /// <summary>
      /// Sets the control to its touched state.
      /// </summary>
      [ScriptName("$setTouched")] public void setTouched() {}

      /// <summary>
      /// Cancel an update and reset the input element's value to prevent an update to the $modelValue,
      /// </summary>
      [ScriptName("$rollbackViewValue")] public void rollbackViewValue() {}

      /// <summary>
      /// Runs each of the registered validations set on the $validators object.
      /// </summary>
      [ScriptName("$validate")] public void validate() {}

      /// <summary>
      /// Commit a pending update to the $modelValue.
      /// </summary>
      [ScriptName("$commitViewValue")] public void commitViewValue() {}

      /// <summary>
      /// Update the view value.
      /// </summary>
      [ScriptName("$setViewValue")] public void setViewValue(string value, string trigger) {}
      [ScriptName("$setViewValue")] public void setViewValue(string value) {}

      /// <summary>
      /// Actual string value in the view.
      /// </summary>
      [ScriptName("$viewValue")] public string viewValue;

      /// <summary>
      /// The value in the model, that the control is bound to.
      /// </summary>
      [ScriptName("$modelValue")] public object modelValue;
   
      /// <summary>
      /// Array of functions to execute, as a pipeline, whenever the control reads value from the DOM
      /// </summary>
      [ScriptName("$parsers")] public Action<object>[] parsers;

      /// <summary>
      /// Array of functions to execute, as a pipeline, whenever the model value changes. 
      /// </summary>
      [ScriptName("$formatters")] public Action<object>[] formatters;
     
      /// <summary>
      /// A collection of validators that are applied whenever the model value changes. 
      /// </summary>
      [ScriptName("$validators")] public JsDictionary<string,Action<object>> validators;

      /// <summary>
      /// Array of functions to execute whenever the view value has changed.
      /// </summary>
      [ScriptName("$viewChangeListeners")] public Action[] viewChangeListeners;
      	
      /// <summary>
      /// An object hash with all errors as keys.
      /// </summary>
      [ScriptName("$error")] public JsDictionary error;

      /// <summary>
      /// True if control has not lost focus yet.
      /// </summary>
      [ScriptName("$untouched")] public bool untouched;

      /// <summary>
      /// True if control has lost focus.
      /// </summary>
      [ScriptName("$touched")] public bool touched;

      /// <summary>
      /// True if user has not interacted with the control yet.
      /// </summary>
      [ScriptName("$pristine")] public bool pristine;

      /// <summary>
      /// True if user has already interacted with the control.
      /// </summary>
      [ScriptName("$dirty")] public bool dirty;

      /// <summary>
      /// True if there is no error.
      /// </summary>
      [ScriptName("$valid")] public bool valid;

      /// <summary>
      /// True if at least one error on the control.
      /// </summary>
      [ScriptName("$invalid")] public bool invalid;
   }
}

