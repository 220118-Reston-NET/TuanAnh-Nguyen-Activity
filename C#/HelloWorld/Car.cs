namespace CarFuntion
{
  public class Car
  {
    //Field
    private string _color;
    private string _owner;
    private int _fuel;
    private int _gallonPerMile;

    //Property
    //They are in PascalCase ThisIsHowPascalCaseWillMakeSentence
    public string Color
    {
      get
      {
        return "The color is " + _color;
      }
      set
      {
        _color = value;
      }
    }

    public string Owner
    {
      get
      {
        return _owner;
      }
      set
      {
        _owner = value;
      }
    }

    public int Fuel { get; set; }

    //Constructor
    //It is a special method that will run first whenever you create an object out of that class
    public Car()
    {
      _color = "Blue";
      _gallonPerMile = 10;
      _owner = "No Owner";
      Fuel = 100;
    }

    //A method will run multiple lines of code to do some sort of operation/behavior/function
    //void this method will return/give back nothing
    //We can change void into another datatype if you want the method to give information back
    public void Start()
    {
      Console.WriteLine("The car is starting right now!");
      Console.WriteLine($"Current fuel: {Fuel}");
    }

    //You can add parameters to a method to pass in data to be used inside method
    //Make sure the parameter has a datatype and then a name
    public void Start(int p_fuel)
    {
      Fuel = p_fuel;
      Console.WriteLine("The car is starting right now!");
      Console.WriteLine($"Current fuel: {Fuel}");
    }

    //Will give the total distnace of a car
    public double TotalDistance()
    {
      return (double)Fuel / _gallonPerMile;
    }

  }
}
