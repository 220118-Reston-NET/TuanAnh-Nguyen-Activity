using Microsoft.EntityFrameworkCore;
using PokeModel;

namespace PokeDL
{
    public class DbContextRepository : IRepository
    {
        private readonly PokeDbContext _context;

        public DbContextRepository(PokeDbContext context)
        {
            _context = context;
        }

        public Pokemon AddPokemon(Pokemon p_poke)
        {
            _context.Add(p_poke);
            _context.SaveChanges();

            return p_poke;
        }

        public List<Ability> GetAbilitiesByPokeId(int p_pokeId)
        {
            return _context.Abilities.Where(abi => abi.PokemonPokeId.Equals(p_pokeId)).ToList();
        }

        public List<Pokemon> GetAllPokemon()
        {
            return _context.Pokemons.Include("Abilities").ToList();
        }

        public async Task<List<Pokemon>> GetAllPokemonAsync()
        {
            return _context.Pokemons.ToList<Pokemon>();
        }

        public Pokemon UpdatePokemon(Pokemon p_poke)
        {
            _context.Update(p_poke);
            _context.SaveChanges();

            return p_poke;
        }
    }
}