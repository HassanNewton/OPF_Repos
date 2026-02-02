using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

            //Försök hämta från databasen först
            var existingPokemon = await _db.Pokemons
       .FirstOrDefaultAsync(p => p.Name.ToLower() == name.ToLower());

            if (existingPokemon != null)
            {
                Pokemon = new PokemonDto
                {
                    Id = existingPokemon.PokeApiId,
                    Name = existingPokemon.Name,
                    Height = existingPokemon.Height,
                    Weight = existingPokemon.Weight,
                    Moves = existingPokemon.Moves
                };
                return;
            }

            // Finns inte → hämta från API
            Pokemon = await _pokeApi.GetPokemonAsync(name);
            if (Pokemon == null)
                return;

            // Spara i databasen
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
