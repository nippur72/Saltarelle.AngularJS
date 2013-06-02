# Saltarelle.AngularJS

This is an import library of AngularJS JavaScript framework for the C#-Saltarelle-compiler, allowing to write
AngularJS applications in C# instead of javascript.

At this stage, only the very basic parts of the framework are covered. 

# Reserved names in AngularJS

AngularJS unfortunately names all its object with the `$` prefix (e.g. `$scope`) thus making them not available in C#. To avoid this, 
the `_` underscore character is used in placed of the `$` sign for known objects. The library takes care of translating it back to `$`.
So for example in your C# code you'll write `_scope` instead of `$scope`.

# How to use this library

Saltarelle.AngularJS is not a pure metadata import library, there are some helper functions that are written in C#, so 
it's necessary to link the file `Saltarelle.AngularJS.js`. Copy `Saltarelle.AngularJS.js` from this repo to the `Scripts/`
directory and put a reference like this: 

```HTML
<script src="Scritps/Saltarelle.AngularJS.js"></script>
```

just after after the `mscorlib.js` reference. Also add a reference to `Saltarelle.AngularJS.dll` in your Saltarelle project references.

To make the AngularJS namespace available, in your C# source files add:

```C#
using AngularJS;
```

# Creating an AngularJS module

Create an Angular module to be referenced with the `ng-app` directive:

```C#
Module app = new Module("myApp"); 
```

# Creating an AngularJS Controller

AngularJs controllers are mapped to C# classes and $scope is bound the the class istance itself, so it's very easy to implement a controller and 
reference to $scope is not require. The only requirements are:

- the controller class is derived from the base `Scope` class
- the first parameter of the class constructor is `_scope`

The class name is the the name for the controller that can be later referenced in the
`ng-controller` directive. For example:

```C#
public class ShoppingCartControllers : Scope
{     
    public static void CartController(Scope _scope, Timeout _timeout)
    {
	}
}
```

any other parameter in the class constructor will be treated as an injectable parameter 
(in the example above the `$timeout` object is injected). If you want to use any injected 
parameter outside of the constructor, save its reference to a field variable. `$scope`
does not need to be referenced because the whole class is the scope itself (this==_scope)
which makes the code much less verbose than the javascript counterpart.

The class should also declare all objects that are put in the scope. What you refer from
outside C# (e.g. HTML) should be declared with then `public` modifier. For example:

```C#
public class ShoppingCartControllers : Scope
{     
    public List<CartItem> items;
    public double billDiscount;

    public static void CartController(Scope _scope, Timeout _timeout)
    {
	}
}
```

After the class controller is defined you need to register it within the application-module:

```C#
app.RegisterControllers(typeof(ShoppingCartControllers));                                  
```

# Implementing the controller logic

Controller functions are defined as methods, but you can also define them as `Action` or `Func`:

```C#
public void remove(int index)
{
	items.RemoveAt(index);
}
```

or (within the constructor):

```C#
remove = (index) => 
{
	items.RemoveAt(index);
};
```

# Adding a watch 

A watch keeps on listening to a function, and when its value changes another function is called. 

Put the watch in the constructor:

```C#
Watch<double>(()=>totalCart, calculateDiscount);
```

and then define:

```C#
public double calculateDiscount(double newValue, double oldValue)
{
	billDiscount = newValue > 100 ? 10 : 0;
};
```

# Defining a config function

Configs are functions that are called on module initialization. As with controllers, they are written as classes:

```C#
public class MyConfigs
{               
    public MyConfig(/* injectables */)
    {
    }
}                 
```

and then registered with

```C#
app.RegisterConfig(typeof(MyConfigs));
```

# Defining a Service (Factory)

A service (factory) is a function that returns an object resource that can be used in controllers or other parts of Angular and 
that is injected automatically using the service name. 

In the following example the service called "Items" is defined

```C#
public class ItemsFactory
{                
    public ItemsFactory(/* injectables */)
	{

	}

	public List<CartItem> Items()
    {
        var items = new List<CartItem>();
        items.Add( new CartItem() { title="AAAA", quantity= 1024, price= 44.95 } );
        items.Add( new CartItem() { title="BBBB", quantity= 2048, price= 55.95 } );
        return items;
    }
}    
```

and then registered with:

```C#
app.RegisterFactory(typeof(ItemsFactory));
```

once the factory is registered, it can be used in any angular function by refering its name ("Items"). For example you can define a controller:

# Defining a filter

A filter is a function that formats data that is used in HTML templates. For example the following filter adds the word "dollars" to a numeric value:

```C#
public class CartFilters
{                
    public Filters(/* injectables */)
	{
	}
	public string dollars(double input)
    {
        return input.ToString() + " dollars";
    }
}                 
```

and then registered with:

```C#
app.RegisterFilters(typeof(CartFilters);  
```

and in HTML template:

```HTML
<span>{{amount | dollars }}<span>
```

# Working with Http

Http is a pre-defined service ($http) that helps working with http requests, e.g. for RESTful services. There are methods for Get, Post, Put, Delete, Head and Jsonp. 

The result of Http requests are `HttpPromise`s that can be chained:

```C#
public PhoneListController
{
	List<string> items;

	public PhoneListController(PhoneScope _scope, Http _http)
	{
		http.Get("items.json").Success((data,status)=> {
			items = data;
		}).Error((data,status)=>{ 
			Window.Alert("error!");
		});
	}
}   
```

# Working with the $route service to define application routing and views

The `RouteProvider` service can be used to define the client-side application routings that are 
mapped to views that are rendered under the `ng-view` directive.

```C#
public class ConfigRoute
{
	public ConfigRoute(RouteProvider _routeProvider)
	{
		routeProvider.when("/phones"          , new RouteMap() { TemplateUrl = "phonemain.html"   })
					 .when("/phones/:phoneId" , new RouteMap() { TemplateUrl = "phonedetail.html" })
					 .otherwise(                new RouteMap() { RedirectTo  = "/phones"          });
	}
}
```

phonedetail.html contains only the partial view to be rendered within the `ng-view` directive:

```HTML
<div ng-controller="PhoneListControllerDetail">   
   <p>phoneId parameter is {{ phoneId }}</p>
</div>
```

# Working with directives

Directive in AngularJS are the most difficult part to understand, but thanks to C# and to an helper function everything becomes very simple.

Directives are defined by deriving an object from `DirectiveDefinition` and filling its content. For example:

```C#
public class HelloDirective : DirectiveDefinition
{
    public HelloDirective()
    {                  
        Name = "hello";
        Restrict = RestrictFlags.Element;
        Template = "<div>Hello <span ng-transclude></span>!</div>";
        Replace = true;         
        Transclude = true;         
    }           
}      
```

defines a directive called "hello", that applies to elements (result will be `<hello>`) with the given template.

Some concepts about directives:

- they can have their own scope, or inerhit from parent
- they can have their own controller for implementing the logic of the directive
- they can have a "shared" controller that other elements can reference (for example netsted elements can register into a common controller)

(to be continued)
 
# The C# paradigm

(...)