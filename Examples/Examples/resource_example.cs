using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;
using System.Threading.Tasks;

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

      public async Task<int> Prova()
      {
         int z = await dostuff();
         return z;
      }

      public async Task<int> dostuff()
      {
         return 55;
      }

      public ResourceExampleController(Scope _scope, Resource _resource)
      {
         // save injectables
         resource = _resource;
         
         var parms = new { userId="@id" };
        
         ResourceActionDefinition actions = new ResourceActionDefinition();
         actions.Add("fetch","GET",false);
        
         myres = resource.Create("/api/person/:userId",null,actions);

         all_is_ok = "OK!";            
      }

      public void prova()
      {
         //persona = myres.Get<Person>(new {userId=10}, succ, err);
         
         //persona = myres.Action<Person>("fetch", new {userId=10}, succ, err);

         //persona.Action("fetch");
        
         ResourceRequest<Person> r = new ResourceRequest<Person>(myres);         
         r.Action = "fetch";
         r.Parameters["userId"] = 10;
         r.PostData = null;
         r.Success = succ;
         r.Error = err;
         persona = r.ExecuteRequest();

         persona.Action("save");
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

