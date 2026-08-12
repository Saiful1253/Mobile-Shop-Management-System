using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MobileShopManagementSystem.Core.Models;
using MobileShopManagementSystem.Services.Interfaces;
using MobileShopManagementSystem.Web.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;

namespace MobileShopManagementSystem.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null, string? tab = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            ViewData["Tab"] = tab;
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AdminLogin(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> AdminLogin(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && await _userManager.IsInRoleAsync(user, "Admin"))
                    return RedirectToArea("Admin", "Home", "Index");
                await _signInManager.SignOutAsync();
                ModelState.AddModelError("", "Access denied. Admin only.");
            }
            ModelState.AddModelError("", "Invalid email or password.");
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult CustomerLogin(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> CustomerLogin(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && await _userManager.IsInRoleAsync(user, "Customer"))
                    return RedirectToArea("Customer", "Home", "Index");
                await _signInManager.SignOutAsync();
                ModelState.AddModelError("", "Access denied. Customer account only.");
            }
            ModelState.AddModelError("", "Invalid email or password.");
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser { FullName = model.FullName, UserName = model.Email, Email = model.Email, EmailConfirmed = true, PhoneNumber = model.Phone };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home", new { area = "Customer" });
            }
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    await _signInManager.SignOutAsync();
                    ModelState.AddModelError("", "Invalid email or password.");
                    return View(model);
                }

                if (model.Tab == "customer")
                {
                    if (await _userManager.IsInRoleAsync(user, "Customer"))
                        return RedirectToAction("Index", "Home", new { area = "Customer" });
                    await _signInManager.SignOutAsync();
                    ModelState.AddModelError("", "Access denied. Customer account only.");
                }
                else
                {
                    if (await _userManager.IsInRoleAsync(user, "Admin") || await _userManager.IsInRoleAsync(user, "Staff"))
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    await _signInManager.SignOutAsync();
                    ModelState.AddModelError("", "Access denied. Staff account only.");
                }
            }
            ModelState.AddModelError("", "Invalid email or password.");
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied() => View();

        private IActionResult RedirectToArea(string area, string controller, string action)
        {
            return RedirectToAction(action, controller, new { area = area });
        }

        private IActionResult RedirectToLocal(string? returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Index", "Home");
        }
    }
}
