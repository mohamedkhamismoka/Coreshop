using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.DAL.Entity
{
  public class Product_order
    {
       public int product_id { get; set; }
        public int order_id { get; set; }
        public int quantity { get; set; }
        [ForeignKey("order_id")]
        public Order order { get; set; }
        [ForeignKey("product_id")]
        public Product Product { get; set; }
    }
}
