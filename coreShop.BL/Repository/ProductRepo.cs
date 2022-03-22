using coreShop.BL.interfaces;
using coreShop.BL.VM;
using coreShop.DAL.Database;
using coreShop.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.BL.Repository
{
    public class ProductRepo : IProduct
    {
        private readonly DataContext data;

        public ProductRepo(DataContext data)
        {
            this.data = data;
        }

        public void create(Product product)
        {
            data.Products.Add(product);
            data.SaveChanges();
        }

        public void decrement(List<int>id, List<int> quantity)
        {
            for (int i = 0; i < id.Count; i++)
            {
                var ele = data.Products.Find(id[i]);
                ele.quantity = ele.quantity - quantity[i];
            }
           
            data.SaveChanges();
        }

        public void delete(int id)
        {
            var ele = data.Products.Find(id);
            data.Products.Remove(ele);
            data.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            var eles = data.Products.Select(a => a);
            return eles;
        }

        public Product GetById(int id)
        {
            var ele = data.Products.Find(id);
            return ele;
        }

        public List<Product> Getspecial(int[] ids)
        {List<Product> products = new List<Product>();  
            foreach (var item in ids)
            {
                var res=data.Products.Find(item);
                products.Add(res);
            }
            return products;
        }

        public void update(Product product)
        {
            data.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            data.SaveChanges();
        }

    }
}
