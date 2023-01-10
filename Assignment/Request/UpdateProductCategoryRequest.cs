using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Assignment.Request
{
    public class UpdateProductCategoryRequest
    {
        [ValidateNever]
        public string updateName { get; set; }

        [ValidateNever]
        public string updateDescription { get; set; }
    }
}
