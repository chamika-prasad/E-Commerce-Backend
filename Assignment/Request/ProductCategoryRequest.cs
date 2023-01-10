using System.ComponentModel.DataAnnotations;

namespace Assignment.Request
{
    public class ProductCategoryRequest
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }


    }
}
