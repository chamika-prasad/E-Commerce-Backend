using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductOrder
    {
        [Key]
        public int Id { get; set; }
        public int productId { get; set; }
        public Product product { get; set; }
        public int orderId { get; set; }
        public Order Order { get; set; }
    }
}
