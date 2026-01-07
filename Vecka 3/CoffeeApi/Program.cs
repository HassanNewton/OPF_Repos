
using CoffeeApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CoffeeApi
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            // ======================================
            // SERVICES (Dependency Injection)
            // ======================================

            builder.Services.AddControllers();

            // -------- DATABASE (EF Core + SQL Server)
            builder.Services.AddDbContext<CoffeeDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                )
            );

            // -------- DAL
            builder.Services.AddScoped<CoffeeRepository>();

            // -------- CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            // -------- Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // ======================================
            // PIPELINE
            // ======================================

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Aktiverar CORS
            app.UseCors("AllowAll");

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
