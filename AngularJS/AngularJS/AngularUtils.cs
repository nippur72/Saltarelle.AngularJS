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
   public class ServiceEntry
   {
      public string name;
      public Type type;
   }

   public static class AngularUtils
   {                  
      public static Dictionary<string,List<ServiceEntry>> Dict = new Dictionary<string,List<ServiceEntry>>();     

      private static List<object> InjectionSyntax(Module module, MethodInfo mi, Type ct)
      {
         List<string> miParameterNames = scanparms(mi.CreateDelegate());
         List<object> NamedParameters = new List<object>();
         
         List<ServiceEntry> services = Dict[module.Name];
                                             
         for(int j=0;j<mi.ParameterTypes.Length;j++)     
         {
            Type t = mi.ParameterTypes[j];               
            bool found = false;
            for(int i=0;i<services.Count;i++)
            {
               if(t==services[i].type || IsSubclassOf(t,services[i].type))
               {  
                  if(services[i].name.StartsWith("$") || (!services[i].name.StartsWith("$") && services[i].name==miParameterNames[j]))
                  NamedParameters.Add(services[i].name);
                  found = true;
                  break;
               }
            }                        

            if(!found) throw new Exception("controller named parameter '"+miParameterNames[j]+"' of type '"+t.ToString()+"' not recognized");
         }   
         
         List<object> wr = new List<object>();
                                                                                                  
         foreach(string s in NamedParameters) wr.Add(s);

         object x = mi.CreateDelegate();                           
         wr.Add(x);          
         return wr;                
      }

      [InlineCode("scanparms({fn})")]
      private static List<string> scanparms(object fn)
      {
         return null;
      }

      [InlineCode("ss.isSubclassOf({target},{type})")]
      private static bool IsSubclassOf(Type target, Type type)
      {
         return false;
      }

      public static void Register(this Module module)
      {
         List<ServiceEntry> serv = new List<ServiceEntry>();
         serv.Add( new ServiceEntry() { name="$scope",         type=typeof(Scope)         } );
         serv.Add( new ServiceEntry() { name="$rootscope",     type=typeof(RootScope)     } );
         serv.Add( new ServiceEntry() { name="$http",          type=typeof(Http)          } );
         serv.Add( new ServiceEntry() { name="$location",      type=typeof(Location)      } );
         serv.Add( new ServiceEntry() { name="$routeProvider", type=typeof(RouteProvider) } );
         serv.Add( new ServiceEntry() { name="$routeParams",   type=typeof(RouteParams)   } );
         Dict.Add(module.Name,serv);          
      }
             
      public static void RegisterControllers(this Module module, object controllers)
      {
         Type ct = controllers.GetType();

         BindingFlags bf = BindingFlags.Static | BindingFlags.Public;
         
         foreach(MethodInfo mi in ct.GetMethods(bf))
         {
            var wr = InjectionSyntax(module, mi, ct);
            module.Controller(mi.Name,wr);         
         }
      }

      public static void RegisterFactory(this Module module, object factory)
      {
         Type ft = factory.GetType();

         BindingFlags bf = BindingFlags.Static | BindingFlags.Public;
         
         foreach(MethodInfo mi in ft.GetMethods(bf))
         {
            RegisterSingleFactory(module, mi, ft);
         }
      }      

      private static void RegisterSingleFactory(Module module, MethodInfo mi, Type ft)
      {
         string factoryname = mi.Name;
         Type returntype = mi.ReturnType;

         var services = Dict[module.Name];

         services.Add(new ServiceEntry(){name=factoryname, type=returntype});

         var wr = InjectionSyntax(module, mi, ft);
         module.Factory(factoryname, wr);         
      }

      public static void RegisterFilters(this Module module, object filter)
      {
         Type ft = filter.GetType();

         BindingFlags bf = BindingFlags.Static | BindingFlags.Public;

         foreach(MethodInfo mi in ft.GetMethods(bf))
         {
            RegisterFilter(module, mi, ft);
         }
      }      

      private static void RegisterFilter(Module module, MethodInfo mi, Type ft)
      {
         string filtername = mi.Name;
         Type returntype = mi.ReturnType;
         
         //var wr = InjectionSyntax(module, mi, ft);
         // TODO: support injectable filters
         var wr = mi.CreateDelegate();
         module.FilterAll(filtername, wr);         
      }

      public static void RegisterConfig(this Module module, object config)
      {
         Type ct = config.GetType();

         BindingFlags bf = BindingFlags.Static | BindingFlags.Public;
         
         foreach(MethodInfo mi in ct.GetMethods(bf))
         {
            var wr = InjectionSyntax(module, mi, ct);
            module.Config(wr);         
         }
      }      

      public static void RegisterDirectives(this Module module, object directives)
      {
         Type ct = directives.GetType();

         BindingFlags bf = BindingFlags.Static | BindingFlags.Public;
         
         foreach(MethodInfo mi in ct.GetMethods(bf))
         {
            var wr = InjectionSyntax(module, mi, ct);
            module.Directive(mi.Name,wr);         
         }
      }
   }
}

