using AutoMapper;
using coreShop.BL.interfaces;
using coreShop.BL.Services;
using coreShop.BL.VM;
using coreShop.DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace coreShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProduct product;
        private readonly IMapper mapper;

        public ProductController(IProduct product, IMapper mapper)
        {
            this.product = product;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = product.GetAll();
            var result = mapper.Map<IEnumerable<ProductVm>>(data);
            return View(result);
        }
      
        public IActionResult Create()
        {
           return View();
        }

        [HttpPost]
        public IActionResult Create(ProductVm prd)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (prd.photo != null)
                    {


                        var data = product.GetAll();

                        var imgname = imageUploader.uploader("images", prd.photo);
                        prd.image = imgname;

                        var res = mapper.Map<Product>(prd);
                        product.create(res);
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        ViewBag.imgwarn = "Please specify image";
                        return View(prd);
                    }



                }
                return View(prd);

            }
            catch (Exception ex)
            {
                return View(prd);
            }
        }





        public IActionResult Update(int id)
        {
            var data=product.GetById(id);
            var result = mapper.Map<ProductVm>(data);
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(ProductVm prd,string img)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (prd.photo == null)
                    {


                      

                  

                        var res = mapper.Map<Product>(prd);
                        res.image = img;
                        product.update(res);
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        var imgname = imageUploader.uploader("images", prd.photo);
                        prd.image = imgname;
                        var res = mapper.Map<Product>(prd);
                       

                        product.update(res);
                        return RedirectToAction("Index");
                    }



                }
               
                prd.image = img;
                return View(prd);

            }
            catch (Exception ex)
            {
                prd.image = img;
                return View(prd);
            }
        }


        public IActionResult Details(int id)
        {
            var data = product.GetById(id);
            var res = mapper.Map<ProductVm>(data);
            return View(res);

        }
        public IActionResult Delete(int id)
        {
            var data = product.GetById(id);
            var res = mapper.Map<ProductVm>(data);
            return View(res);
        }
        [ActionName("Delete")]
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            product.delete(id);
            return RedirectToAction("Index");
        }

    }
}
            
       
  

