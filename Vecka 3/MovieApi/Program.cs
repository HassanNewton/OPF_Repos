using Microsoft.EntityFrameworkCore;
using MovieApi.Data;



namespace MovieApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // =====================================================
            // REGISTRERING AV TJÄNSTER (Dependency Injection)
            // =====================================================

            // Lägger till stöd för Controllers (API endpoints)
            // Detta gör att ASP.NET kan hitta och köra våra Controllers
            builder.Services.AddControllers();

            // -----------------------------------------------------
            // DATABAS (Entity Framework Core)
            // -----------------------------------------------------
            // Här talar vi om för ASP.NET:
            // "När någon behöver MovieDbContext,
            //  skapa den med SQL Server och denna connection string"
            //
            // DbContext används i Controllers via constructor injection
            builder.Services.AddDbContext<MovieDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                )
            );

            // -----------------------------------------------------
            // SWAGGER / OPENAPI
            // -----------------------------------------------------

            // AddEndpointsApiExplorer:
            // Scannar alla Controllers och endpoints
            // och gör dem tillgängliga för OpenAPI/Swagger
            builder.Services.AddEndpointsApiExplorer();

            // AddSwaggerGen:
            // Skapar Swagger-dokumentet och möjliggör Swagger UI
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // =====================================================
            // HTTP REQUEST PIPELINE
            // =====================================================

            // Swagger ska bara köras i Development-miljö
            // (inte i produktion)
            if (app.Environment.IsDevelopment())
            {
                // Genererar swagger.json
                app.UseSwagger();

                // Visar det grafiska Swagger UI:t
                // där vi kan testa alla endpoints
                app.UseSwaggerUI();
            }

            // Tvingar HTTP-trafik att redirectas till HTTPS
            app.UseHttpsRedirection();

            // Används för autentisering/auktorisering
            // (just nu har vi inga policies, men den är redo)
            app.UseAuthorization();

            // Kopplar Controllers till routing-systemet
            app.MapControllers();

            app.Run();
        }
    }
}
