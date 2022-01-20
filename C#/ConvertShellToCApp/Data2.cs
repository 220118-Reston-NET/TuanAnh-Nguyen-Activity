//Using dictionary to solve Activity Day 3
namespace Data2Function
{
  public class Data2
  {
    public static Dictionary<string, int> _shoppingCart = new Dictionary<string, int>();

    public static void AddItemToCart(string item)
    {
      if (_shoppingCart.ContainsKey(item))
      {
        _shoppingCart[item] += 1;
        Console.WriteLine($"You just add one more {item} to your cart!");
      }
      else
      {
        _shoppingCart.Add(item, 1);
        Console.WriteLine($"You just added {item} successfully to your cart");
      }
    }

    public static void DisplayCart()
    {
      if (_shoppingCart.Count == 0)
      {
        Console.WriteLine("You don't have anything in your cart!");
      }
      else
      {
        foreach (var item in _shoppingCart)
        {
          Console.WriteLine($"{item.Key} - Quantity: {item.Value}");
        }
      }
    }

    public static void RemoveItemFromCart(string item)
    {
      if (_shoppingCart.ContainsKey(item))
      {
        _shoppingCart.Remove(item);
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
        if (_shoppingCart.ContainsKey(item))
        {
          Console.WriteLine($"You have {_shoppingCart[item]} of {item} in your cart!");
        }
        else
        {
          Console.WriteLine("You don't have this item in your cart!");
        }
      }
    }
  }
}