using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ServiceStack.DataAnnotations;

namespace Assignment.Request
{
    public class UpdateProductRequest
    {
        [ValidateNever]
        public string updateName { get; set; }

        [ValidateNever]
        public string updateDescription { get; set; }

        [Required]
        public int updateStock { get; set; }

        [Required]
        public int updateCategoryId { get; set; }
    }
}
