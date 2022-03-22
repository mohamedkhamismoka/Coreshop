using coreShop.BL.VM;
using coreShop.DAL.Extend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace coreShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {

        private readonly UserManager<ApplicationUser> usermanager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signmanager;

        public AdminController(UserManager<ApplicationUser> usermanager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signmanager)
        {
            this.usermanager = usermanager;
            this.roleManager = roleManager;
            this.signmanager = signmanager;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult GetRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {

            var result = await roleManager.CreateAsync(model);

            if (result.Succeeded)
            {
                return RedirectToAction("GetRoles");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return RedirectToAction("GetRoles");
            }


        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {

            var role = await roleManager.FindByIdAsync(id);

            if (role != null)
            {
                return View(role);
            }

            return RedirectToAction("GetRoles");

        }


        [HttpPost]
        public async Task<IActionResult> Edit(IdentityRole model)
        {

            var role = await roleManager.FindByIdAsync(model.Id);

            if (role != null)
            {

                role.Name = model.Name;


                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("GetRoles");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                    return RedirectToAction("GetRoles");
                }

            }

            return RedirectToAction("GetRoles");


        }



        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {

            var role = await roleManager.FindByIdAsync(id);

            if (role != null)
            {
                return View(role);
            }

            return RedirectToAction("GetRoles");

        }


        [HttpPost]
        public async Task<IActionResult> Delete(IdentityRole model)
        {

            var role = await roleManager.FindByIdAsync(model.Id);

            if (role != null)
            {

                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("GetRoles");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                    return RedirectToAction("GetRoles");
                }

            }

            return RedirectToAction("GetRoles");


        }


        [HttpGet]
        public async Task<IActionResult> EditUserInRole(string id)
        {

            ViewBag.RoleId = id;

            var role = await roleManager.FindByIdAsync(id);

            if (role != null)
            {

                var model = new List<UserInRoleVM>();

                foreach (var user in usermanager.Users)
                {
                    var userInRole = new UserInRoleVM()
                    {
                        UserId = user.Id,
                        UserName = user.UserName
                    };

                    if (await usermanager.IsInRoleAsync(user, role.Name))
                    {
                        userInRole.IsSelected = true;
                    }
                    else
                    {
                        userInRole.IsSelected = false;
                    }

                    model.Add(userInRole);
                }


                return View(model);

            }


            return RedirectToAction("Edit", new { id = role.Id });

        }


        [HttpPost]
        public async Task<IActionResult> EditUserInRole(List<UserInRoleVM> model, string id)
        {

            var role = await roleManager.FindByIdAsync(id);

            if (role != null)
            {

                for (int i = 0; i < model.Count; i++)
                {

                    var user = await usermanager.FindByIdAsync(model[i].UserId);

                    IdentityResult result = null;

                    if (model[i].IsSelected && !(await usermanager.IsInRoleAsync(user, role.Name)))
                    {

                        result = await usermanager.AddToRoleAsync(user, role.Name);

                    }
                    else if (!model[i].IsSelected && (await usermanager.IsInRoleAsync(user, role.Name)))
                    {
                        result = await usermanager.RemoveFromRoleAsync(user, role.Name);
                    }
                    else
                    {
                        continue;
                    }

                }

                return RedirectToAction("Edit", new { id = role.Id });

            }

            return RedirectToAction("Edit", new { id = role.Id });
        }






    }
}

