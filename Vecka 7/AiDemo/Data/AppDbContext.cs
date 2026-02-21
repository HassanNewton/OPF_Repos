using AiDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace AiDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserMovieModel> UserMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserMovieModel>().HasData(
                new UserMovieModel { Id = 1, Title = "Inception", Genre = "Sci-Fi", Rating = 5 },
                new UserMovieModel { Id = 2, Title = "Interstellar", Genre = "Sci-Fi", Rating = 5 },
                new UserMovieModel { Id = 3, Title = "The Matrix", Genre = "Sci-Fi", Rating = 5 },
                new UserMovieModel { Id = 4, Title = "John Wick", Genre = "Action", Rating = 4 },
                new UserMovieModel { Id = 5, Title = "Mad Max: Fury Road", Genre = "Action", Rating = 4 },
                new UserMovieModel { Id = 6, Title = "The Notebook", Genre = "Romance", Rating = 2 },
                new UserMovieModel { Id = 7, Title = "Titanic", Genre = "Romance", Rating = 3 }
            );
        }
    }


}
