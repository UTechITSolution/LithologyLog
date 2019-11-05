using LithologyLog.Constant;
using LithologyLog.Model;
using LithologyLog.Web.Lang;
using LithologyLog.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading.Tasks;

namespace LithologyLog.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<UserApp> _signInManager;
        private LocalizerService _localizerService;

        public AccountController(UserManager<UserApp> userManager, 
                                 RoleManager<ApplicationRole> roleManager, 
                                 SignInManager<UserApp> signInManager,
                                 LocalizerService localizerService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _localizerService = localizerService;
        }

        public IActionResult Login()
        {
        
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                ModelState.AddModelError("", _localizerService["NotFoundUser"]);
                return View(model);
            }

            if (user.Status == false)
            {
                ModelState.AddModelError("", _localizerService["Blocked"]);

                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user,
                model.Password,
                model.RememberMe,
                true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", _localizerService["LockedOut"]);
                return View(model);
            }
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", _localizerService["WrongPassword"]);

            return View(model);
        }

        #region Logout
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }

        #endregion

        public IActionResult AccessDenied()
        {
            return View();
        }
    }

}