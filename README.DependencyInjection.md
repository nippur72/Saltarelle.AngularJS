# Dependency Injection

Classes can be Dependency-injection annotated in three different ways:

- explicit annotation at registration of type in the module:

```C#
m.Controller<MyController>("$scope","$timeout");
```

- explicit annotation with the [Inject] decorator 

```C#
[Reflectable, Inject("$scope","$timeout")
public class MyController
{
   public MyController(Scope s, Timeout t) { /*...*/ }
}
```

- implicit annotation using constructor parameter names (types are not considered)

```C#
public class MyController
{
   public MyController(Scope _scope, Timeout _timeout) { /*...*/ }
}
```

Please notice that names starting with the `$` prefix (e.g. `$scope`) are not valid identifier names in C#.
To overcome this, the `_` underscore character is used in placed of the `$` sign when declaring parameters for dependency injection. 
The library takes care of translating it back to `$`. 

