using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.DAL.Entity
{
   public class Product_cart
    {
        public int cart_id { get; set; }
        public int product_id { get; set; }

        public bool saveforlater { get; set; }

        public int quantity { get; set; }   
        [ForeignKey("cart_id")]
        public Cart cart { get; set; }
        [ForeignKey("product_id")]
        public Product product { get; set; }
    }
}
