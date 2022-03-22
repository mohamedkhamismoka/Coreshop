using coreShop.BL.interfaces;
using coreShop.DAL.Database;
using coreShop.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.BL.Repository
{
   
    public class Product_orderRepo:IProduct_order
    {
        private readonly DataContext data;

        public Product_orderRepo(DataContext Data)
        {
            data = Data;
        }

        public void add(int order_id,List<int> products, List<int> quantities)
        {
            for (int i = 0; i < products.Count; i++)
            {
                Product_order prod = new Product_order()
                { order_id = order_id,
                    product_id = products[i],
                    quantity = quantities[i],

                };
                data.product_Orders.Add(prod);
            
        
            }
            data.SaveChanges();


        }

        public IEnumerable<Product_order> GetAll()
        {
            var result= data.product_Orders.Include(a=>a.Product).Include(a=>a.order).Include(a=>a.order.user).Select(a=>a);
            return result;
        }
    }
    }

