using System.ComponentModel.DataAnnotations;

namespace Assignment.Request
{
    public class ProductRequest
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public int stock { get; set; }

        [Required]
        public int categoryId { get; set; }

        [Required]
        public decimal price { get; set; }
    }
}
