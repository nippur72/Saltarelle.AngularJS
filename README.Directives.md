# Directives

To create a directive, do the following steps:

- create a class for defining the directive
- the class name must end in "Directive" (e.g. `myDirDirective`)
- the class name (without the word "Directive") will be the camelCase name of the directive (e.g. `<my-dir>`)
- the class must implementing the method `GetDefinition()` from the `IDirective` interface, 
- the method should return a configuration object of type `DefinitionObject` containing 
  all the implementation details of the directive.
- to help setup the configuration object (which is rather complex), there is an helper class `DirectiveDefinitionHelper`
- so for example, create a	`DirectiveDefinitionHelper` object, fill it by using its properties and methods as required.
- once the object is filled, turn it into a true definition object by calling `ob.ToDefinitionObject()`
- return it in the `GetDefinition()` method

Example of a basic "hello" directive:

```C#
// define an <hello></hello> directie
public class helloDirective : IDirective	
{
   public helloDirective()
   {                          
             
   }           

	public DefinitionObject GetDefinition()
	{
		var helper = new DirectiveDefinitionHelper();
		helper.Restrict = RestrictFlags.Element;
      helper.Template = "<div>Hello <span ng-transclude></span>!</div>";
      helper.Replace = true;         
      helper.Transclude = true; 
		helper.ScopeMode = ScopeModes.Existing; 

		return helper.ToDefinitionObject();
	}
}      
```


 