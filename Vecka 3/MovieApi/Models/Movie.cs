using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}
//DirectorId är främmande nyckel i databasen.
//Director är navigation property som låter oss inkludera regissören.