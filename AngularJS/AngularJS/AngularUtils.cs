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
   public static class TypeExtensionMethods
   {
      public static List<string> GetPublicInstanceMethodNames(this Type type)
      {
         List<string> result = new List<string>();
         foreach(string key in type.Prototype.Keys)
         {
            if(key!="constructor" && !key.StartsWith("$")) result.Add(key);
         }   
         return result;
      }

      public static Function GetConstructorFunction(this Type type)
      {         
         return (Function) type.Prototype["constructor"];                 
      }

      [InlineCode("{type}.$inject")]      
      public static List<string> ReadInjection(this Type type)
      {
         return null;
      }      

      [InlineCode("{type}[{funcname}]")]
      public static Function GetKey(this Type type, string funcname) { return null; }
   }

   #region Comment explaining how classes are turned into function controllers
   /*
   public class ControllerClass
   {
      public string a;

      public ControllerClass(Scope _scope, Http _http)
      {
         a = "done";
      }

      public void remove(int index) { ... }

      public void clear() { ... }

      public static List<string> Items(Http _http) { return ...; }
   }

   // as controller: requires $scope as first parameter, inject derived from constructor
   function($scope)
   {
      $scope.remove = ControllerClass.prototype.remove.bind($scope);
      $scope.clear = ControllerClass.prototype.clear.bind($scope);
      ControllerExample.apply($scope,arguments);  // this = $scope
   }

   // as config: does not require $scope as first parameter, inject derived from constructor
   function()
   {
      this.remove = ControllerClass.prototype.remove.bind(this);
      this.clear = ControllerClass.prototype.clear.bind(this);
      ControllerExample.apply(this,arguments);  
   }

   // as factory: static methods are registered one by one, with their own injection
   function(_http)
   {
   }

   // as filter: does not require $scope as first parameter, inject derived from constructor, each method is mapped separately 
   function()
   {
      this.euro = FilterEuro.prototype.bind(this);
      FilterEuro.apply(this,arguments);
      return this.euro;
   }

   */
   #endregion

   public static class AngularUtils
   {        
      #region old code (to delete)
      /*
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
      */

      /*
      [InlineCode("scanparms({fn})")]
      private static List<string> scanparms(object fn)
      {
         return null;
      }

      [InlineCode("scanparms({fn})")]
      private static List<string> scanparms(Function fn)
      {
         return null;
      }
      */
      
      /*
      [InlineCode("ss.isSubclassOf({target},{type})")]
      private static bool IsSubclassOf(Type target, Type type)
      {
         return false;
      }

      public static bool IsOverridenMethod(object derivedtype, string methodname, Type basetype)
      {         
         dynamic thisfn = ((dynamic)derivedtype)[methodname];
         dynamic basefn = ((dynamic)basetype).prototype[methodname];
         return thisfn != basefn;
                  
         // using Reflection
         //Type t1 = derivedtype.GetMethod(methodname).DeclaringType;
         //Type t2 = basetype;
         //return (t1 != t2);
                  
      }       
      */

      /*
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
             
      public static void Old_RegisterControllers(this Module module, object controllers)
      {
         Type ct = controllers.GetType();

         BindingFlags bf = BindingFlags.Static | BindingFlags.Public;
         
         foreach(MethodInfo mi in ct.GetMethods(bf))
         {
            var wr = InjectionSyntax(module, mi, ct);
            module.Controller(mi.Name,wr);         
         }
      }

      public static void OldRegisterClassController(this Module module, Type ct, string name)
      {
         //var wr = InjectionSyntax(module, mi, ct);
         List<object> wr = new List<object>();
         wr.Add("$scope");
         wr.Add("Items");
         wr.Add(ct);
         module.Controller(name,wr);                  
      }*/
                       /*
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
      }                       */

      /*public static void RegisterFilters(this Module module, object filter)
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
      
      public static List<object> BuildInjection(Module module, Type type)
      {
         var services = Dict[module.Name];

         var parameters = scanparms(type);
          
         List<object> injection_array = new List<object>();
         for(int t=0;t<parameters.Count;t++)
         {
            string name = parameters[t].ToLower();                    
            bool found = false;
            for(int i=0;i<services.Count;i++)
            {
               string sname = services[i].name.ToLower();
               if(sname.StartsWith("$")) sname = sname.Substring(1);
               if(sname==name)
               {
                  injection_array.Add(services[i].name);
                  found = true;
                  break;
               }
            }                        

            if(!found) throw new Exception(String.Format("Controller '{0}' parameter '{1}' not recognized",type.Name,name));
         }   
         
         return injection_array;
      }
      */
      #endregion                    

      #region Function builder

      public static Function BuildFunction(Type type, bool this_is_scope, string return_function=null)
      {
         string thisref = this_is_scope ? "$scope" : "this";
         string body = "";
                                             
         Function consutructor = type.GetConstructorFunction();               
         var parameters = Injector.Annotate(consutructor);
         
         // verifies that "scope" is the first parameter in constructor
         if(this_is_scope)
         {
            if(parameters.Count<1 || parameters[0]!="_scope")
            {
               throw new Exception(String.Format("Controller {0} must specify '_scope' as first parameter",type.Name));
            }
         }
                  
         // takes method into $scope, binding "$scope" to "this"                 
         foreach(string funcname in type.GetPublicInstanceMethodNames())
         {
            body += String.Format("{2}.{1} = {0}.prototype.{1}.bind({2});\r\n",type.FullName,funcname,thisref);             
         }
                  
         // put call at the end so that methods are defined first
         body+=String.Format("{0}.apply({1},arguments);\r\n",type.FullName,thisref);

         if(return_function!=null)
         {
            body+=String.Format("return {1}.{0};\r\n",return_function,thisref);   
            if(!type.GetPublicInstanceMethodNames().Contains(return_function))
            {
               throw new Exception("function '"+return_function+"' not defined");
            }
         }

         // build controller function         
         if(this_is_scope) return new Function("$scope",body);
         else return new Function(body);
      }

      #endregion

      #region Controllers
      /*
      public static Function CreateControllerFromType(Type type)
      {         
         string body = "";
                           
         // verifies that "scope" is the first parameter in constructor
         Function consutructor = type.GetConstructorFunction();               
         var parameters = Injector.Annotate(consutructor);
         if(parameters.Count<1 || parameters[0]!="_scope")
         {
            throw new Exception(String.Format("Controller {0} must specify '_scope' as first parameter",type.Name));
         }
                  
         // takes method into $scope, binding "$scope" to "this"                 
         foreach(string funcname in type.GetPublicInstanceMethodNames())
         {
            body += String.Format("$scope.{1} = {0}.prototype.{1}.bind($scope);\r\n",type.FullName,funcname);             
         }
                  
         // put call at the end so that methods are defined first
         body+=String.Format("{0}.apply($scope,arguments);\r\n",type.FullName);

         // build controller function         
         return new Function("$scope",body);
      }
      */

      public static void RegisterController(this Module module, Type type)
      {
         // TODO
         // if(!type.IsSubClassOf(Scope)) throw new Exception("controller must be derived from Scope class");
         
         //Function cfun = AngularUtils.CreateControllerFromType(type);         
         Function cfun = AngularUtils.BuildFunction(type, true);     

         // reads $inject previously added by CreateControllerFromType
         var inject = type.ReadInjection();         

         var inarr = CreateInjectionArray(inject,cfun);         
         module.Controller(type.Name,inarr);
      }
      
      private static List<object> CreateInjectionArray(List<string> parameters, Function fun) 
      {
         List<object> result = new List<object>();
         for(int t=0;t<parameters.Count;t++)
         {
            if(parameters[t].StartsWith("_")) parameters[t] = "$" + parameters[t].Substring(1);
            result.Add(parameters[t]);
         }                           
         result.Add(fun);
         return result;
      }
      #endregion

      #region Factory

      //
      // Factor is a special case, it does use function builder
      //

      public static void RegisterFactory(this Module module, Type type)
      {         
         // scan class static methods (contained in Object.keys)
         var keys = Object.Keys(type);
                           
         foreach(string funcname in keys)
         {
            // skips reserved and private methods
            if(!funcname.StartsWith("__") && !funcname.StartsWith("$"))
            {
               var fun = type.GetKey(funcname);
               
               // make sure it's a function
               if(fun.GetType()==typeof(Function))
               {                          
                  var parameters = Injector.Annotate(fun);
                  var injarr = CreateInjectionArray(parameters,fun);                   
                  module.Factory(funcname,injarr);                  
               }
            }
         }
      }
      #endregion

      #region Filters
     
      public static void RegisterFilter(this Module module, Type type)
      {
         // annotates constructor
         Function constructor = type.GetConstructorFunction();                 
         var parameters = Injector.Annotate(constructor);

         // register all public instance methods as filters                       
         foreach(string funcname in type.GetPublicInstanceMethodNames())
         {
            module.RegisterFilter(type,funcname);
         }
      }

      private static void RegisterFilter(this Module module, Type type, string funcname)
      {
         Function cfun = AngularUtils.BuildFunction(type,false,funcname);         
         
         var inject = type.ReadInjection();

         var inarr = CreateInjectionArray(inject,cfun);         
         module.Filter(funcname,inarr);
      }

      /*
      private static Function CreateFilterFromType(Type type, string filtername)
      {
         // calls constructor, bindind "$scope" to "this"
         string body = String.Format("this.{1} = {0}.prototype.{1}.bind(this);\r\n",type.FullName,filtername);             
                           
         // put call at the end so that methods are defined first
         body+=String.Format("{0}.apply(this,arguments);\r\n",type.FullName);
         body+=String.Format("return this.{0};\r\n",filtername);

         return new Function(body);
      }
      */

      #endregion
      
      #region Configs

      /*
      public static Function CreateConfigFromType(Type type)
      {         
         string body = "";
                           
         // verifies that "scope" is the first parameter in constructor
         Function constructor = type.GetConstructorFunction();                 
         var parameters = Injector.Annotate(constructor);
                  
         // puth methods as local functions in this
         foreach(string funcname in type.GetPublicInstanceMethodNames())
         {
            body += String.Format("this.{1} = {0}.prototype.{1}.bind(this);\r\n",type.FullName,funcname);             
         }
         
         // put call at the end so that methods are defined first
         body+=String.Format("{0}.apply(this,arguments);\r\n",type.FullName);

         // build controller function         
         return new Function(body);
      }
      */

      public static void RegisterConfig(this Module module, Type type)
      {
         Function cfun = AngularUtils.BuildFunction(type,false);       
         
         var inject = type.ReadInjection();         

         var inarr = CreateInjectionArray(inject,cfun);         
         module.Config(inarr);
      }
      #endregion

      #region Directives

      /*
      public static Function CreateDirectiveControllerFromType(Type type)
      {
         // calls constructor, bindind "$scope" to "this"
         string body = "";
                           
         // verifies that "scope" is the first parameter in constructor
         Function constructor = type.GetConstructorFunction();                 
         var parameters = Injector.Annotate(constructor);
                           
         foreach(string funcname in type.GetPublicInstanceMethodNames())
         {
            body += String.Format("this.{1} = {0}.prototype.{1}.bind(this);\r\n",type.FullName,funcname);             
         }
         
         // put call at the end so that methods are defined first
         body+=String.Format("{0}.apply(this,arguments);\r\n",type.FullName);

         // build controller function         
         return new Function(body);
      }
      */

      public static object DirectiveController(Type type)
      {
         Function cfun = AngularUtils.BuildFunction(type,false);
         var inject = type.ReadInjection(); 
         if(inject.Count==0) return cfun;         
         return AngularUtils.CreateInjectionArray(inject,cfun);       
      }

      /*
      public static void RegisterDirective3(this Module module, DirectiveDefinition dirob)
      {
         module.Directive(dirob.Name, dirob.CreateDefinitionObject());
      }
      */

      public static void RegisterDirective(this Module module, DirectiveDefinition dirob)
      {
         var defob = dirob.CreateDefinitionObject();
         
         module.Directive(dirob.Name, defob);
      }

      #endregion
   }
}

