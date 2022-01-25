using System.Text.Json;
using PokeModel;

namespace PokeDL
{
  public class Repository : IRepository
  {
    //Relative filepath is from the PokeUI since that is the starting point of our application
    private string _filepath = "../PokeDL/Database/";
    private string _jsonString;
    public Pokemon AddPokemon(Pokemon p_poke)
    {
      //So we can change which JSON files we can pick on other methods
      string _path = _filepath + "Pokemon.json";

      _jsonString = JsonSerializer.Serialize(p_poke, new JsonSerializerOptions { WriteIndented = true });

      File.WriteAllText(_path, _jsonString);

      return p_poke;
    }
  }
}