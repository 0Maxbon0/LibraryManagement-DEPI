using LibraryManagement.BLL.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using Microsoft.Extensions.Logging;
using System.Linq;
using LibraryManagement.DAL.Db;

namespace LibraryManagement.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Users> signInManager;
        private readonly UserManager<Users> userManager;
        private readonly ILogger<AccountController> logger;
        private readonly AppDbContext dbContext;

        public AccountController(SignInManager<Users> signInManager, UserManager<Users> userManager, ILogger<AccountController> logger, AppDbContext dbContext)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    AddModelError("Email or password is incorrect.");
                    return View(model);
                }
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var user = new Users
                {
                    UserName = model.Email,
                    FullName = model.FullName,
                    Email = model.Email,
                };

                try
                {
                    var result = await userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            AddModelError(error.Description);
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while registering a user.");
                    AddModelError("An unexpected error occurred. Please try again.");
                }
            }
            return View(model);
        }

        public IActionResult VerifyEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Email);

                if (user == null)
                {
                    AddModelError("Something is wrong!");
                    return View(model);
                }
                else
                {
                    return RedirectToAction("ChangePassword", "Account", new { username = user.UserName });
                }
            }
            return View(model);
        }

        public IActionResult ChangePassword(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("VerifyEmail", "Account");
            }
            return View(new ChangePasswordDto { Email = username });
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Email);
                if (user != null)
                {
                    var removePasswordResult = await userManager.RemovePasswordAsync(user);
                    if (removePasswordResult.Succeeded)
                    {
                        var addPasswordResult = await userManager.AddPasswordAsync(user, model.NewPassword);
                        if (addPasswordResult.Succeeded)
                        {
                            return RedirectToAction("Login", "Account");
                        }
                        else
                        {
                            foreach (var error in addPasswordResult.Errors)
                            {
                                AddModelError(error.Description);
                            }
                        }
                    }
                    else
                    {
                        foreach (var error in removePasswordResult.Errors)
                        {
                            AddModelError(error.Description);
                        }
                    }
                }
                else
                {
                    AddModelError("Email not found!");
                }
            }
            else
            {
                AddModelError("Something went wrong. Please try again.");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // New Methods to Manage Reviews and Reservations

        public async Task<IActionResult> MyReviews()
        {
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {
                var reviews = dbContext.Reviews.Where(r => r.UserID == user.Id).ToList();
                return View(reviews);
            }
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> MyReservations()
        {
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {
                var reservations = dbContext.Reservations.Where(r => r.UserID == user.Id).ToList();
                return View(reservations);
            }
            return RedirectToAction("Login");
        }

        private void AddModelError(string error)
        {
            ModelState.AddModelError("", error);
        }
    }
}
