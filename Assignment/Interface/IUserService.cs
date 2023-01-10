using Assignment.Error;
using Assignment.Request;
using Models;

namespace Assignment.Interface
{
    public interface IUserService
    {
        public UserErrorResponseHandler UserRegistration(UserRequest request);
        public UserErrorResponseHandler UserLoging(UserRequest request);
        public User GetUser(UserRequest request);

    }
}
