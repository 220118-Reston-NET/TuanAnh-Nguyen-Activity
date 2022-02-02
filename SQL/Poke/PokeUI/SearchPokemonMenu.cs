using PokeBL;
using PokeModel;

namespace PokeUI
{
  public class SearchPokemonMenu : IMenu
  {
    private IPokemonBL _pokeBL;
    public SearchPokemonMenu(IPokemonBL p_pokeBL)
    {
      _pokeBL = p_pokeBL;
    }

    public void Display()
    {
      Console.WriteLine("Please select an option to filter the pokemon database");
      Console.WriteLine("[1] By Name");
      Console.WriteLine("[0] Go back");
    }

    public MenuType UserChoice()
    {
      string userInput = Console.ReadLine();

      switch (userInput)
      {
        case "0":
          return MenuType.MainMenu;
        case "1":
          //Logic to grab user input
          Console.WriteLine("Please enter a name");
          string name = Console.ReadLine();

          //Logic to display the result
          List<Pokemon> listOfPoke = _pokeBL.SearchPokemon(name);
          foreach (var item in listOfPoke)
          {
            Console.WriteLine("================");
            Console.WriteLine(item);
          }
          Console.WriteLine("Please press Enter to continue");
          Console.ReadLine();

          return MenuType.MainMenu;
        default:
          Console.WriteLine("Please input a valid response");
          Console.WriteLine("Please press Enter to continue");
          Console.ReadLine();
          return MenuType.SearchPokemon;

      }
    }
  }
}