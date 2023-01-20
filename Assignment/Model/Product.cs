using Assignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public int productId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int stock { get; set; }
        public int categoryId { get; set; }
        public Category category { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

    }
}

//public ICollection<NewOrder> neworders { get; set; }
