using Microsoft.AspNetCore.Identity;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        if (!await roleManager.RoleExistsAsync("Admin"))
            await roleManager.CreateAsync(new IdentityRole("Admin"));

        var admin = await userManager.FindByEmailAsync("admin@admin.com");
        if (admin == null)
        {
            var user = new IdentityUser { UserName = "admin@admin.com", Email = "admin@admin.com", EmailConfirmed = true };
            await userManager.CreateAsync(user, "Admin123!");
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
