using AutoMapper;
using coreShop.BL.interfaces;
using coreShop.BL.VM;
using coreShop.DAL.Extend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace coreShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> user;
        private readonly RoleManager<IdentityRole> rolemanager;
        private readonly IMapper mapper;
        private readonly Iorder order;


        public UsersController(IMapper mapper,Iorder order,UserManager<ApplicationUser> user,  RoleManager<IdentityRole> Rolemanager)
        {
            this.user = user;
            rolemanager = Rolemanager;
            this.mapper = mapper;
            this.order = order; 
        }
        public IActionResult Index()
        {
            var data = user.Users; 
             ViewBag.roles=rolemanager.Roles;
            return View(data);
        }


        public async Task<IActionResult> StateChange(string id)
        {
            ApplicationUser appuser = await user.FindByIdAsync(id);
            if (appuser.isActive)
            {
                appuser.isActive = false;
            }
            else
            {
                appuser.isActive = true;
            }
          await user.UpdateAsync(appuser);
             return RedirectToAction("Index");
              
        }

        public async Task<IActionResult> Details(string id)
        {
            ApplicationUser applicationUser= await user.FindByIdAsync(id);
            ViewBag.roles = rolemanager.Roles;
            return View(applicationUser);

        }


        public async Task<IActionResult> Profile(string name)
        {
            ApplicationUser applicationUser = await user.FindByNameAsync(name);
            ViewBag.roles = rolemanager.Roles;
            return View(applicationUser);

        }
    }
}
