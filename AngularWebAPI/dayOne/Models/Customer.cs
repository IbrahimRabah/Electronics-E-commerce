using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace dayOne.Models
{
    public class Customer
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
       
        public Cart? Cart { get; set; }

        public IEnumerable<Order> Orders { get; set; }
        

    }
}
