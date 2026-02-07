using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemo.Data_
{
    // IdentityDbContext är en DbContext som redan kan skapa tabeller för users/roles/claims."

    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
            // "options innehåller connection string och inställningar för EF Core."
            // "Vi skickar vidare options till bas-klassen så EF vet hur den ska koppla mot DB."
        }
    }
}
