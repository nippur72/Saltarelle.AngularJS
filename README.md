# Saltarelle.AngularJS

Angular.JS for C#

## Contents

- [What is](#whatis)
- [Current state](#currentstate)
- [Getting started](#gettingstarted)
- [Member casing](#membercasing)
- [Differences between C# and Javascript](#differences)
- [Creating a directive](README.Directives.md)
   - Reserved names ($)
   - Dependency injection
   - Creating a module
- Creating a controller
- Creating a config
- Creating a factory
- Creating a service
- Creating a filter
- Using watches

<a name="whatis"></a>
## What is

Saltarelle.AngularJS is a library written for the [Saltarelle](www.saltarelle-compiler.com) C#-to-javascript compiler that allows to 
use the [AngularJS](angularjs.org) framework from the C# language, making it possible to write C# client side web applications.

Other than providing an interface to AngularJS, the library also makes Angular more C# friendly, trying to make it look
as if it was designed for C# and not Javascript.

<a name="currentstate"></a>
## Current state

As of now, only the main features of the latest angular release are covered, tough more and more are costantly added. 
If you want to contribute, write a pull request or file a request under the issue section.

## Getting started

To start using the library in your C# project (Visual Studio assumed) do the following steps: 

- add a reference to `Saltarelle.AngularJS.dll` (contained in this repo) in your C#-Saltarelle project.
- put the file `Saltarelle.AngularJS.js` (contained in this repo) in your website script folder, and 

as long as `angular.js` and it related files.
- Put a `<script>` reference to `Saltarelle.AngularJS.js` in your HTML page, just after the `mscorlib.js` reference.

Differently from Javascript, the Angular application needs to be called explicitly, that is, you have to call
the method that contains the app initialization. For example if you have defined a static method called `Main()`, 
in your HTML page add something like this:

```JavaScript
<script type="text/javascript">MyAppNameSpace.MyApp.Main();</script>     
```

Don't forget make the AngularJS namespace available in your C# code by adding:

```C#
using AngularJS;
```

<a name="membercasing"></a>
## Member casing

By default the Saltarelle compiler is configured to translate to Javascript casing (eg "ToString()" is converted into "toString()"),
which can be source of mistakes when you reference your C# objects from the HTML markup. To avoid case mismatches, it's suggested to add the
following global attribute declaration in your `Assembly.cs` file:

```
[assembly: PreserveMemberCase]
```

<a name="differences"></a>
## Differences between C# and Javascript

There are some differences between the AngularJS C# implementation and its Javascript counterpart, mostly due to inherent differences between the two languages, 
C# and Javascript. 

### Classes instead of nested functions

Angular makes intensive use of nested functions (functions containing functions) which are used to manage dependency injection in controllers, services 
and other components. Typically an outer function receives injected objects as function's parameters which are thus available to be referenced withing
inner functions. 

Unfortunately the C# equivalent of this schema results in a clumsy use of function delegates and lambda expressions that is
too impractical for real coding. 

For this reason a different approach is used in C#: 
- controllers, services and all other angular components are written as classes instead of functions
- the class constructor receives the injectable objects as parameters (the same way the "outer" function does in javascript)
- to make injectable objects available to the methods of the class, the constructor needs to save them in field members

Example:

in Javascript:

```Javascript
function outer($scope,$http)
{
	function inner()
	{
	   // use $http here
	}
}
```

in C#:

```C#
public class outer
{
	// save injectables
	Http http;

	public outer(Scope _scope, Http _http)
	{
		this.http = _http;	// since _http is referenced in "inner" we save it locally
	}

	public void inner()
	{
	   // use http here 
	}
}
```

### Scope aumatically bound to controllers

In C# the `$scope` object is bound to the controller class (in other words, it's `this`) so there is no need to make direct reference to the scope. 
This is a good advantage that makes code much more readable than its Javascript equivalent.

# Reserved names in AngularJS

AngularJS unfortunately names all its object with the `$` prefix (e.g. `$scope`) thus making them not available in C#. To avoid this, 
the `_` underscore character is used in placed of the `$` sign when declaring parameters for dependency injection. The library takes care 
of translating it back to `$`. So for example in your C# code you'll write `_scope` instead of `$scope`.

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
public class ShoppingCartController : Scope
{     
    public ShoppingCartController(Scope _scope, Timeout _timeout)
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
public class ShoppingCartController : Scope
{     
    public List<CartItem> items;
    public double billDiscount;

    public ShoppingCartController(Scope _scope, Timeout _timeout)
    {
	}
}
```

After the class controller is defined you need to register it within the application-module:

```C#
app.Controller<ShoppingCartController>();                                  
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
app.Config<MyConfigs>();
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
app.Factory<ItemsFactory>();
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
app.Filters<CartFilters>();  
```

and in HTML template:

```HTML
<span>{{amount | dollars }}<span>
```






