using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using coreShop.BL.VM;
using coreShop.DAL.Entity;

namespace coreShop.BL.Automapper
{
    public class Domainprofile:Profile
    {
        public Domainprofile()
        {
            CreateMap<ProductVm, Product>();
            CreateMap<Product, ProductVm>();
            CreateMap<Product_cart,Product_cartVM>();
            CreateMap<Product_cartVM, Product_cart>();
            CreateMap<OrderVM, Order>();
            CreateMap<Order, OrderVM>();
            CreateMap<PayVM, Pay>();
            CreateMap<Pay, PayVM>();
            CreateMap<Product_order, Product_OrderVM>();
            CreateMap<Product_OrderVM, Product_order>();
        }
    }
}
