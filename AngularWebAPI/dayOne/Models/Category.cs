using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dayOne.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DefaultValue("false")]
        public bool isDeleted { get; set; }
        public IEnumerable<Product>? Products { get; set; }

    }
}
