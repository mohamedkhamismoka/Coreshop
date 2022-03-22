using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.DAL.Entity
{
    public class Pay
    {[Key]
    
        public int Id { get; set; }

        public string mail { get; set; }
        public string name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string phone { get; set; }

        public string creditname { get; set; }

        public string Creditnumber { get; set; }
        public int orderid { get; set; }
        [ForeignKey("orderid")]
        public Order order { get; set; }
    }
}
