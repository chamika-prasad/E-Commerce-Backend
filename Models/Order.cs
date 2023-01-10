using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }
        public DateTime date { get; set; }
        public OrderState state { get; set; }
        public string email { get; set; }
        public User user { get; set; }
        public ICollection<ProductOrder> productorders { get; set; }
    }

    public enum OrderState
    {
        Pending,
        Purchase,
        Completed
    }
}
