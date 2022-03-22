using AutoMapper;
using coreShop.BL.interfaces;
using coreShop.BL.VM;
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
    public class Product_cartRepo : IProduct_cart
    {
        private readonly DataContext data;
        private readonly IProduct product;
        private readonly IMapper mapper;
        public Product_cartRepo(DataContext data, IProduct product, IMapper mapper)
        {
            this.data = data;
            this.product = product;
            this.mapper = mapper;
        
        }

        public void create(Product_cart pc)
        {
          data.product_Carts.Add(pc);
            data.SaveChanges();
        }

     
        public void Delete(int card_id, int product_id)
        {
           var res= data.product_Carts.Where(a => a.cart_id == card_id && a.product_id == product_id).FirstOrDefault();
            data.product_Carts.Remove(res);
            data.SaveChanges();
        }

        public bool existin(int card_id, int product_id)
        {
          if(data.product_Carts.Where(a=>a.product_id==product_id && a.cart_id == card_id).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GETCount(int id)
        {
        int count  = data.product_Carts.Include(a=>a.product).Where(a=>a.cart_id==id).Count();
            return count;
        }

        public int[] GetProducts(int id)
        {
         int[]ids=  data.product_Carts.Where(a=>a.cart_id==id&&a.saveforlater==false).Select(a=>a.product_id).ToArray();
            return ids;
        }

        public IEnumerable<ProductVm> GEtSavaed(int cart_id)
        {
            var res = data.product_Carts.Where(a => a.cart_id == cart_id && a.saveforlater == true).Select(a=>a.product_id);
            List<ProductVm> list = new List<ProductVm>(); 
            foreach (var item in res)
            {
                var ele=product.GetById(item);
                
                var results=mapper.Map<ProductVm>(ele);
                list.Add(results);
                
            }
            return list;
        }
        public void ChangeState(int product_id,int cart_id)
        {
            
            var res=data.product_Carts.Where(a => a.product_id == product_id && a.cart_id == cart_id).FirstOrDefault();
            res.saveforlater = true;
            data.SaveChanges();
            
            
        }

        public void changeQuantity(int product_id, int cart_id, int quantity)
        {
            var res = data.product_Carts.Where(a => a.product_id == product_id && a.cart_id == cart_id).FirstOrDefault();
res.quantity= quantity;
            data.SaveChanges();


        }
        public IEnumerable<Product_cart> GetById(int cart_id)
        {
            var res = data.product_Carts.Include(a=>a.product).Where(a => a.cart_id == cart_id);
            return res;

        }
        public int get_count_in_cart(int cart,int product)
        {
            var res = data.product_Carts.Where(a => a.cart_id == cart&&a.product_id==product).FirstOrDefault();
            return res.quantity;
        } 

    }
}
