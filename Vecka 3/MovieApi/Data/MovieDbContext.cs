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

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Directors
    modelBuilder.Entity<Director>().HasData(
        new Director { Id = 1, Name = "Jim Henson, Frank Oz", Nationality = "American" },
        new Director { Id = 2, Name = "The Wachowski Brothers", Nationality = "American" },
        new Director { Id = 3, Name = "Guillermo del Toro", Nationality = "Mexican" },
        new Director { Id = 4, Name = "Wolfgang Petersen", Nationality = "German" },
        new Director { Id = 5, Name = "Ridley Scott", Nationality = "British" }
    );

    // Movies
    modelBuilder.Entity<Movie>().HasData(
        new Movie
        {
            Id = 1,
            Title = "The Dark Crystal",
            Description = "The last of the Gelflings...",
            DirectorId = 1
        },
        new Movie
        {
            Id = 2,
            Title = "The Matrix",
            Description = "A hacker named Neo discovers...",
            DirectorId = 2
        },
        new Movie
        {
            Id = 3,
            Title = "Pan's Labyrinth",
            Description = "In the falangist Spain of 1944...",
            DirectorId = 3
        },
        new Movie
        {
            Id = 4,
            Title = "The NeverEnding Story",
            Description = "A young boy becomes trapped in a book...",
            DirectorId = 4
        },
        new Movie
        {
            Id = 5,
            Title = "Blade Runner",
            Description = "In a dystopian Los Angeles...",
            DirectorId = 5
        }
    );
}
}
 