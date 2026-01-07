
using ChalkboardChat.Data.Contexts;
using ChalkboardChat.Logic.Services;
using ChalkboardChat.Ui.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace ChalkboardChat.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AppDb")));

            builder.Services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("AuthDb")));

            builder.Services
    .AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<AuthDbContext>();

            builder.Services.AddScoped<MessageService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();  // MÅSTE komma före Authorization
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
