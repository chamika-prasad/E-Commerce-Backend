using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        public int orderId { get; set; }
       // public DateTime date { get; set; }
        //public OrderState state { get; set; }
        public string transactionid { get; set; }
        public string email { get; set; }
        public ICollection<ProductOrder> productorders { get; set; }
    }

    public enum OrderState
    {
        Pending,
        Decline,
        Completed
    }
}
