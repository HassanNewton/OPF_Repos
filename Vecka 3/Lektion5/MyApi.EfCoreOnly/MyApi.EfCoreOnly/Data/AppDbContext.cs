using Microsoft.EntityFrameworkCore;
using MyApi.EfCoreOnly.Models;

namespace MyApi.EfCoreOnly.Data;

// DbContext = "vår databas i kod".
// Den håller koll på tabeller (DbSet) och sköter kommunikationen med databasen.
//
// Viktigt: DbContext ska INTE skapas med new i controllers.
// Den ska injiceras via Dependency Injection (DI).
public class AppDbContext : DbContext
{
    // options innehåller t.ex. vilken databas vi använder (SQL Server)
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // DbSet<Product> = en tabell i databasen
    public DbSet<Product> Products { get; set; } = null!;
}