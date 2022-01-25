namespace OOPFunction
{
  public class OOP
  {
    public static void OOPMain()
    {
      Console.WriteLine("===Ingeritence Demo===");
      Dog dog1 = new Dog();
      dog1.Talk();
      dog1.Talk("German Sheperd");
      Console.WriteLine(dog1.Name);

      Dog dog2 = new Dog("Minnie");
      Console.WriteLine(dog2.Name);
    }
  }
  public class Animal
  {
    public string Name { get; set; }
    public string Color { get; set; }
    public virtual void Talk()
    {
      Console.WriteLine("Animal is talking!");
    }

    //Method overloading
    //When two methods have the same name but different parameters and implementation details
    //Only work with parameters
    public void Talk(string p_talk)
    {
      Console.WriteLine(p_talk + " is talking!");
    }

    public Animal()
    {
      Name = "Animal";
      Color = "Navy Blue";
    }

    public Animal(string p_name)
    {
      Name = p_name;
      Color = "Navy Blue";
    }
  }

  //Inheritance is denoted by a ":" syntax
  //Derived/child class
  //Constructors is a bit special that they aren't inherited but the defualt base class constructor will run whenver you create
  //an abohect out of the derived class
  public class Dog : Animal
  {
    public Dog() : base()
    {

    }
    public Dog(string p_name) : base(p_name)
    {

    }

    //Method overriding
    //It is when a derived class changes the function/implementation details of the base class
    //It needs to use virtual and override keywords (non-access modifiers) to tell the compiler
    //that we are trying to achieve method overriding
    //It needs to have the same method name and same parameters
    public override void Talk()
    {
      Console.WriteLine("Barking!");
    }
  }
}
