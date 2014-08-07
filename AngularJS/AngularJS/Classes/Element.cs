using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;
using System.Reflection;
using System.Diagnostics;

using AngularJS.jqLiteApi;

namespace AngularJS.jqLiteApi 
{
    [Imported]
    [IgnoreNamespace]
    public class jQueryEvent { }

    /// <summary>
    /// Handles a jQuery event.
    /// </summary>
    public delegate void jQueryEventHandler(jQueryEvent e);

 	 /// <summary>
 	 /// Handles a jQuery event, and promotes the 'this' in Javascript to a parameter.
	 /// </summary>
	 [BindThisToFirstParameter]
	 public delegate void jQueryEventHandlerWithContext(Element elem, jQueryEvent e);

    /// <summary>
    /// A callback that returns a value for the element at the specified index.
    /// </summary>
    /// <param name="index">The index of the element in the set.</param>
    public delegate string StringFunction(int index);

    /// <summary>
    /// A callback that returns a value for the element at the specified index.
    /// </summary>
    /// <param name="element">Element for which the function is being invoked, in script represented as 'this'.</param>
    /// <param name="index">The index of the element in the set.</param>
    [BindThisToFirstParameter]
    public delegate string StringFunctionWithContext(Element element, int index);

    /// <summary>
    /// A callback that returns a value for the element at the specified index.
    /// </summary>
    /// <param name="index">The index of the element in the set.</param>
    /// <param name="currentValue">The current value.</param>
    public delegate string StringReplaceFunction(int index, string currentValue);

    /// <summary>
    /// A callback that returns a value for the element at the specified index.
    /// </summary>
    /// <param name="element">Element for which the function is being invoked, in script represented as 'this'.</param>
    /// <param name="index">The index of the element in the set.</param>
    /// <param name="currentValue">The current value.</param>
    [BindThisToFirstParameter]
	 public delegate string StringReplaceFunctionWithContext(Element element, int index, string currentValue);
}

namespace AngularJS
{             
   [Imported]
   public sealed class jElement
   {
      public object controller(string name) { return null; }
      public Injector injector() { return null; }
      public Scope scope() { return null; }
      public Scope isolateScope() { return null; }
      public object inherithedData() { return null; }

        #region jqLite       
        // jqLite definitions are a stripped version from jElement taken from SaltarelleJQuery

        /// <summary>
        /// Gets the Document or DOM element used as the context to match
        /// this set of elements.
        /// </summary>
        [IntrinsicProperty]
        public object context {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the number of elements in this <see cref="jElement" />.
        /// </summary>
        [IntrinsicProperty]
        public int length {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Gets the selector used to match this set of elements.
        /// </summary>
        [IntrinsicProperty]
        public string selector {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the matched element at the specified index.
        /// </summary>
        /// <param name="index">The index to lookup.</param>
        /// <returns>The DOM element at the specified index.</returns>
        [IntrinsicProperty]
        public Element this[int index] {
            get {
                return null;
            }
        }

        /// <summary>
        /// Adds the specified class(es) to each of the set of matched elements.
        /// </summary>
        /// <param name="className">The class or classes to add.</param>
        /// <returns>The current jElement.</returns>
        public jElement addClass(string className) {
            return null;
        }

        /// <summary>
        /// Adds the CSS class returned by the specified function.
        /// </summary>
        /// <param name="cssFunction">The function that returns the CSS class to add.</param>
        /// <returns>The current jElement.</returns>
        public jElement addClass(StringFunction cssFunction) {
            return null;
        }

        /// <summary>
        /// Adds the CSS class returned by the specified function.
        /// </summary>
        /// <param name="cssFunction">The function that returns the CSS class to add.</param>
        /// <returns>The current jElement.</returns>
        public jElement addClass(StringFunctionWithContext cssFunction) {
            return null;
        }

        /// <summary>
        /// Adds the CSS class returned by the specified function.
        /// </summary>
        /// <param name="cssFunction">The function that returns the CSS class to add.</param>
        /// <returns>The current jElement.</returns>
        public jElement AddClass(StringReplaceFunction cssFunction) {
            return null;
        }

        /// <summary>
        /// Adds the CSS class returned by the specified function.
        /// </summary>
        /// <param name="cssFunction">The function that returns the CSS class to add.</param>
        /// <returns>The current jElement.</returns>
        public jElement addClass(StringReplaceFunctionWithContext cssFunction) {
            return null;
        }

        /// <summary>
        /// Insert content after each element of the matching elements.
        /// </summary>
        /// <param name="content">The content to insert.</param>
        /// <returns>The current jElement</returns>
        public jElement after(string content) {
            return null;
        }

        /// <summary>
        /// Insert content after each element of the matching elements.
        /// </summary>
        /// <param name="content">The jElement containing the content.</param>
        /// <returns>The current jElement</returns>
        public jElement after(jElement content) {
            return null;
        }

        /// <summary>
        /// Insert content returned from the specified function after each element
        /// of the matching elements.
        /// </summary>
        /// <param name="contentFunction">The function that returns the content to insert.</param>
        /// <returns>The current jElement</returns>
        public jElement after(StringFunction contentFunction) {
            return null;
        }

        /// <summary>
        /// Insert content returned from the specified function after each element
        /// of the matching elements.
        /// </summary>
        /// <param name="contentFunction">The function that returns the content to insert.</param>
        /// <returns>The current jElement</returns>
        public jElement after(StringFunctionWithContext contentFunction) {
            return null;
        }

        /// <summary>
        /// Insert content to the end of each element of the matching elements.
        /// </summary>
        /// <param name="content">The content to append.</param>
        /// <returns>The current jElement</returns>
        public jElement append(string content) {
            return null;
        }

        /// <summary>
        /// Insert content to the end of each element of the matching elements.
        /// </summary>
        /// <param name="content">The DOM element to append.</param>
        /// <returns>The current jElement</returns>
        public jElement append(Element content) {
            return null;
        }

        /// <summary>
        /// Insert content to the end of each element of the matching elements.
        /// </summary>
        /// <param name="content">The jElement containing the content.</param>
        /// <returns>The current jElement</returns>
        public jElement append(jElement content) {
            return null;
        }

        /// <summary>
        /// Insert content returned from the specified function to end end of each element
        /// of the matching elements.
        /// </summary>
        /// <param name="contentFunction">The function that returns the content to append.</param>
        /// <returns>The current jElement</returns>
        public jElement append(StringFunction contentFunction) {
            return null;
        }

        /// <summary>
        /// Insert content returned from the specified function to end end of each element
        /// of the matching elements.
        /// </summary>
        /// <param name="contentFunction">The function that returns the content to append.</param>
        /// <returns>The current jElement</returns>
        public jElement append(StringFunctionWithContext contentFunction) {
            return null;
        }

        /// <summary>
        /// Insert content returned from the specified function to end end of each element
        /// of the matching elements.
        /// </summary>
        /// <param name="contentFunction">The function that returns the content to append.</param>
        /// <returns>The current jElement</returns>
        public jElement append(StringReplaceFunction contentFunction) {
            return null;
        }

        /// <summary>
        /// Insert content returned from the specified function to end end of each element
        /// of the matching elements.
        /// </summary>
        /// <param name="contentFunction">The function that returns the content to append.</param>
        /// <returns>The current jElement</returns>
        public jElement append(StringReplaceFunctionWithContext contentFunction) {
            return null;
        }

        /// <summary>
        /// Sets the specified attribute value to the specified value on
        /// the set of matched elements.
        /// </summary>
        /// <param name="attributeName">The name of the attribute to set.</param>
        /// <param name="value">The value of the attribute.</param>
        /// <returns>The current jElement.</returns>
        public jElement attr(string attributeName, string value) {
            return null;
        }

        /// <summary>
        /// Sets the specified attributes to the set of matched elements.
        /// </summary>
        /// <param name="nameValueMap">The list of names and values of the attributes to set.</param>
        /// <returns>The current jElement.</returns>
        [ScriptName("attr")]
        public jElement attr(JsDictionary nameValueMap) {
            return null;
        }

        /// <summary>
        /// Sets the specified attributes to the value returned from the specified function.
        /// </summary>
        /// <param name="attributeName">The name of the attribute to set.</param>
        /// <param name="attrFunction">The function returning the attribute values.</param>
        /// <returns>The current jElement.</returns>
        public jElement attr(string attributeName, StringFunction attrFunction) {
            return null;
        }

        /// <summary>
        /// Sets the specified attributes to the value returned from the specified function.
        /// </summary>
        /// <param name="attributeName">The name of the attribute to set.</param>
        /// <param name="attrFunction">The function returning the attribute values.</param>
        /// <returns>The current jElement.</returns>        
        public jElement attr(string attributeName, StringFunctionWithContext attrFunction) {
            return null;
        }

        /// <summary>
        /// Sets the specified attributes to the value returned from the specified function.
        /// </summary>
        /// <param name="attributeName">The name of the attribute to set.</param>
        /// <param name="attrFunction">The function returning the attribute values.</param>
        /// <returns>The current jElement.</returns>
        public jElement attr(string attributeName, StringReplaceFunction attrFunction) {
            return null;
        }

        /// <summary>
        /// Sets the specified attributes to the value returned from the specified function.
        /// </summary>
        /// <param name="attributeName">The name of the attribute to set.</param>
        /// <param name="attrFunction">The function returning the attribute values.</param>
        /// <returns>The current jElement.</returns>
        public jElement attr(string attributeName, StringReplaceFunctionWithContext attrFunction) {
            return null;
        }

        /// <summary>
        /// Attaches a handler for handling the specified event on the matched set of elements.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jElement</returns>
        public jElement bind(string eventName, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler for the specified event on the matched set of elements.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventData">Any data that needs to be passed to the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns>The current jElement</returns>
        public jElement bind(string eventName, JsDictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler that prevents default behavior and stops event bubbling for
        /// the specified event on the matched set of elements.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="result">Should be false.</param>
        /// <returns>The current jElement</returns>
        public jElement bind(string eventName, bool result) {
            return null;
        }

        /// <summary>
        /// Gets a jElement representing the children of the matched set of elements.
        /// </summary>
        /// <returns>The new jElement.</returns>
        public jElement children() {
            return null;
        }

        /// <summary>
        /// Gets a jElement representing the children of the matched set of elements.
        /// </summary>
        /// <param name="selector">The selector to match children against.</param>
        /// <returns>The new jElement.</returns>
        public jElement children(string selector) {
            return null;
        }

        /// <summary>
        /// Creates a clone of the current jElement and the matching elements it
        /// represents.
        /// </summary>
        /// <returns>The cloned jElement.</returns>
        public jElement clone() {
            return null;
        }

        /// <summary>
        /// Creates a clone of the current jElement and the matching elements it
        /// represents.
        /// </summary>
        /// <param name="withDataAndEvents">Whether event handlers and element data should be copied over.</param>
        /// <returns>The cloned jElement.</returns>
        public jElement clone(bool withDataAndEvents) {
            return null;
        }

        /// <summary>
        /// Creates a clone of the current jElement and the matching elements it
        /// represents.
        /// </summary>
        /// <param name="withDataAndEvents">Whether event handlers and element data should be copied over.</param>
        /// <param name="deepWithDataAndEvents">Whether event handlers and element data for all children should be copied over.</param>
        /// <returns>The cloned jElement.</returns>
        public jElement clone(bool withDataAndEvents, bool deepWithDataAndEvents) {
            return null;
        }

        /// <summary>
        /// Gets a jElement representing the content of the matched set of elements
        /// including text nodes.
        /// </summary>
        /// <returns>The new jElement with added elements.</returns>
        public jElement contents() {
            return null;
        }

        /// <summary>
        /// Sets the specified CSS attribute value to the specified value on
        /// the set of matched elements.
        /// </summary>
        /// <param name="attributeName">The name of the CSS attribute to set.</param>
        /// <param name="value">The value of the CSS attribute.</param>
        /// <returns>The current jElement.</returns>        
        public jElement css(string attributeName, string value) {
            return null;
        }

        /// <summary>
        /// Sets the specified CSS attribute value to the specified value on
        /// the set of matched elements.
        /// </summary>
        /// <param name="attributeName">The name of the CSS attribute to set.</param>
        /// <param name="value">The value of the CSS attribute.</param>
        /// <returns>The current jElement.</returns>
        public jElement css(string attributeName, int value) {
            return null;
        }

        /// <summary>
        /// Sets the specified CSS attribute value to the values returned by the
        /// specified function on the set of matched elements.
        /// </summary>
        /// <param name="attributeName">The name of the CSS attribute to set.</param>
        /// <param name="valueFunction">The function returning attribute values.</param>
        /// <returns>The current jElement.</returns>
        public jElement css(string attributeName, StringFunction valueFunction) {
            return null;
        }

        /// <summary>
        /// Sets the specified CSS attribute value to the values returned by the
        /// specified function on the set of matched elements.
        /// </summary>
        /// <param name="attributeName">The name of the CSS attribute to set.</param>
        /// <param name="valueFunction">The function returning attribute values.</param>
        /// <returns>The current jElement.</returns>
        public jElement css(string attributeName, StringFunctionWithContext valueFunction) {
            return null;
        }

        /// <summary>
        /// Sets the specified CSS attribute value to the values returned by the
        /// specified function on the set of matched elements.
        /// </summary>
        /// <param name="attributeName">The name of the CSS attribute to set.</param>
        /// <param name="valueFunction">The function returning attribute values.</param>
        /// <returns>The current jElement.</returns>
        public jElement css(string attributeName, StringReplaceFunction valueFunction) {
            return null;
        }

        /// <summary>
        /// Sets the specified CSS attribute value to the values returned by the
        /// specified function on the set of matched elements.
        /// </summary>
        /// <param name="attributeName">The name of the CSS attribute to set.</param>
        /// <param name="valueFunction">The function returning attribute values.</param>
        /// <returns>The current jElement.</returns>
        public jElement css(string attributeName, StringReplaceFunctionWithContext valueFunction) {
            return null;
        }

        /// <summary>
        /// Sets the specified CSS attributes to the set of matched elements.
        /// </summary>
        /// <param name="nameValueMap">The list of names and values of the CSS attributes to set.</param>
        /// <returns>The current jElement.</returns>
        public jElement css(JsDictionary nameValueMap) {
            return null;
        }

        /// <summary>
        /// Sets the specified value as data on the matching set of elements.
        /// </summary>
        /// <param name="key">The key used to store value.</param>
        /// <param name="value">The value to store.</param>
        /// <returns>The current jElement.</returns>
        public jElement data(string key, object value) {
            return null;
        }

        /// <summary>
        /// Sets the specified name/value pairs as data on the matching set of elements.
        /// This extends any existing data on the element.
        /// </summary>
        /// <param name="data">The set of name/value pairs to set.</param>
        /// <returns>The current jElement.</returns>
        public jElement data(JsDictionary data) {
            return null;
        }

        /// <summary>
        /// Removes all child elements of the matching set of elements.
        /// </summary>
        /// <returns>The current jElement.</returns>
        public jElement empty() {
            return null;
        }

        /// <summary>
        /// Reduce the set of matched elements to a single element.
        /// </summary>
        /// <param name="index">The index of the element. Use negative to count backwards.</param>
        /// <returns>A new jElement wrapping the specified element.</returns>
        public jElement eq(int index) {
            return null;
        }

        /// <summary>
        /// Returns a new jElement with descendents of each matched element filtered
        /// by the specified element.
        /// This traverses down multiple levels of the tree.
        /// </summary>
        /// <param name="element">The element to match against.</param>
        /// <returns>The new jElement.</returns>
        public jElement find(Element element) {
            return null;
        }

        /// <summary>
        /// Returns a new jElement with descendents of each matched element filtered
        /// by the specified matched set of elements.
        /// This traverses down multiple levels of the tree.
        /// </summary>
        /// <param name="elements">The matched set of elements to lookup.</param>
        /// <returns>The new jElement.</returns>
        public jElement find(jElement elements) {
            return null;
        }

        /// <summary>
        /// Returns a new jElement with descendents of each matched element filtered
        /// by the specified selector. This traverses down multiple levels of the tree.
        /// </summary>
        /// <param name="selector">The selector used to match elements.</param>
        /// <returns>The new jElement.</returns>
        public jElement find(string selector) {
            return null;
        }
        /// <summary>
        /// Determine whether any of the matched elements are assigned the given class.
        /// </summary>
        /// <param name="className">The class name to search for.</param>
        /// <returns>true if the class name is found; false otherwise.</returns>
        public bool hasClass(string className) {
            return false;
        }

        /// <summary>
        /// Sets the HTML content of the matched set of elements.
        /// </summary>
        /// <param name="html">The new HTML to set.</param>
        /// <returns>The current jElement.</returns>
        public jElement html(string html) {
            return null;
        }

        /// <summary>
        /// Sets the HTML content of the matched set of elements to the markup represented
        /// by the specified element.
        /// </summary>
        /// <param name="html">The new HTML to set.</param>
        /// <returns>The current jElement.</returns>
        public jElement html(jElement html) {
            return null;
        }

        /// <summary>
        /// Sets the HTML content of the matched set of elements by calling the specified
        /// function.
        /// </summary>
        /// <param name="htmlFunction">The function that returns the HTML content.</param>
        /// <returns>The current jElement.</returns>
        public jElement html(StringFunction htmlFunction) {
            return null;
        }

        /// <summary>
        /// Sets the HTML content of the matched set of elements by calling the specified
        /// function.
        /// </summary>
        /// <param name="htmlFunction">The function that returns the HTML content.</param>
        /// <returns>The current jElement.</returns>
        public jElement html(StringFunctionWithContext htmlFunction) {
            return null;
        }

        /// <summary>
        /// Sets the HTML content of the matched set of elements by calling the specified
        /// function.
        /// </summary>
        /// <param name="htmlFunction">The function that returns the HTML content.</param>
        /// <returns>The current jElement.</returns>
        public jElement html(StringReplaceFunction htmlFunction) {
            return null;
        }

        /// <summary>
        /// Sets the HTML content of the matched set of elements by calling the specified
        /// function.
        /// </summary>
        /// <param name="htmlFunction">The function that returns the HTML content.</param>
        /// <returns>The current jElement.</returns>
        public jElement html(StringReplaceFunctionWithContext htmlFunction) {
            return null;
        }

        /// <summary>
        /// Gets a jElement representing the immediate following sibling
        /// element of the matched set of elements.
        /// </summary>
        /// <returns>The new jElement.</returns>
        public jElement next() {
            return null;
        }

        /// <summary>
        /// Gets a jElement representing the immediate following sibling
        /// element of the matched set of elements filtered by the specified selector.
        /// </summary>
        /// <param name="selector">The selector to match children against.</param>
        /// <returns>The new jElement.</returns>
        public jElement next(string selector) {
            return null;
        }

        /// <summary>
        /// Removes an event handler which has been created by called On()
        /// </summary>
        /// <param name="eventsMap">A dictionary in which the string keys represent the event names, and the values represent the handler which was previously attached to that event</param>
        /// <returns>The current jElement.</returns>
        public jElement off(JsDictionary eventsMap) {
            return null;
        }

        /// <summary>
        /// Removes an event handler which has been created by called On()
        /// </summary>
        /// <param name="eventsMap">A dictionary in which the string keys represent the event names, and the values represent the handler which was previously attached to that event</param>
        /// <param name="selector">A selector which should match the one originally passed to On()</param>
        /// <returns>The current jElement.</returns>
        public jElement off(JsDictionary eventsMap, string selector) {
            return null;
        }

        /// <summary>
        /// Removes an event handler which has been created by called On()
        /// </summary>
        /// <param name="events">One or more space-separated event types and optional namespaces</param>
        /// <returns>The current jElement.</returns>
        public jElement Off(string events) {
            return null;
        }

        /// <summary>
        /// Removes an event handler which has been created by called On()
        /// </summary>
        /// <param name="events">One or more space-separated event types and optional namespaces</param>
        /// <param name="selector">A selector which should match the one originally passed to On()</param>
        /// <returns>The current jElement.</returns>
        public jElement off(string events, string selector) {
            return null;
        }

        /// <summary>
        /// Removes an event handler which has been created by called On()
        /// </summary>
        /// <param name="events">One or more space-separated event types and optional namespaces</param>
        /// <param name="selector">A selector which should match the one originally passed to On()</param>
        /// <param name="eventHandler">A handler function previously attached for the event(s)</param>
        /// <returns>The current jElement.</returns>
        public jElement off(string events, string selector, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Removes an event handler which has been created by called On()
        /// </summary>
        /// <param name="events">One or more space-separated event types and optional namespaces</param>
        /// <param name="selector">A selector which should match the one originally passed to On()</param>
        /// <param name="eventHandler">A handler function previously attached for the event(s)</param>
        /// <returns>The current jElement.</returns>
        public jElement off(string events, string selector, jQueryEventHandlerWithContext eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches an event handler function for one or more events to the selected elements.
        /// </summary>
        /// <param name="eventName">The name of the event</param>
        /// <param name="eventHandler">The event handler to be invoked</param>
        /// <returns>The current jElement.</returns>
        public jElement on(string eventName, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches an event handler function for one or more events to the selected elements.
        /// </summary>
        /// <param name="eventName">The name of the event</param>
        /// <param name="eventHandler">The event handler to be invoked</param>
        /// <returns>The current jElement.</returns>
        public jElement on(string eventName, jQueryEventHandlerWithContext eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches an event handler function for one or more events to the selected elements.
        /// </summary>
        /// <param name="eventName">The name of the event</param>
        /// <param name="selector">A selector string to filter the descendants of the selected elements that trigger the event.</param>
        /// <param name="eventHandler">The event handler to be invoked</param>
        /// <returns>The current jElement.</returns>
        public jElement on(string eventName, string selector, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches an event handler function for one or more events to the selected elements.
        /// </summary>
        /// <param name="eventName">The name of the event</param>
        /// <param name="selector">A selector string to filter the descendants of the selected elements that trigger the event.</param>
        /// <param name="eventHandler">The event handler to be invoked</param>
        /// <returns>The current jElement.</returns>
        public jElement on(string eventName, string selector, jQueryEventHandlerWithContext eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches an event handler function for one or more events to the selected elements.
        /// </summary>
        /// <param name="eventName">The name of the event</param>
        /// <param name="selector">A selector string to filter the descendants of the selected elements that trigger the event.</param>
        /// <param name="data">A custom data structure to be passed to the handler</param>
        /// <param name="eventHandler">The event handler to be invoked</param>
        /// <returns>The current jElement.</returns>
        public jElement on(string eventName, string selector, object data, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches an event handler function for one or more events to the selected elements.
        /// </summary>
        /// <param name="eventName">The name of the event</param>
        /// <param name="selector">A selector string to filter the descendants of the selected elements that trigger the event.</param>
        /// <param name="data">A custom data structure to be passed to the handler</param>
        /// <param name="eventHandler">The event handler to be invoked</param>
        /// <returns>The current jElement.</returns>
        public jElement on(string eventName, string selector, object data, jQueryEventHandlerWithContext eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches an event handler function for one or more events to the selected elements.
        /// </summary>
        /// <param name="eventsMap">A dictionary in which the string keys represent the event names, and the values represent the handler for that event.</param>
        /// <returns>The current jElement</returns>
        public jElement on(JsDictionary eventsMap) {
            return null;
        }

        /// <summary>
        /// Attaches an event handler function for one or more events to the selected elements.
        /// </summary>
        /// <param name="eventsMap">A dictionary in which the string keys represent the event names, and the values represent the handler for that event.</param>
        /// <param name="selector">A selector string to filter the descendants of the selected elements that trigger the event.</param>
        /// <returns>The current jElement</returns>
        public jElement on(JsDictionary eventsMap, string selector) {
            return null;
        }

        /// <summary>
        /// Attaches an event handler function for one or more events to the selected elements.
        /// </summary>
        /// <param name="eventsMap">A dictionary in which the string keys represent the event names, and the values represent the handler for that event.</param>
        /// <param name="selector">A selector string to filter the descendants of the selected elements that trigger the event.</param>
        /// <param name="data">A custom data structure to be passed to the handler</param>
        /// <returns>The current jElement</returns>
        public jElement on(JsDictionary eventsMap, string selector, object data) {
            return null;
        }

        /// <summary>
        /// Attaches a handler for the handling the specified event once on the matched
        /// set of elements.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns></returns>
        public jElement one(string eventName, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler for the handling the specified event once on the matched
        /// set of elements.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns></returns>
        public jElement one(string eventName, jQueryEventHandlerWithContext eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler for handling the specified event once on the matched set of elements.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventData">Any data that needs to be passed to the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns></returns>
        public jElement one(string eventName, JsDictionary eventData, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Attaches a handler for handling the specified event once on the matched set of elements.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventData">Any data that needs to be passed to the event handler.</param>
        /// <param name="eventHandler">The event handler to be invoked.</param>
        /// <returns></returns>
        public jElement one(string eventName, JsDictionary eventData, jQueryEventHandlerWithContext eventHandler) {
            return null;
        }

        /// <summary>
        /// Gets a new jElement containing the parents of each of the matched elements.
        /// </summary>
        /// <returns>The new jElement.</returns>
        public jElement parent() {
            return null;
        }

        /// <summary>
        /// Gets a new jElement containing the parents of each of the matched elements,
        /// filtered by the specified selector.
        /// </summary>
        /// <param name="selector">The selector to match elements.</param>
        /// <returns>The new jElement.</returns>
        public jElement parent(string selector) {
            return null;
        }

        /// <summary>
        /// Prepend content to the beginning of each element of the matching elements.
        /// </summary>
        /// <param name="content">The content to prepend.</param>
        /// <returns>The current jElement</returns>
        public jElement prepend(string content) {
            return null;
        }

        /// <summary>
        /// Prepend content to the beginning of each element of the matching elements.
        /// </summary>
        /// <param name="content">The DOM element to prepend.</param>
        /// <returns>The current jElement</returns>
        public jElement prepend(Element content) {
            return null;
        }

        /// <summary>
        /// Prepend content to the beginning of each element of the matching elements.
        /// </summary>
        /// <param name="content">The DOM elements to prepend.</param>
        /// <returns>The current jElement</returns>
        public jElement prepend(Element[] content) {
            return null;
        }

        /// <summary>
        /// Prepend content to the beginning of each element of the matching elements.
        /// </summary>
        /// <param name="content">The jElement containing the content.</param>
        /// <returns>The current jElement</returns>
        public jElement prepend(jElement content) {
            return null;
        }

        /// <summary>
        /// Prepend content returned from the specified function to the beginning of each element
        /// of the matching elements.
        /// </summary>
        /// <param name="contentFunction">The function that returns the content to prepend.</param>
        /// <returns>The current jElement</returns>
        public jElement prepend(StringFunction contentFunction) {
            return null;
        }

        /// <summary>
        /// Prepend content returned from the specified function to the beginning of each element
        /// of the matching elements.
        /// </summary>
        /// <param name="contentFunction">The function that returns the content to prepend.</param>
        /// <returns>The current jElement</returns>
        public jElement prepend(StringFunctionWithContext contentFunction) {
            return null;
        }

        /// <summary>
        /// Prepend content returned from the specified function to the beginning of each element
        /// of the matching elements.
        /// </summary>
        /// <param name="contentFunction">The function that returns the content to prepend.</param>
        /// <returns>The current jElement</returns>
        public jElement prepend(StringReplaceFunction contentFunction) {
            return null;
        }

        /// <summary>
        /// Prepend content returned from the specified function to the beginning of each element
        /// of the matching elements.
        /// </summary>
        /// <param name="contentFunction">The function that returns the content to prepend.</param>
        /// <returns>The current jElement</returns>
        public jElement prepend(StringReplaceFunctionWithContext contentFunction) {
            return null;
        }

        /// <summary>
        /// Sets the value of the specified property to the specified value on
        /// the matched set of elements.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The value to set the property to.</param>
        /// <returns>The value of the specified property.</returns>        
        public string prop(string propertyName, object value) {
            return null;
        }

        /// <summary>
        /// Removes the matched elements from the DOM, and removes jQuery data from elements.
        /// </summary>
        /// <returns>The current jElement.</returns>
        public jElement remove() {
            return null;
        }

        /// <summary>
        /// Removes the matching elements from the DOM, and removes jQuery data from elements.
        /// </summary>
        /// <param name="selector">The selector to use to filter the elements to remove.</param>
        /// <returns>The current jElement.</returns>
        public jElement remove(string selector) {
            return null;
        }

        /// <summary>
        /// Removes the specified attribute from each of the set of matched elements.
        /// </summary>
        /// <param name="attributeName">The attribute to remove.</param>
        /// <returns>The current jElement.</returns>
        public jElement removeAttr(string attributeName) {
            return null;
        }

        /// <summary>
        /// Removes all classes from each of the set of matched elements.
        /// </summary>
        /// <returns>The current jElement.</returns>
        public jElement removeClass() {
            return null;
        }

        /// <summary>
        /// Removes the CSS class returned by the specified function.
        /// </summary>
        /// <param name="className">The class or classes to remove.</param>
        /// <returns>The current jElement.</returns>
        public jElement removeClass(string className) {
            return null;
        }

        /// <summary>
        /// Removes the class returned from the specified function for each of the set of matched elements.
        /// </summary>
        /// <param name="cssFunction">The function that returns the CSS class to remove.</param>
        /// <returns>The current jElement.</returns>
        public jElement removeClass(StringFunction cssFunction) {
            return null;
        }

        /// <summary>
        /// Removes the class returned from the specified function for each of the set of matched elements.
        /// </summary>
        /// <param name="cssFunction">The function that returns the CSS class to remove.</param>
        /// <returns>The current jElement.</returns>
        public jElement removeClass(StringFunctionWithContext cssFunction) {
            return null;
        }

        /// <summary>
        /// Removes the class returned from the specified function for each of the set of matched elements.
        /// </summary>
        /// <param name="cssFunction">The function that returns the CSS class to remove.</param>
        /// <returns>The current jElement.</returns>
        public jElement removeClass(StringReplaceFunction cssFunction) {
            return null;
        }

        /// <summary>
        /// Removes the class returned from the specified function for each of the set of matched elements.
        /// </summary>
        /// <param name="cssFunction">The function that returns the CSS class to remove.</param>
        /// <returns>The current jElement.</returns>
        public jElement removeClass(StringReplaceFunctionWithContext cssFunction) {
            return null;
        }

        /// <summary>
        /// Removes all the data from the matching set of elements.
        /// </summary>
        /// <returns>The current jElement.</returns>
        public jElement removeData() {
            return null;
        }

        /// <summary>
        /// Removes the specified data from the matching set of elements.
        /// </summary>
        /// <param name="key">The name of the value to remove.</param>
        /// <returns>The current jElement.</returns>
        public jElement removeData(string key) {
            return null;
        }

        /// <summary>
        /// Replace each element in the set of matched elements with the provided new content.
        /// </summary>
        /// <param name="content">The HTML to wrap with.</param>
        /// <returns>The current jElement.</returns>
        public jElement replaceWith(string content) {
            return null;
        }

        /// <summary>
        /// Replace each element in the set of matched elements with the new content provided
        /// by the specified element.
        /// </summary>
        /// <param name="content">The element containing the HTML to use.</param>
        /// <returns>The current jElement.</returns>
        public jElement replaceWith(Element content) {
            return null;
        }

        /// <summary>
        /// Replace each element in the set of matched elements with the new content provided
        /// by the specified set of matched elements.
        /// </summary>
        /// <param name="content">The object containing the HTML to use.</param>
        /// <returns>The current jElement.</returns>
        public jElement replaceWith(jElement content) {
            return null;
        }

        /// <summary>
        /// Replace each element in the set of matched elements with the content returned from
        /// the specified function.
        /// </summary>
        /// <param name="contetntFunction">The functio returning the HTML to replace with.</param>
        /// <returns>The current jElement.</returns>
        public jElement replaceWith(StringFunction contetntFunction) {
            return null;
        }

        /// <summary>
        /// Replace each element in the set of matched elements with the content returned from
        /// the specified function.
        /// </summary>
        /// <param name="contetntFunction">The functio returning the HTML to replace with.</param>
        /// <returns>The current jElement.</returns>
        public jElement replaceWith(StringFunctionWithContext contetntFunction) {
            return null;
        }

        /// <summary>
        /// Sets the text content of the matched set of elements.
        /// </summary>
        /// <param name="text">The new text to set.</param>
        /// <returns>The current jElement.</returns>
        public jElement text(string text) {
            return null;
        }

        /// <summary>
        /// Sets the text content of the matched set of elements by calling the specified
        /// function.
        /// </summary>
        /// <param name="textFunction">The function that returns the text content.</param>
        /// <returns>The current jElement.</returns>
        public jElement text(StringFunction textFunction) {
            return null;
        }

        /// <summary>
        /// Sets the text content of the matched set of elements by calling the specified
        /// function.
        /// </summary>
        /// <param name="textFunction">The function that returns the text content.</param>
        /// <returns>The current jElement.</returns>
        public jElement text(StringFunctionWithContext textFunction) {
            return null;
        }

        /// <summary>
        /// Sets the text content of the matched set of elements by calling the specified
        /// function.
        /// </summary>
        /// <param name="textFunction">The function that returns the text content.</param>
        /// <returns>The current jElement.</returns>
        public jElement text(StringReplaceFunction textFunction) {
            return null;
        }

        /// <summary>
        /// Sets the text content of the matched set of elements by calling the specified
        /// function.
        /// </summary>
        /// <param name="textFunction">The function that returns the text content.</param>
        /// <returns>The current jElement.</returns>
        public jElement text(StringReplaceFunctionWithContext textFunction) {
            return null;
        }

        /// <summary>
        /// Returns the matching set of elements as an array.
        /// </summary>
        /// <returns>An array containing the matched elements.</returns>
        public Element[] ToArray() {
            return null;
        }


        /// <summary>
        /// Toggles the specified class from each of the set of matched elements.
        /// </summary>
        /// <param name="className">The class to toggle.</param>
        /// <returns>The current jElement.</returns>
        public jElement toggleClass(string className) {
            return null;
        }

        /// <summary>
        /// Toggles the class returned from the function for the set of matched elements.
        /// </summary>
        /// <param name="cssFunction">The function returning the class to toggle.</param>
        /// <returns>The current jElement.</returns>
        public jElement toggleClass(StringFunction cssFunction) {
            return null;
        }

        /// <summary>
        /// Toggles the class returned from the function for the set of matched elements.
        /// </summary>
        /// <param name="cssFunction">The function returning the class to toggle.</param>
        /// <returns>The current jElement.</returns>
        public jElement toggleClass(StringFunctionWithContext cssFunction) {
            return null;
        }

        /// <summary>
        /// Toggles the class returned from the function for the set of matched elements.
        /// </summary>
        /// <param name="cssFunction">The function returning the class to toggle.</param>
        /// <returns>The current jElement.</returns>
        public jElement toggleClass(StringReplaceFunction cssFunction) {
            return null;
        }

        /// <summary>
        /// Toggles the class returned from the function for the set of matched elements.
        /// </summary>
        /// <param name="cssFunction">The function returning the class to toggle.</param>
        /// <returns>The current jElement.</returns>
        public jElement toggleClass(StringReplaceFunctionWithContext cssFunction) {
            return null;
        }

        /// <summary>
        /// Triggers the first event handler attached for the first matched element.
        /// This does not trigger the default DOM behavior of the event.
        /// </summary>
        /// <param name="eventName">The event to trigger.</param>
        /// <returns>The result of the event handler.</returns>
        public object triggerHandler(string eventName) {
            return null;
        }

        /// <summary>
        /// Triggers the first event handler attached for the first matched element.
        /// This does not trigger the default DOM behavior of the event.
        /// </summary>
        /// <param name="eventName">The event to trigger.</param>
        /// <param name="eventParameters">Additional parameters for the event handler.</param>
        /// <returns>The result of the event handler.</returns>
        public object triggerHandler(string eventName, object[] eventParameters) {
            return null;
        }

        /// <summary>
        /// Removes all event handlers attached to the matched set of elements
        /// </summary>
        /// <returns>The current jElement.</returns>
        public jElement unbind() {
            return null;
        }

        /// <summary>
        /// Detaches a handler for the specified event on the matched set of elements.
        /// </summary>
        /// <param name="eventName">The event to detach handlers for.</param>
        /// <returns>The current jElement.</returns>
        public jElement unbind(string eventName) {
            return null;
        }

        /// <summary>
        /// Detaches a handler for the specified event on the matched set of elements.
        /// </summary>
        /// <param name="e">The event passed in into an event handler.</param>
        /// <returns>The current jElement.</returns>
        public jElement unbind(jQueryEvent e) {
            return null;
        }

        /// <summary>
        /// Detaches a handler for the specified event on the matched set of elements.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventHandler">The event handler to be detached.</param>
        /// <returns>The current jElement.</returns>
        public jElement unbind(string eventName, jQueryEventHandler eventHandler) {
            return null;
        }

        /// <summary>
        /// Detaches a handler for the specified event on the matched set of elements.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="eventHandler">The event handler to be detached.</param>
        /// <returns>The current jElement.</returns>
        public jElement unbind(string eventName, jQueryEventHandlerWithContext eventHandler) {
            return null;
        }

        /// <summary>
        /// Detaches the "return false" handler that was bound earlier.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="result">Should be false.</param>
        /// <returns>The current jElement.</returns>
        public jElement unbind(string eventName, bool result) {
            return null;
        }

        /// <summary>
        /// Sets the value attribute of the matched set of elements.
        /// </summary>
        /// <param name="value">The new value to set.</param>
        /// <returns>The current jElement.</returns>        
        public jElement val(string value) {
            return null;
        }

        /// <summary>
        /// Sets the value attribute of the matched set of elements using values returned
        /// from the specified function.
        /// </summary>
        /// <param name="valueFunction">The function returning the values to set.</param>
        /// <returns>The current jElement.</returns>        
        public jElement val(StringFunction valueFunction) {
            return null;
        }

        /// <summary>
        /// Sets the value attribute of the matched set of elements using values returned
        /// from the specified function.
        /// </summary>
        /// <param name="valueFunction">The function returning the values to set.</param>
        /// <returns>The current jElement.</returns>        
        public jElement val(StringFunctionWithContext valueFunction) {
            return null;
        }

        /// <summary>
        /// Sets the value attribute of the matched set of elements using values returned
        /// from the specified function.
        /// </summary>
        /// <param name="valueFunction">The function returning the values to set.</param>
        /// <returns>The current jElement.</returns>        
        public jElement val(StringReplaceFunction valueFunction) {
            return null;
        }

        /// <summary>
        /// Sets the value attribute of the matched set of elements using values returned
        /// from the specified function.
        /// </summary>
        /// <param name="valueFunction">The function returning the values to set.</param>
        /// <returns>The current jElement.</returns>        
        public jElement val(StringReplaceFunctionWithContext valueFunction) {
            return null;
        }

        /// <summary>
        /// Wraps an HTML structure around each of the matched set of elements.
        /// </summary>
        /// <param name="htmlSnippet">The HTML to wrap with.</param>
        /// <returns>The current jElement.</returns>
        public jElement wrap(string htmlSnippet) {
            return null;
        }

        /// <summary>
        /// Wraps a DOM element around each of the matched set of elements.
        /// </summary>
        /// <param name="element">A DOM element specifying the structure.</param>
        /// <returns>The current jElement.</returns>
        public jElement wrap(Element element) {
            return null;
        }

        /// <summary>
        /// Wraps a jElement around each of the matched set of elements.
        /// </summary>
        /// <param name="element">A jElement specifying the structure.</param>
        /// <returns>The current jElement.</returns>
        public jElement wrap(jElement element) {
            return null;
        }

        /// <summary>
        /// Wraps an HTML structure around each of the matched set of elements as
        /// returned from the specified wrapping function.
        /// </summary>
        /// <param name="wrappingFunction">The functio returning the HTML to wrap with.</param>
        /// <returns>The current jElement.</returns>
        public jElement wrap(StringFunction wrappingFunction) {
            return null;
        }

        /// <summary>
        /// Wraps an HTML structure around each of the matched set of elements as
        /// returned from the specified wrapping function.
        /// </summary>
        /// <param name="wrappingFunction">The functio returning the HTML to wrap with.</param>
        /// <returns>The current jElement.</returns>
        public jElement wrap(StringFunctionWithContext wrappingFunction) {
            return null;
        }
        #endregion
   }      
}

