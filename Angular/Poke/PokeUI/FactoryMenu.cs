using PokeBL;
using PokeDL;
using Microsoft.Extensions.Configuration;

namespace PokeUI
{
  /*
    - Factory design pattern uses one class that is designed to do all the creaton logic to create multiple objects in your program
    - This is so you can re-use code and don't have to copy and paste a bunch of creation logic
  */
  public class FactoryMenu : IFactory
  {
    public IMenu CreateMenu(MenuType p_menu)
    {
      //Reading and obtaining connectionString from appsettings.json
      var configuration = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json")
                              .Build();

      string _connectionString = configuration.GetConnectionString("Reference2DB");

      switch (p_menu)
      {
        case MenuType.MainMenu:
          return new MainMenu();
        case MenuType.AddPoke:
          return new AddPokeMenu(new PokemonBL(new SQLRepository(_connectionString)));
        case MenuType.GetPokeAbility:
          return new GetPokeAbility(new PokemonBL(new SQLRepository(_connectionString)));
        case MenuType.SearchPokemon:
          return new SearchPokemonMenu(new PokemonBL(new SQLRepository(_connectionString)));
        default:
          return new MainMenu();
      }
    }
  }
}