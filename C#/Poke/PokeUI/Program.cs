// See https://aka.ms/new-console-template for more information
// using PokeModel;
using PokeBL;
using PokeDL;
using PokeUI;
// Console.WriteLine("Hello, World!");
// Ability ab = new Ability();
// ab.PP = -1; //Validation is working since can't input a negative value

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
      menu = new AddPokeMenu(new PokemonBL(new Repository()));
      break;
    case "MainMenu":
      menu = new MainMenu();
      break;
    case "Exit":
      repeat = false;
      break;
    default:
      Console.WriteLine("Page does not exist!");
      break;
  }
}