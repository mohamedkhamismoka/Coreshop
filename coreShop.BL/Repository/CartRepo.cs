using coreShop.BL.interfaces;
using coreShop.DAL.Database;
using coreShop.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.BL.Repository
{
    public class CartRepo:ICart
    {
        private readonly DataContext data;

        public CartRepo(DataContext data)
        {
            this.data = data;
        }

        public int create()
        {
            var res=data.carts.Count();
            Cart c = new Cart();
            if(res==0)
            {
                c.ID = 1;
            }
            else
            {
               var id= data.carts.OrderByDescending(a => a.ID).First().ID;
                c.ID = id + 1;
            }

            data.carts.Add(c);

            data.SaveChanges();
            return data.carts.OrderByDescending(a => a.ID).First().ID;
        }

        public void Delete(int id)
        {
            var ele = data.carts.Find(id);
            data.carts.Remove(ele);
            data.SaveChanges();
        }

        public void update(Cart cart)
        {
            data.Entry(cart).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            data.SaveChanges();
        }
    }
}
