using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokeDL;
using PokeModel;
using Xunit;

namespace PokeTest
{
    public class DbContextRepositoryTest
    {
        private readonly DbContextOptions<PokeDbContext> options;

        //The constructor is called on before every unit tests
        public DbContextRepositoryTest()
        {
            //Gets the DbContextOptions from the inmemory database that is created using SQLite as the engine
            options = new DbContextOptionsBuilder<PokeDbContext>().UseSqlite("Filename = Test.db").Options;
            Seed();
        }

        [Fact]
        void GetAllPokemon_Should_Get_All_Pokemon()
        {
            using (PokeDbContext context = new PokeDbContext(options))
            {
                //Arrange
                IRepository repo = new DbContextRepository(context);

                //Act
                List<Pokemon> _listOfPoke = repo.GetAllPokemon();

                //Assert
                Assert.Equal(2, _listOfPoke.Count);
                Assert.Equal("Jasmine", _listOfPoke[0].Name);
            }
        }

        [Fact]
        async Task AddPokemonShouldAddPokemonInDB()
        {
            using (PokeDbContext context = new PokeDbContext(options))
            {
                //Arrange
                string name = "testPoke";
                int level = 1;
                Pokemon dummyPoke = new Pokemon();
                dummyPoke.Name = name;
                dummyPoke.Level = level;

                IRepository repo = new DbContextRepository(context);

                //Act
                repo.AddPokemon(dummyPoke);

                //Assert
                Pokemon pokemnoActual = await context.Pokemons.FirstAsync(p => p.Name.Equals(name));

                Assert.Equal(pokemnoActual.Level, level);
            }
        }

        //This will add data into our inmemory database
        private void Seed()
        {
            using (PokeDbContext context = new PokeDbContext(options))
            {
                //We want to make sure that our database is consistent for each unit test we run on
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.AddRange(
                    new Pokemon
                    {
                        PokeId = 1,
                        Name = "Jasmine",
                        Attack = 50,
                        Defense = 10,
                        Health = 100,
                        Level = 24,
                        Speed = 1,
                        Abilities = new List<Ability>(){
                            new Ability(){
                                AbId = 1,
                                Name = "Sleeping",
                                Accuracy = 100,
                                Power = 10,
                                PP = 999
                            }
                        }
                    },
                    new Pokemon
                    {
                        PokeId = 2,
                        Name = "Andrew",
                        Attack = 800,
                        Defense = 1,
                        Health = 1,
                        Level = 2,
                        Speed = 1,
                        Abilities = new List<Ability>(){
                            new Ability(){
                                AbId = 2,
                                Name = "Bad at coding",
                                Accuracy = 1,
                                Power = 0,
                                PP = 999
                            }
                        }
                    }
                );

                context.SaveChanges();
            }
        }
    }
}