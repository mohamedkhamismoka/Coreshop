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
    public class OrderRepo : Iorder
    {
        private readonly DataContext data;
        public OrderRepo(DataContext data)
        {
            this.data = data;
        }
       
        public int create(Order order)
        {
            data.Orders.Add(order);
            data.SaveChanges();
            return data.Orders.OrderByDescending(a => a.id).First().id;
        }

        public IEnumerable<Order> GetAll()
        {
            var result = data.Orders.Include(a => a.user).Select(a => a);
            return result;
        }
    }
}
