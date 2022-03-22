using AutoMapper;
using coreShop.BL.interfaces;
using coreShop.BL.VM;
using coreShop.DAL.Entity;
using coreShop.DAL.Extend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace coreShop.Areas.Client.Controllers
{
    [Area("Client")]
    public class CheckoutController : Controller
    {
        private readonly IProduct product;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userman;
        private readonly ICart cart;
        private readonly IProduct_cart Prod_cart;
        private readonly IProduct_order prod;
        private readonly Iorder order;
        private readonly IPAy Pays;

        public CheckoutController(IPAy Pays,IProduct_order prod,Iorder order,IProduct_cart Prod_cart, IProduct product, IMapper mapper, UserManager<ApplicationUser> userman, ICart cart)
        {
            this.product = product;
            this.mapper = mapper;
            this.userman = userman;
            this.cart = cart;
            this.Prod_cart = Prod_cart;
            this.prod = prod;
            this.order = order;
            this.Pays = Pays;
        }
        [HttpGet]
        public IActionResult Pay(int id)
        {
            List<Product> products = new List<Product>();   
   var data=Prod_cart.GetById(id);
            ViewBag.count = Prod_cart.GETCount(id);
          
            var result = mapper.Map<IEnumerable<Product_cartVM>>(data);
            ViewBag.Products = result;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Pay(PayVM pay,string user)
        {
          
            ApplicationUser userdata = await userman.FindByEmailAsync(user);
            var user_id = userdata.Id;
            var cart = userdata.cart_id;

            try
            {
              
                if (ModelState.IsValid)
                {
                    List<int> products = new List<int>();
                    List<int> quantities = new List<int>();
                  
                    var payy = pay;


                    OrderVM ord = new OrderVM()
                    {
                        user_id = user_id
                    };


                    var res = mapper.Map<Order>(ord);
                    int order_id = order.create(res);
                    payy.orderid = order_id;
                    var pp = mapper.Map<Pay>(payy);
                    Pays.create(pp);
                    var data = Prod_cart.GetById(cart);
                    foreach (var item in data)
                    {
                        if (item.saveforlater == false)
                        {
                            products.Add(item.product_id);
                            quantities.Add(item.quantity);
                          
                        }
                       
                    }

                    prod.add(order_id, products, quantities);
                    product.decrement(products, quantities);

                    return RedirectToAction("Index", "Client", new { area = "Client",id=cart });
                }
                var data2 = Prod_cart.GetById(cart);
                ViewBag.count = Prod_cart.GETCount(cart);

                var result = mapper.Map<IEnumerable<Product_cartVM>>(data2);
                ViewBag.Products = result;
                return View(pay);
            }
            catch(Exception ex)
            {
                var data = Prod_cart.GetById(cart);
                ViewBag.count = Prod_cart.GETCount(cart);

                var result = mapper.Map<IEnumerable<Product_cartVM>>(data);
                ViewBag.Products = result;
                return View(pay);
            }
          
        }
    }
}
