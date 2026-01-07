using System.ComponentModel.DataAnnotations;

namespace CoffeeApi.Models
{
    public class Coffee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Origin { get; set; }
        public int Strength { get; set; } // 1–10
    }
}
