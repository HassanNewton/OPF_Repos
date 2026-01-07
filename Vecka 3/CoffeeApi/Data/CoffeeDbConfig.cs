using CoffeeApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CoffeeApi.Data
{
    public class CoffeeDbContext : DbContext
    {
        public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options)
            : base(options)
        {
        }

        // DbSet = tabell i databasen
        public DbSet<Coffee> Coffees { get; set; }
    }
}
