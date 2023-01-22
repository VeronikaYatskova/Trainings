using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Trainings.Data.Models;
using Trainings.Data.Models.Identity;
using Trainings.Models.Request;

namespace Trainings.Services.Abstracts
{
    public interface IAccountService
    {
        Task<User> GetUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<IdentityResult> Register(UserModel user);
        Task<SignInResult?> Login(Login login);
        Task Logout();
    }
}
