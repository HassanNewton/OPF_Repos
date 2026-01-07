using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models
{
    public class Director
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Nationality { get; set; }

        public List<Movie> Movies { get; set; } = new();
    }
}
