using PokeModel;
using PokeBL;

namespace PokeUI
{
  public class GetPokeAbility : IMenu
  {
    private List<Pokemon> _listOfPoke;
    private IPokemonBL _pokeBL;
    public GetPokeAbility(IPokemonBL p_pokeBL)
    {
      _pokeBL = p_pokeBL;
      _listOfPoke = _pokeBL.GetAllPokemon();
    }
    public void Display()
    {
      foreach (var item in _listOfPoke)
      {
        Console.WriteLine("====================");
        Console.WriteLine(item);
      }
      Console.WriteLine("[1] Select Pokemon by Id");
      Console.WriteLine("[0] Go Back");
    }

    public MenuType UserChoice()
    {
      string userInput = Console.ReadLine();

      //Switch cases are just useful if you are doing a bunch of comparison
      switch (userInput)
      {
        case "0":
          return MenuType.MainMenu;
        case "1":
          Console.WriteLine("Enter PokeId:");

          try
          {
            int pokeId = Convert.ToInt32(Console.ReadLine());
            List<Ability> listOfAbility = _pokeBL.GetAbilitiesByPokeId(pokeId);
            foreach (var item in listOfAbility)
            {
              Console.WriteLine("======================");
              Console.WriteLine(item);
            }

            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();

            return MenuType.MainMenu;
          }
          catch (FormatException)
          {
            Console.WriteLine("Please input a valid response");
            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();
            return MenuType.GetPokeAbility;
          }

        default:
          Console.WriteLine("Please input a valid response");
          Console.WriteLine("Please press Enter to continue");
          Console.ReadLine();
          return MenuType.MainMenu;
      }
    }
  }
}