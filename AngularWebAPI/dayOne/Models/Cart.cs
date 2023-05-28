using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dayOne.Models
{
    public class Cart
    {
      

        public IEnumerable<ProductCart>? CartProducts { get; set; }
        [Key]
        [ForeignKey("Customer")]
        public string CustomerCartId { get; set; }
        public Customer? Customer{ get; set; }


        [DefaultValue("false")]
        public bool isDeleted { get; set; }
    }
}
