
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;


namespace ChalkboardChat.Ui.Contexts;

public class AuthDbContext : IdentityDbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {
    }
}

//Hela Identity-systemet startar här
//Detta skapar automatiskt:

//AspNetUsers

//AspNetRoles

//Ingen DbSet behövs – Identity gör det åt dig.