using System.Threading.Tasks;
using WebApplicationBasic.Models.Entities;
using Microsoft.AspNetCore.Identity;
using WebApplicationBasic.Models.ApiModels;

namespace WebApplicationBasic.Services.Contracts
{
    public interface IUserService
    {
        Task<ApplicationUser> GetCurrentUser();

        ApplicationUser GetUser(string userName);

        Task<IdentityResult> CreateUser(ApplicationUser user, string password);

        Task<IdentityResult> UpdateUser(ApplicationUser user);
    }
}