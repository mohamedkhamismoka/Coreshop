using AutoMapper;
using coreShop.BL.interfaces;
using coreShop.BL.VM;
using coreShop.DAL.Extend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace coreShop.Areas.Admin.Controllers
{[Area("Admin")]
    public class OrderController : Controller
    {
        private readonly UserManager<ApplicationUser> user;
        private readonly RoleManager<IdentityRole> rolemanager;
        private readonly IMapper mapper;
        private readonly Iorder order;
        private readonly IProduct_order Pro_order;

        public OrderController(IProduct_order Pro_order,IMapper mapper, Iorder order, UserManager<ApplicationUser> user, RoleManager<IdentityRole> Rolemanager)
        {
            this.user = user;
            rolemanager = Rolemanager;
            this.mapper = mapper;
            this.order = order;
            this.Pro_order = Pro_order;
        }
        public IActionResult Index()
        {
            var data=Pro_order.GetAll();
           var result=mapper.Map<IEnumerable<Product_OrderVM>>(data);
            return View(result);
        }
    }
}
