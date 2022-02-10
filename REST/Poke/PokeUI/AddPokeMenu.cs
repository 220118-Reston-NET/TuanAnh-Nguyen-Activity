using PokeBL;
using PokeModel;

namespace PokeUI
{
  public class AddPokeMenu : IMenu
  {
    //static non-access modifier is needed to keep this variable consistent to all objects we create out of our AddPokeMenu
    private static Pokemon _newPoke = new Pokemon();

    //Dependency Injection
    //==========================
    private IPokemonBL _pokeBL;
    public AddPokeMenu(IPokemonBL p_pokeBL)
    {
      _pokeBL = p_pokeBL;
    }
    //==========================

    public void Display()
    {
      Console.WriteLine("Enter Pokemon information");
      Console.WriteLine("[3] Name - " + _newPoke.Name);
      Console.WriteLine("[2] Level - " + _newPoke.Level);
      Console.WriteLine("[1] Save");
      Console.WriteLine("[0] Go Back");
    }

    public MenuType UserChoice()
    {
      string userInput = Console.ReadLine();

      switch (userInput)
      {
        case "0":
          return MenuType.MainMenu;
        case "1":
          //Exception handling to have a better user experience
          try
          {
            Log.Information("Adding pokemon \n" + _newPoke);
            _pokeBL.AddPokemon(_newPoke);
            Log.Information("Successful at adding pokemon!");
          }
          catch (System.Exception exc)
          {
            Log.Warning("Failed to add pokemon due to reaching total capacity (4)");
            Console.WriteLine(exc.Message);
            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();
          }
          return MenuType.MainMenu;
        case "2":
          Console.WriteLine("Please enter a level!");
          _newPoke.Level = Convert.ToInt32(Console.ReadLine());
          return MenuType.AddPoke;
        case "3":
          Console.WriteLine("Please enter a name!");
          _newPoke.Name = Console.ReadLine();
          return MenuType.AddPoke;
        default:
          Console.WriteLine("Please input a valid response");
          Console.WriteLine("Please press Enter to continue");
          Console.ReadLine();
          return MenuType.AddPoke;
      }
    }
  }
}