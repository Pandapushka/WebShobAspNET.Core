using Core.Entity;
using Microsoft.AspNetCore.Identity;
using OnlineShopDB.Constans;

namespace OnlineShopDB
{
    public class IdentityInitializer
    {
        public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminEmail = "admin@gmail.com";
            var password = "_Aa123456";
            if (roleManager.FindByNameAsync(Constant.AdminRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Constant.AdminRoleName)).Wait();
            }
            if (roleManager.FindByNameAsync(Constant.UserRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Constant.UserRoleName)).Wait();
            }
            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                var admin = new User { Email = adminEmail, UserName = adminEmail };
                var result = userManager.CreateAsync(admin, password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, Constant.AdminRoleName).Wait();
                }
            }
        }
    }
}
