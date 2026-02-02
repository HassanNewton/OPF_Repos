using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeRepo.Enums;

namespace PokeRepo.Pages.PokemonPages
{
    public class IndexModel : PageModel
    {
        public List<string> PokemonNames { get; set; } = new();

        public void OnGet()
        {
            PokemonNames = Enum.GetNames(typeof(Pokemons)).ToList(); 
        }
    }
}
