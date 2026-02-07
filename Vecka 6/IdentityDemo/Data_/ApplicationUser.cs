using Microsoft.AspNetCore.Identity;

namespace IdentityDemo.Data_
{
    // "IdentityUser är Microsofts standard-användare. Vi ärver för att kunna lägga till egna fält senare."
    public class ApplicationUser : IdentityUser
    {
        // "Det här är exempel på extra data vi vill kunna spara om användaren."
        public string? City { get; set; }

        // "Vi vill kunna logga senaste inloggning, därför ett DateTime-fält."
        public DateTime? LastLogin { get; set; }
    }
}
