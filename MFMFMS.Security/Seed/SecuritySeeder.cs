using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MFMFMS.Security.Models;

namespace MFMFMS.Security.Seed;

public static class SecuritySeeder
{
    public static async Task SeedAdminAsync(
        UserManager<User> userManager)
    {
        var email = Environment.GetEnvironmentVariable("MFMFMS_ADMIN_EMAIL");
        var password = Environment.GetEnvironmentVariable("MFMFMS_ADMIN_PASSWORD");

        var user = await userManager.FindByEmailAsync(email!);

        if (user == null)
        {
            user = new User
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, password!);

            if (!result.Succeeded)
            {
                throw new Exception(
                    string.Join(
                        "; ",
                        result.Errors.Select(x => x.Description)));
            }
        }

        var claims = await userManager.GetClaimsAsync(user);

        if (!claims.Any(x => x.Type == "isAdmin"))
        {
            var result = await userManager.AddClaimAsync(
                user,
                new Claim("isAdmin", "true"));

            if (!result.Succeeded)
            {
                throw new Exception(
                    string.Join(
                        "; ",
                        result.Errors.Select(x => x.Description)));
            }
        }
    }
}