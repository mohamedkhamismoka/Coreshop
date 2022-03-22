using AutoMapper;
using coreShop.BL.interfaces;
using coreShop.BL.VM;
using coreShop.DAL.Extend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace coreShop.Areas.Client.Controllers
{
    [Area("Client")]
    public class ClientController : Controller
    {
        private readonly IProduct product;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userman;
        private readonly ICart cart;
        private readonly IProduct_cart Prod_cart;
        public ClientController(IProduct_cart Prod_cart,IProduct product,IMapper mapper, UserManager<ApplicationUser> userman, ICart cart)
        {
           this.product = product;  
            this.mapper = mapper;
            this.userman = userman; 
            this.cart = cart;
            this.Prod_cart = Prod_cart;
        }
        public IActionResult Index(int id)
        {

            var count = Prod_cart.GETCount(id);
            ViewBag.Count = count;
            ViewBag.cart = id;
            var data=product.GetAll();
            var result = mapper.Map <IEnumerable<ProductVm>>(data);
            return View(result);
        }
    }
}
