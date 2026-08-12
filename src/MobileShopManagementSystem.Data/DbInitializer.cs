using Microsoft.AspNetCore.Identity;
using MobileShopManagementSystem.Core.Models;

namespace MobileShopManagementSystem.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await context.Database.EnsureCreatedAsync();

            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (!await roleManager.RoleExistsAsync("Staff"))
                await roleManager.CreateAsync(new IdentityRole("Staff"));
            if (!await roleManager.RoleExistsAsync("Customer"))
                await roleManager.CreateAsync(new IdentityRole("Customer"));

            var adminEmail = "tanvinislam3273@gmail.com";
            var admin = await userManager.FindByEmailAsync(adminEmail);

            if (admin == null)
            {
                var oldAdmin = await userManager.FindByEmailAsync("admin@mobileshop.com");
                if (oldAdmin != null)
                {
                    await userManager.DeleteAsync(oldAdmin);
                }

                admin = new ApplicationUser { FullName = "Admin", UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
                var result = await userManager.CreateAsync(admin, "Tanvin0123!");
                if (result.Succeeded)
                {
                await userManager.AddToRoleAsync(admin, "Admin");
            }

            var customerEmail = "customer@mobileshop.com";
            var customer = await userManager.FindByEmailAsync(customerEmail);

            if (customer == null)
            {
                customer = new ApplicationUser { FullName = "Customer", UserName = customerEmail, Email = customerEmail, EmailConfirmed = true };
                var custResult = await userManager.CreateAsync(customer, "Customer123!");
                if (custResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(customer, "Customer");
                }
            }
        }
    }
}
}
