using Microsoft.AspNetCore.Identity;
using WebApplicationBasic.Common;
using WebApplicationBasic.Models.Entities;
using WebApplicationBasic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBasic.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleService(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task EnsureRoles()
        {
            if (!_roleManager.Roles.Any(role => role.Name == ApplicationRoleNames.Admin))
                await _roleManager.CreateAsync(new ApplicationRole { Name = ApplicationRoleNames.Admin });

            if (!_roleManager.Roles.Any(role => role.Name == ApplicationRoleNames.User))
                await _roleManager.CreateAsync(new ApplicationRole { Name = ApplicationRoleNames.User });

            if (!_roleManager.Roles.Any(role => role.Name == ApplicationRoleNames.Blocked))
                await _roleManager.CreateAsync(new ApplicationRole { Name = ApplicationRoleNames.Blocked });
        }
    }
}
