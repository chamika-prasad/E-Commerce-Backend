using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Category
    {
        public int categoryId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
