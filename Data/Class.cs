using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Assignment.Models;

namespace Assignment.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = { "Supervisor", "Employee" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create Supervisor
            var supervisor = new ApplicationUser
            {
                UserName = "supervisor@test.com",
                Email = "supervisor@test.com",
                FirstName = "Super",
                LastName = "Visor",
                EmailConfirmed = true
            };

            if (userManager.FindByEmailAsync(supervisor.Email).Result == null)
            {
                await userManager.CreateAsync(supervisor, "Password123!");
                await userManager.AddToRoleAsync(supervisor, "Supervisor");
            }

            var employee = new ApplicationUser
            {
                UserName = "employee@test.com",
                Email = "employee@test.com",
                FirstName = "Em",
                LastName = "Ployee",
                EmailConfirmed = true
            };

            if (userManager.FindByEmailAsync(employee.Email).Result == null)
            {
                await userManager.CreateAsync(employee, "Password123!");
                await userManager.AddToRoleAsync(employee, "Employee");
            }
        }
    }
}
