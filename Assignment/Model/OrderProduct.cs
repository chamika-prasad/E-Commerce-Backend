using Funq;
using Models;

namespace Assignment.Model
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public NewOrder Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
