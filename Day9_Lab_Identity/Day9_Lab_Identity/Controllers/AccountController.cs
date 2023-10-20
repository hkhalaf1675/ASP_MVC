using Day9_Lab_Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Day9_Lab_Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> _userManager,SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        [HttpGet]
        public IActionResult Registeration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registeration(RegisterAccountsViewModel newAccount,string ReturnUrl = "/Categories/Index")
        {
            if (ModelState.IsValid)
            {
                // map from viewModel class to Identity Model
                IdentityUser user = new IdentityUser();
                user.UserName = newAccount.UserName;
                user.Email = newAccount.EmailAddress;

                // Save user and create cookie --------------------> to save user , to hash password
                IdentityResult result = await userManager.CreateAsync(user, newAccount.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                    // create cookie
                    // the responsible of creating cookie is SignInManager Repositary
                    await signInManager.SignInAsync(user, isPersistent: false);
                    // false to make it per session : when close the session while be deleted
                    // if true : need to duration

                    return LocalRedirect(ReturnUrl);
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(newAccount);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginAccountViewModel account,string ReturnUrl = "/Categories/Index")
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByEmailAsync(account.Email);
                if(user != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, account.Password, account.IsPersiste, false);
                    if (result.Succeeded)
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    ModelState.AddModelError("", "Invalid Email Or Password");
                }
                ModelState.AddModelError("", "InCorrect Email or password");
            }
            return View(account);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
