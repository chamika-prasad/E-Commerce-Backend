using Models;

namespace Assignment.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int quantity { get; set; }
        public string productName { get; set; }
        public decimal totalPrice { get; set; }
        public string userEmail { get; set; }
        public User User { get; set; }
    }
}
