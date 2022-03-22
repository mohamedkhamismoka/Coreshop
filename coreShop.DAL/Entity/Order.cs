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
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string user_id { get; set; }
        public IEnumerable<Product_order> product_Orders { get; set; }


        [ForeignKey("user_id")]
        public ApplicationUser user { get; set; }

   
        public Pay payment { get; set; }
    }
}
