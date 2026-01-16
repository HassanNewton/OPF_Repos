using Microsoft.EntityFrameworkCore;
using MyApi.EfCoreOnly.Data;
using MyApi.EfCoreOnly.Models;

var builder = WebApplication.CreateBuilder(args);

// 1) Controllers (API endpoints)
builder.Services.AddControllers();

// 2) Swagger (bra för att testa API:t snabbt under lektion)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3) EF Core: registrera DbContext i DI-containern
// DbContext är normalt Scoped (en instans per HTTP-request).
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// ⚠️ För undervisning:
// Vi kan "seed:a" lite data vid start så att GET /api/products inte är tomt.
// Detta är valfritt men pedagogiskt.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // OBS:
    // - EnsureCreated() skapar databasen direkt utan migrationer.
    // - För "riktig" workflow i kursen: använd migrationer (dotnet ef migrations add + update).
    //
    // Här använder vi EnsureCreated för att projektet ska vara lätt att köra direkt.
    db.Database.EnsureCreated();

    if (!db.Products.Any())
    {
        db.Products.AddRange(
            new Product { Name = "Pen", Price = 10 },
            new Product { Name = "Book", Price = 50 }
        );

        db.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();