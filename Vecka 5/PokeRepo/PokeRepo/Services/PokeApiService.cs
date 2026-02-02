using PokeRepo.Models;

namespace PokeRepo.Services
{
    public class PokeApiService
    {
        private readonly HttpClient _http;

        public PokeApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<PokemonDto?> GetPokemonAsync(string name)
        {
            return await _http.GetFromJsonAsync<PokemonDto>(
                $"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}");
        }
    }
}
