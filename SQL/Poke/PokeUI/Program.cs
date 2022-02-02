// See https://aka.ms/new-console-template for more information
// using PokeModel;
global using Serilog;
using Microsoft.Extensions.Configuration;
using PokeBL;
using PokeDL;
using PokeUI;

// Console.WriteLine("Hello, World!");
// Ability ab = new Ability();
// ab.PP = -1; //Validation is working since can't input a negative value

//Creating and configuring our logger
Log.Logger = new LoggerConfiguration().WriteTo.File("./logs/user.txt").CreateLogger();

//Reading and obtaining connectionString from appsettings.json
var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

string _connectionString = configuration.GetConnectionString("Reference2DB");

bool repeat = true;
IMenu menu = new MainMenu();

while (repeat)
{
  Console.Clear();
  menu.Display();
  string ans = menu.UserChoice();

  switch (ans)
  {
    case "AddPokemon":
      Log.Information("Displaying AddPokemon Menu to user");
      menu = new AddPokeMenu(new PokemonBL(new SQLRepository(_connectionString)));
      break;
    case "SearchPokemon":
      Log.Information("Displaying SearchPokemon Menu to user");
      menu = new SearchPokemonMenu(new PokemonBL(new SQLRepository(_connectionString)));
      break;
    case "MainMenu":
      Log.Information("Displaying MainMenu to user");
      menu = new MainMenu();
      break;
    case "Exit":
      Log.Information("Exiting application");
      Log.CloseAndFlush(); //To close our logger resource
      repeat = false;
      break;
    default:
      Console.WriteLine("Page does not exist!");
      Console.WriteLine("Please press Enter to continue");
      Console.ReadLine();
      break;
  }
}