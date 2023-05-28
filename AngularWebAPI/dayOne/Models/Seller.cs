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
    public enum status
    {
        confirmed,
        waiting,
        rejected
    }
    public class Seller
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int Age { get; set; }
        public double Balance { get; set; }
        public string NationalIdImage { get; set; }
        [DefaultValue("waiting")]
        public status Status { get; set; }
        public IEnumerable<Product>? Products { get; set; }


    }
}
