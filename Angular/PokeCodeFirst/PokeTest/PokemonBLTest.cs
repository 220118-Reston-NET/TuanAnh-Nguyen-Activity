using Xunit;
using Moq;
using PokeModel;
using System.Collections.Generic;
using PokeDL;
using PokeBL;

namespace PokeTest
{
  public class PokemonBLTest
  {
    [Fact]
    public void Should_Get_All_Pokemon()
    {
      //Arrange
      string _pokeName = "Pikachu";
      int _pokeLevel = 5;
      Pokemon poke = new Pokemon()
      {
        Name = _pokeName,
        Level = _pokeLevel
      };

      List<Pokemon> _expectedlistOfPoke = new List<Pokemon>();
      _expectedlistOfPoke.Add(poke);

      //We are mocking one of the required dependencies of PokemonBL which is IRepository
      Mock<IRepository> _mockRepo = new Mock<IRepository>();

      //We change that if our IRepository.GetAllPokemon() is called, it will always return our expectedListOfPoke
      //In this way, we guaranteed that our dependency will always work so if something goes wrong it is the business layer's fault
      _mockRepo.Setup(repo => repo.GetAllPokemon()).Returns(_expectedlistOfPoke);

      IPokemonBL _pokeBL = new PokemonBL(_mockRepo.Object);

      //Act
      List<Pokemon> _actualListOFPoke = _pokeBL.GetAllPokemon();

      //Assert
      Assert.Same(_expectedlistOfPoke, _actualListOFPoke);
      Assert.Equal(_pokeName, _actualListOFPoke[0].Name);
      Assert.Equal(_pokeLevel, _actualListOFPoke[0].Level);
    }
  }
}