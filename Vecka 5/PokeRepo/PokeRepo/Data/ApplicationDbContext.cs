using PokeRepo.Models;
using Microsoft.EntityFrameworkCore;
using PokeRepo.Enums;

namespace PokeRepo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PokemonModel> Pokemons => Set<PokemonModel>();

    }
}
