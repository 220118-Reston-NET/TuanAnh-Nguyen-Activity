namespace AsyncFunction
{
  /*
    In the context of cooking something
    As you know with cooking shows, to expedite the process of getting the finish prodcut, they will cook things at the same time
    We can do the same with programming
  */
  public class Asynchronous
  {
    public async Task<string> CookRice()
    {
      Console.WriteLine("Started cooking rice...");
      await Task.Delay(5000); //This line just stops the program for 5000 miliseconds
      return "Finished cooking rice";
    }

    //We want to cook the meat first and then the veggies
    public async Task<string> CookMeat()
    {
      Console.WriteLine("Started cooking meat...");
      await Task.Delay(3000); //This line just stops the program for 3000 miliseconds
      return "Finished cooking meat";
    }

    public async Task<string> CookVeggies()
    {
      Console.WriteLine("Started cooking veggies...");
      await Task.Delay(1000); //This line just stops the program for 1000 miliseconds
      return "Finished cooking veggies";
    }

    public async Task<string> CookMeatThenVeggies()
    {
      Console.WriteLine("Preparing main course...");

      Console.WriteLine(await CookMeat());
      Console.WriteLine(await CookVeggies());

      return "Finished cooking the main course";
    }
  }
}