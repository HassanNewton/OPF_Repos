using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeRepo.Data;
using PokeRepo.Models;

namespace PokeRepo.Pages.PokemonPages
{
    public class SavedModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public List<PokemonModel> Pokemons { get; set; } = new();

        public SavedModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Pokemons = _db.Pokemons
                .OrderBy(p => p.Name)
                .ToList();
        }
    }
}
