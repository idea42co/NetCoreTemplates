using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using WebApplicationBasic.Models.ApiModels;
using WebApplicationBasic.Models.Entities;
using WebApplicationBasic.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using AspNet.Security.OpenIdConnect.Primitives;
using WebApplicationBasic.Common;

namespace WebApplicationBasic.Services
{

    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(UserManager<ApplicationUser> userManager, IRoleService roleService, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _roleService = roleService;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }


        public async Task<ApplicationUser> GetCurrentUser()
        {
            var userId = Guid.Parse(_contextAccessor.HttpContext.User.Claims.Where(t => t.Type == OpenIdConnectConstants.Claims.Subject).First().Value);
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);
            return user;
        }

        public ApplicationUser GetUser(string userName)
        {
            return _userManager.Users.Where(user => user.UserName == userName).FirstOrDefault();
        }

        public async Task<IdentityResult> CreateUser(ApplicationUser user, string password)
        {
            var results = await _userManager.CreateAsync(user, password);

            if (results.Succeeded)
            {
                var newUser = GetUser(user.UserName);

                await _userManager.AddToRoleAsync(newUser, ApplicationRoleNames.User);
            }

            return results;
        }

        public async Task<IdentityResult> UpdateUser(ApplicationUser user)
        {
            var userToUpdate = GetUser(user.UserName);

            if (userToUpdate == null)
                return null;

            userToUpdate = _mapper.Map<ApplicationUser>(user);

            return await _userManager.UpdateAsync(userToUpdate);
        }
    }
}