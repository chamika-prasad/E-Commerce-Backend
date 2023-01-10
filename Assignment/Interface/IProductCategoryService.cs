using Assignment.Error;
using Assignment.Request;
using Models;

namespace Assignment.Interface
{
    public interface IProductCategoryService
    {
        public CategoryErrorResponseHandler SaveCategory(ProductCategoryRequest request);
        public CategoryErrorResponseHandler UpdateCategory(int id, UpdateProductCategoryRequest request);
        public Category SelectProductcategory(int id);
        public List<Category> GetAllProductcategories();
        public CategoryErrorResponseHandler DeleteCategory(int id);


    }
}
