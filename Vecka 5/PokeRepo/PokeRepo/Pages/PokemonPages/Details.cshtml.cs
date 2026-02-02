using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeRepo.Data;
using PokeRepo.Models;
using PokeRepo.Services;
using System.Net.Http.Json;

namespace PokeRepo.Pages.PokemonPages
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly PokeApiService _pokeApi;
        public PokemonDto? Pokemon { get; set; }

        public DetailsModel(ApplicationDbContext db, PokeApiService pokeApi)
        {
            _db = db;
            _pokeApi = pokeApi;
        }

        public async Task OnGetAsync(string name)
        {
            //Dåligt sätt att hämta data direkt från API:et Men fungerar för demo

            //using var httpClient = new HttpClient();
            //var url = $"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}";

            //Pokemon = await httpClient.GetFromJsonAsync<PokemonDto>(url);

            Pokemon = await _pokeApi.GetPokemonAsync(name);
            if (Pokemon == null)
                return;

            bool exists = _db.Pokemons.Any(p => p.PokeApiId == Pokemon.Id);
            if (exists)
                return;

            //MAPPING HÄR
            var pokemonModel = new PokemonModel
            {
                PokeApiId = Pokemon.Id,
                Name = Pokemon.Name,
                Height = Pokemon.Height,
                Weight = Pokemon.Weight
            };

            _db.Pokemons.Add(pokemonModel);
            await _db.SaveChangesAsync();
        }
    }
}
