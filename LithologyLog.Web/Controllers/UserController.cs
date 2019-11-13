using LithologyLog.Model;
using LithologyLog.Web.Lang;
using LithologyLog.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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


        public IActionResult LoadDataForTable()
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            // Skiping number of Rows count
            var start = Request.Form["start"].FirstOrDefault();
            // Paging Length 10,20
            var length = Request.Form["length"].FirstOrDefault();
            // Sort Column Name
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            // Sort Column Direction ( asc ,desc)
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            // Search Value from (Search box)
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            //Paging Size (10,20,50,100)
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var model = _userManager.Users.Select(x => new UserList
            {
                Id = x.Id,
                UserName = x.UserName,
                Status = x.Status ? _localizerService["Active"] : _localizerService["Deactive"]
            });

            if (!string.IsNullOrEmpty(searchValue))
            {
                model = model.Where(m => m.UserName == searchValue
                                             || m.UserName.StartsWith(searchValue));
            }

            //total number of rows count 
            recordsTotal = model.Count();
            //Paging 
            var data = model.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }


        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
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
                if (!_userManager.Users.Any(u => u.UserName == model.UserName))
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

                        return Json(new { status = 200, message = _localizerService["Success"] });
                    }

                    return Json(new { status = 200, message = _localizerService["Error"] });
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

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Json(new
                {
                    status = 404,
                    message = _localizerService["NotFoundUser"]
                });
            }

            var model = await _userManager.FindByIdAsync(id);
            if (model == null)
            {
                return Json(new
                {
                    status = 404,
                    message = _localizerService["NotFoundUser"]
                });
            }

            IdentityResult result = await _userManager.DeleteAsync(model);

            if (result.Succeeded)
            {
                return Json(new { status = 200, message = _localizerService["Success"] });
            }

            foreach (var error in result.Errors.ToList())
            {
                return Json(new
                {
                    status = 406,
                    message = error
                });
            }

            return Json(new { status = 406, message = _localizerService["Error"] });
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