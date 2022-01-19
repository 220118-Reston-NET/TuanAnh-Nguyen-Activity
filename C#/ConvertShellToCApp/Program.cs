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
  else if (userInput == 0)
  {
    repeat = false;
  }
  else
  {
    Console.WriteLine("Please try the number in the menu");
  }
}