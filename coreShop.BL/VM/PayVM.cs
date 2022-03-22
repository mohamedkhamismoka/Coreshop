using coreShop.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.BL.VM
{
    public class PayVM
    {
       
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Mail")]
        public string mail { get; set; }

        [Required(ErrorMessage = "name Required")]
     [MinLength(10,ErrorMessage ="Min length = 10")]
        public string name { get; set; }

        [Required(ErrorMessage = "Address Required")]
        [RegularExpression("[0-9]{2,5}-[a-zA-Z]{1,50}-[a-zA-Z]{1,50}-[a-zA-Z]{1,50}", ErrorMessage = "address must like 12-Street name-cityname-countryname")]

        public string Address { get; set; }
        [Required(ErrorMessage = "City Required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Phone Required")]
        [Phone(ErrorMessage ="Enter valid phone")]
        public string phone { get; set; }



        [Required(ErrorMessage = "Name on Credit Required")]
        [MinLength(10, ErrorMessage = "Min length = 10")]
        public string creditname { get; set; }
        //[CreditCard(ErrorMessage = "Enter valid Credit number")]
        [Required(ErrorMessage = "Credit number Required")]
        public string Creditnumber { get; set; }
        public int orderid { get; set; }
        public Order order { get; set; }
    }
}
