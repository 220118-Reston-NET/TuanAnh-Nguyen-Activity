using Microsoft.EntityFrameworkCore;
using PokeModel;

namespace PokeDL
{
    public class PokeDbContext : DbContext
    {
        //WE SUPPLY A BUNCH OF DbSet properties to map our models to this upcoming DbContext
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Ability> Abilities { get; set; }

        public PokeDbContext() : base()
        {
        }

        public PokeDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Create self generating Id
            builder.Entity<Pokemon>()
                .Property(poke => poke.PokeId)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Entity<Ability>()
                .Property(abi => abi.AbId)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}