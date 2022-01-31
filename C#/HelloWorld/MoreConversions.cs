namespace MoreConversionFunction
{
  public class MoreConversion
  {
    public static void MoreConvMain()
    {
      Console.WriteLine("======= MoreConversion =========");
      int integerVar = 10;
      double doubleVar = integerVar;

      //User-defined implicit conversion
      Car car1 = integerVar;
      Console.WriteLine(car1.Fuel);

      //User-defined explicit conversion
      Car car2 = (Car)doubleVar;
      Console.WriteLine(car2.Fuel);

      //Boxing example
      //When value type gets converted into an object and acts more like a reference type
      //Implicit conversion
      object obj1 = integerVar;
      Console.WriteLine(obj1);

      //Autoboxing - done with non-generic collection when we add the elements 


      //Unboxing example
      //Explicit conversion
      int integerVar2 = (int)obj1;
      Console.WriteLine(integerVar2 + 10);
    }
  }

  public class Car
  {
    public string Owner { get; set; }
    public int Fuel { get; set; }

    //Implicit user-defined conversion
    //Allows us to create a class to be able to convert from some other dattatype
    //The parameter will dictate what datatype you are converting
    //Return an object out of the class
    //Implicit and explicit are interchangeable
    public static implicit operator Car(int p_fuel)
    {
      return new Car()
      {
        Fuel = p_fuel
      };
    }

    //Explicit user-defined conversion
    public static explicit operator Car(double p_fuel)
    {
      return new Car()
      {
        Fuel = (int)p_fuel
      };
    }
  }
}