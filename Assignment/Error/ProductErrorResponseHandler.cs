using Models;

namespace Assignment.Error
{
    public class ProductErrorResponseHandler
    {
        public bool State { get; set; }
        public string Name { get; set; }
        public Product Detail { get; set; }
        public string Message { get; set; }
    }
}
