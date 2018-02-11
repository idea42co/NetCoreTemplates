using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBasic.Common;
using WebApplicationBasic.Models.Entities;
using WebApplicationBasic.Services.Contracts;

namespace WebApplicationBasic.Data.DbContexts
{
    public static class ApplicationDbContextExtensions
    {
        public static async Task EnsureSeedData(this ApplicationDbContext context, UserManager<ApplicationUser> userManager, IUserService userService, RoleManager<ApplicationRole> roleManager)
        {
            if (!roleManager.Roles.Any(role => role.Name == ApplicationRoleNames.Admin))
                await roleManager.CreateAsync(new ApplicationRole { Name = ApplicationRoleNames.Admin });

            if (!roleManager.Roles.Any(role => role.Name == ApplicationRoleNames.User))
                await roleManager.CreateAsync(new ApplicationRole { Name = ApplicationRoleNames.User });

            if (!roleManager.Roles.Any(role => role.Name == ApplicationRoleNames.Blocked))
                await roleManager.CreateAsync(new ApplicationRole { Name = ApplicationRoleNames.Blocked });

            if (!context.Users.Where(t => t.NormalizedUserName == "ADMIN").Any())
            {
                var results = await userManager.CreateAsync(new ApplicationUser
                {
                    Email = "admin@admin.com",
                    UserName = "admin",
                }, "P@ssw0rd");
            }
        }
    }
}
