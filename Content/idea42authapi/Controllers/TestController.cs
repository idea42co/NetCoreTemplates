using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using WebApplicationBasic.Services.Contracts;

namespace WebApplicationBasic.Controllers
{
    [Produces("application/json")]
    [Route("api/Test")]
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    public class TestController : Controller
    {
        private readonly IUserService _userService;

        public TestController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Get()
        {
            var currentUser = await _userService.GetCurrentUser();
            return Ok($"Test success! You are {currentUser.UserName}!");
        }
    }
}