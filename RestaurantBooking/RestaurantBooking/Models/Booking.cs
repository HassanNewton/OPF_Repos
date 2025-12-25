using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models
{
    public class Booking
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Guests { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}

//`[Required]` → fältet måste fyllas i
//`EmailAddress` → enkel validering
// används som ViewModel