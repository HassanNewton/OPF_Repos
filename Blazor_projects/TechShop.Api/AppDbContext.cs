using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TechShop.Api;

namespace TechShop.Api;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Tabell i databasen
    public DbSet<Order> Orders => Set<Order>();
}
