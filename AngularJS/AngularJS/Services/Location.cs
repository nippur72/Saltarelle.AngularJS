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
   public sealed class LocationProvider
   {
      [InlineCode("{this}.html5Mode({mode})")]    public LocationProvider Html5Mode(bool mode)      { return null; }
      [InlineCode("{this}.hashPrefix({prefix})")] public LocationProvider HashPrefix(string prefix) { return null; }
   }

   [Imported]
   public sealed class Location
   {
      /// <summary>
      /// Returns full url representation with all segments encoded according to rules specified in RFC 3986.
      /// </summary>
      public string AbsUrl
      {
         [InlineCode("{this}.absUrl()")]        get { return ""; }         
      }

      /// <summary>
      /// Sets or returns the hash fragment
      /// </summary>
      public string Hash
      {         
         [InlineCode("{this}.hash()")]        get { return ""; }         
         [InlineCode("{this}.hash({value})")] set { }
      }

      /// <summary>
      /// Returns host of current url.
      /// </summary>
      public string Host
      {
         [InlineCode("{this}.host()")]        get { return ""; }         
      }

      /// <summary>
      /// Sets or returns path of current url 
      /// </summary>
      public string Path
      {         
         [InlineCode("{this}.path()")]        get { return ""; }         
         [InlineCode("{this}.path({value})")] set { }
      }

      /// <summary>
      /// Returns port of current url.
      /// </summary>
      public int Port
      {
         [InlineCode("{this}.port()")] get { return 0; }         
      }


      /// <summary>
      /// Returns protocol of current url.
      /// </summary>
      public string Protocol
      {
         [InlineCode("{this}.protocol()")] get { return null; }         
      }

      /// <summary>
      /// If called, all changes to $location during current $digest will be replacing current history record, instead of adding new one.
      /// </summary>
      [InlineCode("{this}.replace()")] 
      public void Replace()
      {
      }

      /// <summary>
      /// Sets or returns path of current url 
      /// </summary>
      public JsDictionary<string,string> Search
      {         
         [InlineCode("{this}.search()")] 
         get 
         { 
            return null; 
         }  
         [InlineCode("{this}.search({value})")] 
         set
         {
            
         }                
      }

      [InlineCode("{this}.search({search})")] public string SetSearch(string search) { return null; }
      [InlineCode("{this}.search({search})")] public string SetSearch(object search) { return null; }
      [InlineCode("{this}.search({search})")] public string SetSearch(JsDictionary<string,string> search) { return null; }

      [InlineCode("{this}.search({search},{paramValue})")] public string SetSearch(string search, string paramValue) { return null; }
      [InlineCode("{this}.search({search},{paramValue})")] public string SetSearch(object search, string paramValue) { return null; }
      [InlineCode("{this}.search({search},{paramValue})")] public string SetSearch(JsDictionary<string,string> search, string paramValue) { return null; }

      /// <summary>
      /// Sets or returns url
      /// </summary>
      public string Url
      {         
         [InlineCode("{this}.url()")]        get { return ""; }         
         [InlineCode("{this}.url({value})")] set { }
      }      
   }
}

