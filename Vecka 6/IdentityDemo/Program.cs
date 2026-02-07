using IdentityDemo.Data_;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IdentityDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // "Vi säger till appen: använd AuthDbContext och koppla den mot SQL Server med connection string."

            builder.Services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnection")));

            // "AddDefaultIdentity lägger in all standardfunktionalitet: users, hashing, cookies, login."
            // "AddEntityFrameworkStores säger: spara allt i vår AuthDbContext."

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                // ===== Password settings =====
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 4;

                // ===== User settings =====
                options.User.RequireUniqueEmail = false;
            })
                .AddRoles<IdentityRole>()   // <-- NY RAD GENOMGÅNG 2
.AddEntityFrameworkStores<AuthDbContext>();

            //GENOMGÅNG 2
            builder.Services.AddAuthorization(options =>
            {
                //“Policy är ett NAMN på en regel.
                //Regeln är: kräver rollen Admin.”
                options.AddPolicy("AdminOnly",
                    policy => policy.RequireRole("Admin"));
            });


            // "Här säger vi: mappen /Member kräver inloggning."
            // "Om man inte är inloggad → redirect till login-sidan (Identity default)."

            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Member");
                options.Conventions.AuthorizeFolder("/Admin", "AdminOnly");
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Index";
                options.AccessDeniedPath = "/NoAccess";
            });

            var app = builder.Build();

            // "Authentication måste ligga före Authorization."
            // "Först identifierar vi användaren, sen kollar vi vad den får göra."


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Skapa rollen om den inte finns
                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Admin"));

                // Skapa admin-användare om den inte finns
                var admin = await userManager.FindByNameAsync("admin");

                if (admin == null)
                {
                    admin = new ApplicationUser { UserName = "admin" };
                    await userManager.CreateAsync(admin, "admin");
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }

            app.Run();
        }
    }
}


//Skapa Razor Pages-projekt utan färdig auth

//Installera EF Core + Identity NuGet-paket

//Skapa Data/-mapp för DB/Identity-kod

//Skapa ApplicationUser (utökad användarmodell)

//Skapa AuthDbContext : IdentityDbContext<ApplicationUser>

//Lägg connection string i appsettings.json

//Konfigurera i Program.cs:

//AddDbContext

//AddDefaultIdentity + AddEntityFrameworkStores

//AuthorizeFolder("/Member")

//UseAuthentication före UseAuthorization

//Kör migrations:

//Add - Migration

//Update - Database

//Skapa Pages/Index för Register/Login

//Skapa Pages/Member/Index för skyddad sida + Logout


//vad som görs stegvis

//Lägger till .AddRoles<IdentityRole>()

//Skapar en policy "AdminOnly" som kräver rollen Admin

//Skyddar /Admin med policy

//Skapar NoAccess-sida

//Kopplar AccessDeniedPath

//Skapar /Admin-mapp och sida

//Använder ServiceProvider för att:

//skapa rollen Admin

//skapa första admin-användaren

//tilldela rollen