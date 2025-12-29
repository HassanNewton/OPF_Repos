using ChalkboardChat.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChalkboardChat.Data.Contexts;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<MessageModel> Messages { get; set; }
}


//Detta är databasens hjärna
//EF Core använder denna för:

//skapa tabeller

//köra queries

//spara data