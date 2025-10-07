using Assignment.Models;
using Microsoft.AspNetCore.Identity;

namespace Assignment.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "Supervisor", "Employee" };
            foreach (var role in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            var supEmail = "supervisor@example.com";
            var supervisor = await userManager.FindByEmailAsync(supEmail);
            if (supervisor == null)
            {
                supervisor = new ApplicationUser
                {
                    UserName = "supervisor",
                    Email = supEmail,
                    FirstName = "Sam",
                    LastName = "Supervisor",
                    EmailConfirmed = true
                };
                var res = await userManager.CreateAsync(supervisor, "P@ssword123!");
                if (res.Succeeded)
                {
                    await userManager.AddToRoleAsync(supervisor, "Supervisor");
                }
            }
        }
    }
}