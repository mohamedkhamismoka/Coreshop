using coreShop.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.BL.interfaces
{
    public interface IProduct_order
    {
        public void add(int order_id, List<int> products, List<int> quantities);
        public IEnumerable<Product_order> GetAll();
    }
}
