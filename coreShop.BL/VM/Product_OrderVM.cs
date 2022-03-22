using coreShop.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.BL.VM
{
    public class Product_OrderVM
    {
        public int product_id { get; set; }
        public int order_id { get; set; }
        public int quantity { get; set; }
  
        public Order order { get; set; }
     
        public Product Product { get; set; }
    }
}
