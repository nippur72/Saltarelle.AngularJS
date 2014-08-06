# Creating an AngularJS Controller

```C#
public class ShoppingCartController 
{         
    public ShoppingCartController(Scope _scope, Timeout _timeout)
    {
	 }
}
```

any other parameter in the class constructor will be treated as an injectable parameter 
(in the example above the `$timeout` object is injected). If you want to use any injected 
parameter outside of the constructor, save its reference to a field variable. 

The class should also declare the objects that are part of the "model". What you refer from
outside C# (e.g. HTML) should be declared with the `public` modifier. For example:

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
_scope.Watch<double>(()=>totalCart, calculateDiscount);
```

and then define:

```C#
public double calculateDiscount(double newValue, double oldValue)
{
	billDiscount = newValue > 100 ? 10 : 0;
};
```

