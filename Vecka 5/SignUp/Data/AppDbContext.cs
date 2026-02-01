using Microsoft.EntityFrameworkCore;
using SignUp.Models;

namespace SignUp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
