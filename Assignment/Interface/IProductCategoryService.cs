using Assignment.Error;
using Assignment.Request;
using Models;

namespace Assignment.Interface
{
    public interface IProductCategoryService
    {
        public CategoryErrorResponseHandler SaveCategory(ProductCategoryRequest request);
        public CategoryErrorResponseHandler UpdateCategory(int categoryId, UpdateProductCategoryRequest request);
        public Category SelectProductcategory(int categoryId);
        public List<Category> GetAllProductcategories();
        public CategoryErrorResponseHandler DeleteCategory(int categoryId);


    }
}
