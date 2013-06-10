using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;

namespace TestAngularJS
{                           
   public class ResourceExample
   {
      public static void Main()
      {
         Module app = new Module("myApp","ngResource");
         app.Controller<ResourceExampleController>();
      }      
   }

   public class Person : IResourceObject
   {
      public int id;
      public string name;
   }
   
   public class ResourceExampleController
   {
      // injectables
      public Resource resource;

      // scope
      public string all_is_ok;
      public Person persona;      
                
      public ResourceObject myres;

      public ResourceExampleController(Scope _scope, Resource _resource)
      {
         // save injectables
         resource = _resource;
         
         var parms = new { userId="@id" };
        
         ResourceActions actions = new ResourceActions();
         actions.Add("fetch","GET",false);
        
         myres = resource.Create("/api/person/:userId",null,actions);

         all_is_ok = "OK!";            
      }

      public void prova()
      {
         //persona = myres.Get<Person>(new {userId=10}, succ, err);
         persona = myres.Action<Person>("fetch", new {userId=10}, succ, err);

         persona.Action("fetch");
      }

      public void getok()
      {
         System.Diagnostics.Debug.Break();
      }

      public void succ(Person p, HttpResponseHeaders rh)
      {
         Window.Alert(p.name);
      }

      public void err(HttpResponse rh)
      {         
         Window.Alert(rh.Status);
      }
   }
}
