## Getting started

To start using the library (Visual Studio assumed) do the following steps: 

- have a Visual Studio solution containing a C# project and a Website project
- open package manager console, choose C# project and install Saltarelle with:
- `install-package Saltarelle.Compiler`
- `install-package Saltarelle.Runtime`
- `install-package Saltarelle.Web`
- then install this repo with: `install-package Saltarelle.Angular.Cs`
- from package manager console switch to Website project and type: `install-package Saltarelle.Angular.Web`
- in your HTML files put references to `angular.js`, `mscorlib.js` and `Saltarelle.AngularJS.js` 

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

## Member casing

By default the Saltarelle compiler is configured to translate to Javascript casing, also known as camelCase (e.g. "ToString()" is converted into "toString()"),
which can be source of mistakes when you reference your C# objects from the HTML markup. To avoid case mismatches, it's suggested to add the
following global attribute declaration in your `Assembly.cs` file:

```C#
[assembly: PreserveMemberCase]
```

