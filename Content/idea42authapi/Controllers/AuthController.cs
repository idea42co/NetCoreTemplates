using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Extensions;
using AspNet.Security.OpenIdConnect.Primitives;
using AspNet.Security.OpenIdConnect.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplicationBasic.Models.ApiModels;
using WebApplicationBasic.Models.Entities;
using WebApplicationBasic.Services.Contracts;
using WebApplicationBasic.Common;

namespace WebApplicationBasic.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IUserService userService, IRoleService roleService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userService = userService;
            _roleService = roleService;
        }



        [HttpPost("~/token"), Produces("application/json")]
        public async Task<IActionResult> Exchange(OpenIdConnectRequest request)
        {
            if (request.IsPasswordGrantType())
            {
                await _roleService.EnsureRoles();

                if (_userManager.Users.Count() == 0)
                {
                    var results = await _userManager.CreateAsync(new ApplicationUser
                    {
                        Email = "admin@admin.com",
                        UserName = "admin@admin.com",
                    }, "P@ssw0rd");

                    var adminUser = _userService.GetUser("admin@admin.com");

                    await _userManager.AddToRolesAsync(adminUser, new List<string> { ApplicationRoleNames.Admin, ApplicationRoleNames.User });
                }

                var user = _userManager.Users.Where(t => t.UserName.ToLower() == request.Username.ToLower()).FirstOrDefault();

                if (user == null)
                    return NotFound(new { message = "The specified user name and password are invalid" });

                var signinResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (signinResult.Succeeded)
                {
                    var identity = new ClaimsIdentity(
                        OpenIdConnectServerDefaults.AuthenticationScheme,
                        OpenIdConnectConstants.Claims.Name,
                        OpenIdConnectConstants.Claims.Role);

                    identity.AddClaim(OpenIdConnectConstants.Claims.Subject, user.Id.ToString(), OpenIdConnectConstants.Destinations.AccessToken);
                    identity.AddClaim(OpenIdConnectConstants.Claims.Name, user.UserName, OpenIdConnectConstants.Destinations.AccessToken);

                    var principal = new ClaimsPrincipal(identity);

                    return SignIn(principal, OpenIdConnectServerDefaults.AuthenticationScheme);
                }
                else
                {
                    return NotFound(new { message = "The specified user name and password are invalid" });
                }
            }
            return NotFound(new { message = "The specified grant type is not supported." });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/auth/create")]
        public async Task<IActionResult> Create([FromBody] NewUserRequest login)
        {
            var results = await _userManager.CreateAsync(new ApplicationUser { UserName = login.UserName }, login.Password);

            if (results.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(results.Errors);
            }
        }
    }
}
