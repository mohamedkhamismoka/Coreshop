using AutoMapper;
using coreShop.BL.interfaces;
using coreShop.BL.VM;
using coreShop.DAL.Entity;
using coreShop.DAL.Extend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace coreShop.Areas.Client.Controllers
{
    [Area("Client")]
    public class CartController : Controller
    {

        private readonly IProduct product;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userman;
        private readonly ICart cart;
        private readonly IProduct_cart Prod_cart;
        private readonly IProduct Product;
        public CartController(IProduct Product,IProduct_cart Prod_cart, IProduct product, IMapper mapper, UserManager<ApplicationUser> userman, ICart cart)
        {
            this.product = product;
            this.mapper = mapper;
            this.userman = userman;
            this.cart = cart;
            this.Prod_cart = Prod_cart;
            this.Product = product;
        }


        [HttpGet]
        public IActionResult Index(int cart)
        {
         int[]products= Prod_cart.GetProducts(cart);
            IEnumerable<Product> data = product.Getspecial(products);
            ViewBag.count =Prod_cart.GETCount(cart);
            var result=mapper.Map< IEnumerable<ProductVm>>(data);
            ViewBag.cart = cart;
            return View(result);
        }

        [HttpPost]
        public JsonResult Load(int[] products, int cart)
        {
            
            for (int i = 0; i < products.Length; i++)
            {
                Product_cart pc = new Product_cart()
                {
                    cart_id = cart,
                    product_id = products[i],
                    saveforlater = false,
                    quantity = 1

                };
                Prod_cart.create(pc);

            }
            return Json(new { prods=products,cart=cart});
        }
        [HttpPost]
        public JsonResult check(int product_id,int cart_id)
        {

            bool x=Prod_cart.existin(cart_id,product_id);
            int y = 0;
            if (x == true)
            {
                y = 1;
            }
        
            return Json(new {state=y});
        }
        [HttpPost]
        public JsonResult CheckProduct(int product_id,int cart_id ,int quantity)
        {
            int x = 0;
            int y = y = Prod_cart.get_count_in_cart(cart_id, product_id); ;
            var count = product.GetById(product_id).quantity;
            if(count >= quantity)
            {
                x = 1;
                Prod_cart.changeQuantity(product_id, cart_id, quantity);
                y = 0;
            }
     

            return Json(new { state = x,count=y });
        }
        [HttpPost]
        public JsonResult Remove(int product_id, int cart_id)
        {
            int x = 0;
            try
            {
                Prod_cart.Delete(cart_id, product_id);
                x = 1;
                return Json(new { state = x });
            }catch(Exception e)
            {
                return Json(new { state = x });
            }
           

           
        }
        [HttpPost]
        public JsonResult ChangeState(int product_id, int cart_id)
        {
            int x = 0;
            try
            {
                Prod_cart.ChangeState(product_id, cart_id);
                x = 1;
                return Json(new { state = x });
            }
            catch (Exception e)
            {
                return Json(new { state = x });
            }



        }

    }
}
