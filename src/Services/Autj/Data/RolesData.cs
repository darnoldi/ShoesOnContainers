using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

public static class RolesData
{

    private static readonly string[] roles = new[] {
        "SuperUser",
        "Admin",
        "Customer"
    };

    public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
    {

        foreach (var role in roles)
        {

            if (!await roleManager.RoleExistsAsync(role))
            {
                var create = await roleManager.CreateAsync(new IdentityRole(role));

                if (!create.Succeeded)
                {

                    throw new Exception("Failed to create role");

                }
            }

        }

    }

}