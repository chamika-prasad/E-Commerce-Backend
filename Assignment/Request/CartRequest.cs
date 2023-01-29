using System.ComponentModel.DataAnnotations;

namespace Assignment.Request
{
    public class CartRequest
    {
        [Required]
        public List<int> cartIds { get; set; }
    }
}
