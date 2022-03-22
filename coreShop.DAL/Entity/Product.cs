using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.DAL.Entity
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }

        public IEnumerable<Product_cart> Product_carts { get; set; }
        public IEnumerable<Product_order> product_Orders { get; set; }
    }
}
