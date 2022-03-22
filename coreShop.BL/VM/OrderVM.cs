using coreShop.DAL.Entity;
using coreShop.DAL.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.BL.VM
{
    public class OrderVM
    {
      
        public int id { get; set; }
        public string user_id { get; set; }
        public IEnumerable<Product_order> product_Orders { get; set; }


  
        public ApplicationUser user { get; set; }
    }
}
