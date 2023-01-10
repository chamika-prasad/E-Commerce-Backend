using Models;

namespace Assignment.Error
{
    public class UserErrorResponseHandler
    {
        public bool State { get; set; }
        public string User { get; set; }
        public User Detail { get; set; }
        public string Message { get; set; }
    }
}
