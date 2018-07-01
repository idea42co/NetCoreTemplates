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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplicationBasic.Models.ApiModels;
using WebApplicationBasic.Models.Entities;
using WebApplicationBasic.Services.Contracts;
using AutoMapper;
using System.IO;
using AspNet.Security.OAuth.Validation;

namespace WebApplicationBasic.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/user/create")]
        public async Task<IActionResult> Create([FromBody] NewUserRequest request)
        {
            var results = await _userService.CreateUser(_mapper.Map<ApplicationUser>(request), request.Password);

            if (results.Succeeded)
            {
                return Ok(new { message = "Created" });
            }
            else
            {
                return BadRequest(results.Errors);
            }
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        [Route("api/user/update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request)
        {
            var results = await _userService.UpdateUser(_mapper.Map<ApplicationUser>(request));

            if (results.Succeeded)
            {
                return Ok(new { message = "Updated" });
            }
            else
            {
                return BadRequest(results.Errors);
            }
        }
    }
}
