using Microsoft.EntityFrameworkCore;
using MyApi.ProductionLike.Models;

namespace MyApi.ProductionLike.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
}