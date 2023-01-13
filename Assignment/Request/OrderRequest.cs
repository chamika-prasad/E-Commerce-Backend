using System.ComponentModel.DataAnnotations;

namespace Assignment.Request
{
    public class OrderRequest
    {

        [Required]
        public int quantity { get; set; }

        [Required]
        public string userEmail { get; set; }
    }
}
