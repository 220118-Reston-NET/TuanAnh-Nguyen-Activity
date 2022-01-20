using System.Text.Json;

namespace SerializeFunction
{
  public class Serialize
  {
    private static string _filepath = "./data/Cart.json";

    private static Dictionary<string, int> _temporaryCart = new Dictionary<string, int>();
    private static Dictionary<string, int> _cart = new Dictionary<string, int>();

    public static void AddNewDataToFile(string item)
    {
      //Check if the JSON file is exists.
      if (File.Exists(_filepath))
      {
        //Check if the file is not empty
        if (new FileInfo(_filepath).Length == 0)
        {
          //If the file is empty, write new data on it!
          _temporaryCart.Add(item, 1);
          string jsonString = JsonSerializer.Serialize(_temporaryCart, new JsonSerializerOptions { WriteIndented = true });
          Console.WriteLine(jsonString);
          File.WriteAllText(_filepath, jsonString);
        }
        else
        {
          // Console.WriteLine("File is not empty");
          string jsonString2 = File.ReadAllText(_filepath);
          // Console.WriteLine(jsonString2);
          _cart = JsonSerializer.Deserialize<Dictionary<string, int>>(jsonString2);
          if (_cart.ContainsKey(item))
          {
            _cart[item] += 1;
            //Write to the JSON file after added item to the Cart
            string jsonString = JsonSerializer.Serialize(_cart, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filepath, jsonString);
            Console.WriteLine($"You just add one more {item} to your cart!");
          }
          else
          {
            _cart.Add(item, 1);
            //Write to the JSON file after added item to the Cart
            string jsonString = JsonSerializer.Serialize(_cart, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filepath, jsonString);
            Console.WriteLine($"You just added {item} successfully to your cart");
          }
        }
      }
      else
      {
        // File.WriteAllText(_filepath, "");
        // Console.WriteLine("JSON file just created!");
        _cart.Add(item, 1);
        //Write to the JSON file after added item to the Cart
        string jsonString = JsonSerializer.Serialize(_cart, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filepath, jsonString);
        Console.WriteLine($"You just added {item} successfully to your cart");
      }
    }

    public static void DisplayData()
    {
      //Check if the JSON file is exists.
      if (File.Exists(_filepath))
      {
        //Check if the file is not empty
        if (new FileInfo(_filepath).Length == 0)
        {
          Console.WriteLine("Empty Cart!");
        }
        else
        {
          string jsonString2 = File.ReadAllText(_filepath);
          _cart = JsonSerializer.Deserialize<Dictionary<string, int>>(jsonString2);
          if (_cart.Count == 0)
          {
            Console.WriteLine("You don't have anything in your cart!");
          }
          else
          {
            foreach (var item in _cart)
            {
              Console.WriteLine($"{item.Key} - Quantity: {item.Value}");
            }
          }
        }
      }
      else
      {
        Console.WriteLine("You need to start shopping first!");
      }
    }

    public static void RemoveData(string item)
    {
      //Check if the JSON file is exists.
      if (File.Exists(_filepath))
      {
        //Check if the file is not empty
        if (new FileInfo(_filepath).Length == 0)
        {
          Console.WriteLine("Empty Cart!");
        }
        else
        {
          string jsonString2 = File.ReadAllText(_filepath);
          _cart = JsonSerializer.Deserialize<Dictionary<string, int>>(jsonString2);
          if (_cart.ContainsKey(item))
          {
            _cart.Remove(item);
            //Write to the JSON file after added item to the Cart
            string jsonString = JsonSerializer.Serialize(_cart, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filepath, jsonString);
            Console.WriteLine($"We removed all {item} from your cart!");
          }
          else
          {
            Console.WriteLine("You don't have this item in your cart!");
          }
        }
      }
      else
      {
        Console.WriteLine("You need to start shopping first!");
      }
    }

    public static void SearchData(string item)
    {
      //Check if the JSON file is exists.
      if (File.Exists(_filepath))
      {
        //Check if the file is not empty
        if (new FileInfo(_filepath).Length == 0)
        {
          Console.WriteLine("Empty Cart!");
        }
        else
        {
          string jsonString2 = File.ReadAllText(_filepath);
          _cart = JsonSerializer.Deserialize<Dictionary<string, int>>(jsonString2);
          if (_cart.Count == 0)
          {
            Console.WriteLine("You don't have anything in your cart!");
          }
          else
          {
            if (_cart.ContainsKey(item))
            {
              Console.WriteLine($"You have {_cart[item]} of {item} in your cart!");
            }
            else
            {
              Console.WriteLine("You don't have this item in your cart!");
            }
          }
        }
      }
      else
      {
        Console.WriteLine("You need to start shopping first!");
      }
    }
  }
}