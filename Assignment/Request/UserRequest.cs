using System.ComponentModel.DataAnnotations;

namespace Assignment.Request
{
    public class UserRequest
    {
        [Required, EmailAddress]
        public string email { get; set; }

        [Required, MinLength(6)]
        public string password { get; set; }
    }
}
