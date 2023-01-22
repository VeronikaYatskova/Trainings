using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Trainings.Data.Models.Identity;
using Trainings.Models.Request;
using Trainings.Services.Abstracts;

namespace Trainings.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await accountService.GetUserAsync(HttpContext.User);
            string message = "Hello " + user.UserName;

            return View((object)message);
        }

        [AllowAnonymous]
        public IActionResult Register() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await accountService.Register(userModel);

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }

            return View(userModel);
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            Login login = new Login();
            login.ReturnUrl = returnUrl;

            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = await accountService.Login(login);
                if (result is null)
                {
                    ModelState.AddModelError(nameof(login.Email), "Login Failed: Invalid Email or password");
                }
                else if (result.Succeeded)
                {
                    return Redirect(login.ReturnUrl ?? "/");
                }
            }

            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await accountService.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}
