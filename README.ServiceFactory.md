# Defining a Factory

A factory is a function that returns an object resource that can be used in controllers or other parts of Angular and 
that is injected automatically using the its name. 

In the following example the factory called "Items" is defined

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

once the factory is registered, it can be used in any angular function by refering its name ("Items"). 

# Defining a Service

A service is a singleton named class hat can be used in controllers or other parts of Angular and 
that is injected automatically using the service name. 

In the following example the service called "Item" is defined

```C#
public class Item
{                
   public Items(/* injectables */)
   {

   }
}    
```

and then registered with:

```C#
app.Service<Item>();
```

once the service is registered, it can be used in any angular function by refering its name ("Item"). 
