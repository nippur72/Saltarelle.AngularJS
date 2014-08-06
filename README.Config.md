# Configs, Runs, Constant, Value, Filter 

- Configs are functions that are called on module initialization. 
- Runs are functions that are called after the module is initialized
- Filter are functions that are called from HTML templates

All of the above, are written as injectable classes:

```C#
public class MyConfig
{               
    public MyConfig(/* injectables */)
    {
    }
}                 

public class MyRun
{               
    public MyRun(/* injectables */)
    {
    }
}                 

public class CartFilters
{                
   public Filters(/* injectables */)
	{
	}
	public string dollars(double input)
    {
        return input.ToString() + " dollars";    // e.g. <span>{{amount | dollars }}<span>
    }
}                 
```

and then registered with

```C#
app.Config<MyConfig>();
app.Run<MyRun>();
app.Filter<CartFilters>();
```

- Constant is used to provide a constant value
- Value is used to provide a named value

they don't need classes, they can be defined on the fly:

```C#
app.Constant("myconst",42);
app.Value("myval",6502);
```


