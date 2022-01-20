namespace DataFunction
{
  public class Data
  {
    public static List<string> _shoppingCart = new List<string>();

    public static void AddItemToCart(string item)
    {
      _shoppingCart.Add(item);
      Console.WriteLine($"You just added {item} successfully to your cart");
    }

    public static void DisplayCart()
    {
      if (_shoppingCart.Count == 0)
      {
        Console.WriteLine("You don't have anything in your cart!");
      }
      else
      {
        for (int i = 0; i < _shoppingCart.Count; i++)
        {
          Console.WriteLine($"- {_shoppingCart[i]}");
        }
        Console.WriteLine($"You have {_shoppingCart.Count} item(s) in your cart!");
      }
    }

    public static void RemoveItemFromCart(string item)
    {
      if (_shoppingCart.Contains(item))
      {
        for (int i = 0; i < _shoppingCart.Count; i++)
        {
          if (_shoppingCart[i] == item)
          {
            _shoppingCart.RemoveAt(i);
          }
        }
        Console.WriteLine($"We removed all {item} from your cart!");
      }
      else
      {
        Console.WriteLine("You don't have this item in your cart!");
      }

    }

    public static void SearchItemFromCart(string item)
    {
      if (_shoppingCart.Count == 0)
      {
        Console.WriteLine("You don't have anything in your cart!");
      }
      else
      {
        if (_shoppingCart.Contains(item))
        {
          Console.WriteLine("You have this item in your cart!");
        }
        else
        {
          Console.WriteLine("You don't have this item in your cart!");
        }
      }
    }
  }
}