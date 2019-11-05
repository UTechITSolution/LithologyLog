using LithologyLog.Constant;
using LithologyLog.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace LithologyLog.Web.Helper
{
    public static class DbInitializer
    {
        public static async Task Seed(
            UserManager<UserApp> userManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration)
        {

            if (!await roleManager.RoleExistsAsync(ROLECONSTANT.Admin))
            {
                await roleManager.CreateAsync(new ApplicationRole(ROLECONSTANT.Admin));
            }

            if (!await roleManager.RoleExistsAsync(ROLECONSTANT.Moderator))
            {
                await roleManager.CreateAsync(new ApplicationRole(ROLECONSTANT.Moderator));
            }

            if (!await roleManager.RoleExistsAsync(ROLECONSTANT.Operator))
            {
                await roleManager.CreateAsync(new ApplicationRole(ROLECONSTANT.Operator));
            }

            if (await userManager.FindByEmailAsync(configuration["AdminSettings:Email"]) == null)
            {
                var admin = new UserApp()
                {
                    Email = configuration["AdminSettings:Email"],
                    UserName = configuration["AdminSettings:Username"],
                    Status = true
                };
                var result = await userManager.CreateAsync(admin, configuration["AdminSettings:Password"]);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, ROLECONSTANT.Admin);
                }
            }
        }
    }
}
