using DataFunction;
using Data2Function;

Console.Clear();
Console.WriteLine("Welcome to programming!");
Console.WriteLine("Please tell me your name:");
string name = Console.ReadLine();
Console.WriteLine($"Hello {name}, what do you want to do today?");

bool repeat = true;
while (repeat == true)
{
  Console.WriteLine("[1] - Add three numbers");
  Console.WriteLine("[2] - Solve x in the Quadratic Formula");
  Console.WriteLine("[3] - Shopping Cart(Day3)");
  Console.WriteLine("[0] - Exit");
  int userInput = Convert.ToInt32(Console.ReadLine());

  if (userInput == 1)
  {
    Console.WriteLine("Pleasve give me two numbers");
    int num1 = Convert.ToInt32(Console.ReadLine());
    int num2 = Convert.ToInt32(Console.ReadLine());
    int num3 = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine($"The sum is {num1 + num2 + num3}");

    Console.WriteLine("Press enter to continue...");
    Console.ReadLine();
  }
  else if (userInput == 2)
  {
    Console.WriteLine("Here is the Quadratic Formula format: ax^2 + bx + c = 0");
    Console.WriteLine("Please give me the number a:");
    int numA = Convert.ToInt32(Console.ReadLine());
    while (numA == 0)
    {
      Console.WriteLine("Number a can not be 0. Pleasve give me another number:");
      numA = Convert.ToInt32(Console.ReadLine());
    }
    Console.WriteLine("Please give me the number b:");
    int numB = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Please give me the number c:");
    int numC = Convert.ToInt32(Console.ReadLine());

    double delta = Math.Pow(numB, 2) - (4 * numA * numC);
    if (delta < 0)
    {
      Console.WriteLine("There is no x in this case!");
    }
    else if (delta == 0)
    {
      Console.WriteLine("There is only one x which is: " + (-numB / (2 * numA)));
    }
    else
    {
      Console.WriteLine("There are 2 of x:");
      double x1 = (-numB + Math.Sqrt(delta)) / (2 * numA);
      double x2 = (-numB - Math.Sqrt(delta)) / (2 * numA);
      Console.WriteLine($"x1: {x1}");
      Console.WriteLine($"x2: {x2}");
    }

    Console.WriteLine("Press enter to continue...");
    Console.ReadLine();
  }
  //START Day 3 Activity
  else if (userInput == 3)
  {
    bool repeatMenu2 = true;
    Console.Clear();
    Console.WriteLine($"Hi {name}, welcome to our online shopping!");
    Console.WriteLine("What do you want to do today?");

    while (repeatMenu2 == true)
    {
      Console.WriteLine("[1] - Add item to my cart");
      Console.WriteLine("[2] - Display all items I have in my cart");
      Console.WriteLine("[3] - Remove item from my cart");
      Console.WriteLine("[4] - Search item from my cart");
      Console.WriteLine("[0] - Go back to the main menu");
      int userInput2 = Convert.ToInt32(Console.ReadLine());

      if (userInput2 == 1)
      {
        Console.WriteLine("What do you want to buy today?");
        string item = Console.ReadLine();
        // Data.AddItemToCart(item);
        Data2.AddItemToCart(item);
      }
      else if (userInput2 == 2)
      {
        Console.WriteLine("Here are all item(s) you have in my cart:");
        // Data.DisplayCart();
        Data2.DisplayCart();
      }
      else if (userInput2 == 3)
      {
        Console.WriteLine("Which item do you want to remove from your cart");
        string item = Console.ReadLine();
        // Data.RemoveItemFromCart(item);
        Data2.RemoveItemFromCart(item);
      }
      else if (userInput2 == 4)
      {
        Console.WriteLine("Which item do you want to look for from my cart");
        string item = Console.ReadLine();
        // Data.SearchItemFromCart(item);
        Data2.SearchItemFromCart(item);
      }
      else if (userInput2 == 0)
      {
        Console.Clear();
        repeatMenu2 = false;
      }
      else
      {
        Console.WriteLine("Please try the number in the menu");
      }
    }
  }
  //END Day 3 Activity
  else if (userInput == 0)
  {
    repeat = false;
  }
  else
  {
    Console.WriteLine("Please try the number in the menu");
  }
}