using Models;

namespace Assignment.Error
{
    public class CategoryErrorResponseHandler
    {
        public bool State { get; set; }
        public string Name { get; set; }
        public Category Detail { get; set; }
        public string Message { get; set; }
    }
}
