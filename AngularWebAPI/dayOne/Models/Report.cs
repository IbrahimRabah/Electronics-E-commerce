using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dayOne.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string ReviewBody { get; set; }
      
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

      
        [DefaultValue("false")]
        public bool isDeleted { get; set; }
    }
}
