using Microsoft.EntityFrameworkCore;
using MovieApi.Models;
using System.Collections.Generic;
using System.IO;

namespace MovieApi.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
    }
}
//DbSet < Movie > = tabellen Movies
//DbSet < Director > = tabellen Directors