using Microsoft.EntityFrameworkCore;
using MyApi.ProductionLike.Data;
using MyApi.ProductionLike.Models;
using MyApi.ProductionLike.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers + automatisk validering via [ApiController]
builder.Services.AddControllers();

// Swagger (bra för lektion + test)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core DbContext (Scoped)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Service-lager (Scoped, samma livslängd som DbContext)
builder.Services.AddScoped<IProductService, ProductService>();


// ------------------------------------------------------------
// CORS – Cross-Origin Resource Sharing
// ------------------------------------------------------------
//
// CORS behövs när frontend och backend körs på OLIKA origins
// (t.ex. frontend: http://localhost:5500
//        backend:  https://localhost:5001)
//
// Browsern blockerar annars anropen.
//
builder.Services.AddCors(options =>
{
options.AddPolicy("FrontendPolicy", policy =>
{
    policy
        // ÄNDRA DENNA URL TILL DIN FRONTEND
        // Exempel:
        // - http://localhost:5500 (Live Server, VS Code)
        // - http://localhost:5173 (Vite)
        // - http://localhost:3000 (React)
        .WithOrigins("http://localhost:5500")

        // Tillåt alla HTTP-metoder (GET, POST, PUT, DELETE)
        .AllowAnyMethod()

        // Tillåt alla headers (Content-Type, Authorization m.m.)
        .AllowAnyHeader();

    // Om du använder cookies eller auth-token i framtiden:
    // .AllowCredentials();
});


// ------------------------------------------------------------
// Redo för AI-labb (nästa steg):
// Här registrerar man t.ex. en AI-service som använder en extern klient.
//
// Exempel:
// builder.Services.AddSingleton<IAiImageService, AzureOpenAiImageService>();
// ------------------------------------------------------------

var app = builder.Build();

// Seed-data för att API:t inte ska vara tomt första gången.
// Här använder vi EnsureCreated för enkel start.
//
// I ett "riktigt" EF Core-workflow:
// - ta bort EnsureCreated
// - kör migrations (dotnet ef migrations add + update)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Products.Any())
    {
        db.Products.AddRange(
            new Product { Name = "Pen", Price = 10, CreatedUtc = DateTime.UtcNow },
            new Product { Name = "Book", Price = 50, CreatedUtc = DateTime.UtcNow }
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