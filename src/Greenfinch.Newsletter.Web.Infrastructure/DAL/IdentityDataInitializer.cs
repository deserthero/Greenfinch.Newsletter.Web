using Greenfinch.Newsletter.Web.Common;
using Greenfinch.Newsletter.Web.Common.Interfaces;
using Greenfinch.Newsletter.Web.Core.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Greenfinch.Newsletter.Web.Infrastructure.EF.DAL
{
    /// <summary>
    /// Used to Seed Default users and roles.
    /// </summary>
    public static class IdentityDataInitializer
    {

        public static void SeedData(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager, IAppConfigManager appConfigManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager, appConfigManager);
        }


        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {

            if (!roleManager.RoleExistsAsync(UserRole.Administrator.ToString()).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = UserRole.Administrator.ToString();
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }


        public static void SeedUsers(UserManager<IdentityUser> userManager, IAppConfigManager appConfigManager)
        {
            var adminUserName = appConfigManager.GetAppSettingsValueOrDefault<string>("SampleAdminUserName", "admin");

            if (userManager.FindByNameAsync(adminUserName).Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = adminUserName;
                user.Email = appConfigManager.GetAppSettingsValueOrDefault<string>("SampleAdminEmail", "admin@admin.com");
                var password = appConfigManager.GetAppSettingsValueOrDefault<string>("SampleAdminPassword", "P@ssW0rd@!");  
                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, UserRole.Administrator.ToString()).Wait();
                }
            }
        }

    }



}
