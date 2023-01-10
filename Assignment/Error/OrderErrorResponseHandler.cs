using Models;

namespace Assignment.Error
{
    public class OrderErrorResponseHandler
    {
        public bool State { get; set; }
        public string Name { get; set; }
        public Order Detail { get; set; }
        public string Message { get; set; }
    }
}
