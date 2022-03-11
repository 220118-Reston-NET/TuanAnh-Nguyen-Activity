﻿using PokeModel;

namespace PokeBL
{
  /// <summary>
  /// Business layer is responsible for further validation or processing of data obtained from either the database or the user
  /// What kind of processing? That all depends on the type of functionality you will be doing
  /// </summary>
  public interface IPokemonBL
  {
    /// <summary>
    /// Will add a pokemon data to the database
    /// Initial addition of a pokemon will give it some sort of a randomize stats
    /// Can only have the total of 4 pokemons in the database
    /// </summary>
    /// <param name="p_poke"></param>
    /// <returns></returns>
    Pokemon AddPokemon(Pokemon p_poke);

    /// <summary>
    /// Will give a list of pokemon objects that are related to the searched name
    /// </summary>
    /// <param name="p_name">Name parameter being used to filter our pokemon</param>
    /// <returns>Gives a filtered list of pokemon via a name</returns>
    List<Pokemon> SearchPokemon(string p_name);

    /// <summary>
    /// Will give a list of pokemon from the database
    /// </summary>
    /// <returns>List collection with pokemon objects</returns>
    List<Pokemon> GetAllPokemon();
    Task<List<Pokemon>> GetAllPokemonAsync();

    List<Ability> GetAbilitiesByPokeId(int p_pokeId);
    Pokemon UpdatePokemon(Pokemon p_poke);
  }
}
