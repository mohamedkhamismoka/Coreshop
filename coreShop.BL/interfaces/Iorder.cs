using coreShop.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.BL.interfaces
{
    public interface Iorder
    {
        int create(Order order);
        IEnumerable<Order> GetAll();
    }
}
