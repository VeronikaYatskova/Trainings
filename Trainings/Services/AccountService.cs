using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Trainings.Data.Models;
using Trainings.Data.Models.Identity;
using Trainings.Models.Request;
using Trainings.Services.Abstracts;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Trainings.Services
{
    public class AccountService : IAccountService
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<User> GetUserAsync(ClaimsPrincipal claimsPrincipal) =>
            await userManager.GetUserAsync(claimsPrincipal);

        public async Task<IdentityResult> Register(UserModel user)
        {
            var appUser = new User
            {
                UserName = user.Name,
                Email = user.Email
            };

            var result = await userManager.CreateAsync(appUser, user.Password);
            if (result.Succeeded)
            {
                await Login(new Login
                {
                    Email = user.Email,
                    Password = user.Password,
                });
            }

            return result;
        }

        public async Task<SignInResult?> Login(Login login)
        {
            var appUser = await userManager.FindByEmailAsync(login.Email);
            if (appUser != null)
            {
                await signInManager.SignOutAsync();
                var result = await signInManager.PasswordSignInAsync(appUser, login.Password, login.Remember, false);
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }
    }
}
