using coreShop.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.BL.VM
{
    public class Product_cartVM
    {
        public int cart_id { get; set; }
        public int product_id { get; set; }

        public bool saveforlater { get; set; }

        public int quantity { get; set; }
   
        public Cart cart { get; set; }
     
        public Product product { get; set; }
    }
}
