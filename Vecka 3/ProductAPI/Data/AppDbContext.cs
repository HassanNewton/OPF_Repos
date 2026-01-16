using ProductAPI.Models;
using System.Collections.Generic;

namespace ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
    }
}
