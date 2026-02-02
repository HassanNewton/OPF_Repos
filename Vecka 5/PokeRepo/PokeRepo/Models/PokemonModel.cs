namespace PokeRepo.Models
{
    public class PokemonModel
    {
        public int Id { get; set; } // DB primary key
        public int PokeApiId { get; set; }   // ID från PokéAPI
        public string Name { get; set; } = "";
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
