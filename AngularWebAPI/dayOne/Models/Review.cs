using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dayOne.Models
{
    public class Review
    {
        public int Id { get; set; }
     
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [DefaultValue("false")]
        public bool isDeleted { get; set; }
    }
}
