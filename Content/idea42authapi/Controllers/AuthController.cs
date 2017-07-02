﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Extensions;
using AspNet.Security.OpenIdConnect.Primitives;
using AspNet.Security.OpenIdConnect.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplicationBasic.Models.ApiModels;
using WebApplicationBasic.Models.Entities;

namespace WebApplicationBasic.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("~/token"), Produces("application/json")]
        public async Task<IActionResult> Exchange(OpenIdConnectRequest request)
        {
            if (request.IsPasswordGrantType())
            {
                var signinResult = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

                if (signinResult.Succeeded)
                {
                    var user = _userManager.Users.Where(t=>t.UserName == request.Username).FirstOrDefault();

                    var identity = new ClaimsIdentity(
                        OpenIdConnectServerDefaults.AuthenticationScheme,
                        OpenIdConnectConstants.Claims.Name,
                        OpenIdConnectConstants.Claims.Role);

                    identity.AddClaim(OpenIdConnectConstants.Claims.Subject, user.Id, OpenIdConnectConstants.Destinations.AccessToken);
                    identity.AddClaim(OpenIdConnectConstants.Claims.Name, user.UserName, OpenIdConnectConstants.Destinations.AccessToken);

                    var principal = new ClaimsPrincipal(identity);

                    return SignIn(principal, OpenIdConnectServerDefaults.AuthenticationScheme);
                }
                else{
                    throw new InvalidOperationException("The specified user name and password are invalid");
                }
            }
            throw new InvalidOperationException("The specified grant type is not supported.");
        }

        [HttpPost]
        [Authorize]
        [Route("api/auth/test")]
        public IActionResult Test()
        {
            return Ok(HttpContext.User.Identity.Name);
        }


        [HttpPost]
        [Authorize]
        [Route("api/auth/create")]

        public async Task<IActionResult> Create([FromBody] NewUserRequest login)
        {
            var results = await _userManager.CreateAsync(new ApplicationUser { UserName = login.UserName, FirstName = login.FirstName, LastName = login.LastName }, login.Password);

            if (results.Succeeded)
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
