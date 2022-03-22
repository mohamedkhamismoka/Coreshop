using coreShop.DAL.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.DAL.Entity
{
    public class Cart
    {
        [Key]
        
        public int ID { get; set; }
        public IEnumerable<Product_cart> Products_carts { get; set; }
     
        public ApplicationUser user { get; set; }
    }
}
