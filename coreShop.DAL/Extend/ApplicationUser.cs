using coreShop.DAL.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.DAL.Extend
{
    public class ApplicationUser:IdentityUser
    {
        public string address { get; set; }
        public IEnumerable<Order> orders { get; set; }

        public int cart_id { get; set; }
        [ForeignKey("cart_id")]
        public Cart cart { get; set; }

        public bool isActive { get; set; }
    }
}
