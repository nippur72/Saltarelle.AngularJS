# Factory, Service, Provider

There is just one type of Angular service and it can be created in three different ways with Factory, Service and Provider.

`Provider` is the most complex, `Factory` and `Service` are just synonims of `Provider` that are easier to use.

## Factory

Use `Factory` when you want to create a (named) service just from a plain javascript object.

In the following example the service named "Items" consisting of an array of objects is defined:

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

// ...

app.Factory<ItemsFactory>();
```

## Service

Use `Service` when you want to create a named service drirectly from an instantiable class. It is equivalent of
having a factory with a method that returns the new instance of the class. `Service` is just a short for it.

In the following example the service called "User" is defined

```C#
public class User
{                
   public User(/* injectables */)
   {
      // service initialization here
   }

   // service methods and propr here
}    

// ...

app.Service<User>();
```

## Provider

Services created from `Factory` or `Service` cannot be configured during the config phase because when they are
needed they are instantiated passing them no parameters (other than dependency injection).

`Provider` lets you define a serviceProvider that handles object initialization during the config phase.

Consider the following service named "UnicornLauncher":

```C#
public class UnicornLauncher
{
   public int launchedCount = 0; 
   public string shieldtype = "none";  
   public Timeout Timeout;

   public UnicornLauncher(Timeout _timeout, bool useTinfoilShielding)
   {
      Timeout = _timeout;

      if(useTinfoilShielding)
      {
         shieldtype = "tinfoil";
      }
   }

   public void launch()
   {
      this.launchedCount++;
   } 
}
```

notice it's configurable because its constructor accepts a flag "useTinfoilShielding". We can build a provider for it:

```C#
public class UnicornLauncherProvider 
{
   private bool shield_flag = false;  
   
   public UnicornLauncherProvider()
   {      
   }

   public void useTinfoilShielding(bool flag)
   {
      shield_flag = flag;
   }
   
   [Inject("$timeout")]
   public UnicornLauncher UnicornLauncher(Timeout _timeout)
   {
      return new UnicornLauncher(_timeout, shield_flag);
   }   
}
```

and use the provider to configure the UnicornLauncher during the config phase:

```C#
public class UnicornConfig
{
   public UnicornConfig(UnicornLauncherProvider UnicornLauncherProvider)
   {      
      UnicornLauncherProvider.useTinfoilShielding(true);   
   }
}

// ...

app.Provider<UnicornProvider>();
app.Config<UnicornConfig>();
```
