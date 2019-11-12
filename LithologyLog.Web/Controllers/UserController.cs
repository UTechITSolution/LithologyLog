using LithologyLog.Model;
using LithologyLog.Web.Lang;
using LithologyLog.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LithologyLog.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private LocalizerService _localizerService;

        public UserController(UserManager<UserApp> userManager,
                              RoleManager<ApplicationRole> roleManager,
                              LocalizerService localizerService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _localizerService = localizerService;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Create()
        {
            UserCreateViewModel model = new UserCreateViewModel();

            FillRoleDropDown();

            return PartialView("_Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Create(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_userManager.Users.Any(u => u.UserName != model.UserName))
                {
                    var user = new UserApp()
                    {
                        UserName = model.UserName,
                        Status = model.Status,
                    };

                    var userInsertResult = await _userManager.CreateAsync(user, model.Password);

                    if (userInsertResult.Succeeded)
                    {
                        var roleNames = model.GetRoles ?? new List<string>();

                        foreach (var roleName in roleNames)
                        {
                            await _userManager.AddToRoleAsync(user, roleName);
                        }

                        return Json(new { status = 200, message = _localizerService["Success" });
                    }

                    foreach (var error in userInsertResult.Errors.ToList())
                    {
                        return Json(new
                        {
                            status = 406,
                            message = error
                        });

                    }
                }
                return Json(new { status = 207, message = _localizerService["AleadyTakenUsername"] });
            }

            return Json(new { status = 407, message = _localizerService["ModelNotValid"] });
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return Json(new { status = 404, message = _localizerService["NotFoundUser"] });
            }

            FillRoleDropDown();

            var selectedRoles = await _userManager.GetRolesAsync(user);

            var model = new UserEditViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Status = user.Status,
                GetRoles = selectedRoles
            };

            return PartialView("_Edit", model); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Edit(UserEditViewModel model)
        {
            var list = new List<SelectListItem>();

            foreach (var role in _roleManager.Roles)
            {
                list.Add(new SelectListItem() { Value = role.Name, Text = role.Name });
            }

            if (ModelState.IsValid)
            {
                if (!_userManager.Users.Any(u => u.UserName == model.UserName && u.Id != model.Id))
                {
                    var user = await _userManager.FindByIdAsync(model.Id);

                    if (user == null)
                    {
                        return Json(new
                        {
                            status = 404,
                            message = _localizerService["NotFoundUser"]
                        });
                    }

                    user.UserName = model.UserName;

                    user.Status = model.Status;

                    if (!string.IsNullOrEmpty(model.Password))
                    {
                        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                    }

                    var editUserResult = await _userManager.UpdateAsync(user);

                    if (editUserResult.Succeeded)
                    {
                        var selectedRoles = model.GetRoles ?? new List<string>();

                        var userRoles = await _userManager.GetRolesAsync(user);

                        var deletedRoles = userRoles.Except(selectedRoles);

                        var addedRoles = selectedRoles.Except(userRoles);

                        await _userManager.AddToRolesAsync(user, addedRoles);

                        await _userManager.RemoveFromRolesAsync(user, deletedRoles);


                        return Json(new { status = 200, message = _localizerService["Success"] });
                    }
                    return Json(new { status = 406, message = _localizerService["Error"] });
                }
                return Json(new { status = 207, message = _localizerService["AleadyTakenUsername"] });
            }
            return Json(new { status = 407, message = _localizerService["ModelNotValid"] });
        }



        private void FillRoleDropDown()
        {
            var availableRoles = new List<SelectListItem>();

            foreach (var role in _roleManager.Roles)
            {
                availableRoles.Add(new SelectListItem() { Value = role.Name, Text = role.Name });
            }

            ViewBag.Roles = availableRoles;
        }


    }
}