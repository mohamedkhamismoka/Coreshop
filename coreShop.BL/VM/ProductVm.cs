using coreShop.DAL.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.BL.VM
{
    public class ProductVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Quantity Required")]
        [Range(1,1000,ErrorMessage ="Range between 1 and 1000")]
        public int quantity { get; set; }
        [Required(ErrorMessage = "Price Required")]
        [Range(1, 100000, ErrorMessage = "price is not in range")]
        public int price { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [MinLength(3,ErrorMessage ="Min length is 3")]
        public string name { get; set; }
        [Required(ErrorMessage ="Description Required")]
        [MinLength (3,ErrorMessage ="Desription length must be more than 3 letters")]
        public string description { get; set; }
        public string image { get; set; }
        public IFormFile photo {get; set;}

        public IEnumerable<Product_cart> Products { get; set; }
        public IEnumerable<Product_order> product_Orders { get; set; }
    }
}
