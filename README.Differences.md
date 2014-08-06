## Differences between C# and Javascript

There are some differences between the AngularJS C# implementation and its Javascript counterpart:

### Classes instead of nested functions

Angular makes intensive use of nested functions (functions containing functions) which are used to manage dependency injection in controllers, services 
and other components. Typically an outer function receives injected objects as function's parameters which are thus available to be referenced within
inner functions. 

Unfortunately the C# equivalent of this pattern results in a clumsy use of function delegates and lambda expressions that is
too impractical for real coding. 

For this reason a different approach is used: 
- controllers, services and all other angular components are written as classes instead of functions
- the class constructor receives the injectable objects as parameters (the same way the "outer" function does in javascript)
- to make injectable objects available to the methods of the class, the constructor needs to save them in field members
- class controllers can be referenced from HTML templated only with the "controller as" syntax e.g. `ng-controller="MyController as ctrl"`

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
		this.http = _http;	// since _http is referenced in "inner()" we save it locally
	}

	public void inner()
	{
	   // use http here 
	}
}
```

