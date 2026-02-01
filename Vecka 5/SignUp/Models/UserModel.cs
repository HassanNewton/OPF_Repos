using System.ComponentModel.DataAnnotations;

namespace SignUp.Models
{
    public class UserModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
