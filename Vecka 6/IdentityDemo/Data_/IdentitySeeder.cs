using Microsoft.AspNetCore.Identity;

namespace IdentityDemo.Data_
{
    public static class IdentitySeeder
    {
        public static async Task SeedAdminAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            const string adminRole = "Admin";
            const string adminUser = "admin";
            const string adminPass = "admin";

            if (!await roleManager.RoleExistsAsync(adminRole))
                await roleManager.CreateAsync(new IdentityRole(adminRole));

            var user = await userManager.FindByNameAsync(adminUser);

            if (user == null)
            {
                user = new ApplicationUser { UserName = adminUser };
                await userManager.CreateAsync(user, adminPass);
                await userManager.AddToRoleAsync(user, adminRole);
            }
        }
    }
}
