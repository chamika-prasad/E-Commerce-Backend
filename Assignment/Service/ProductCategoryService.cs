using Assignment.Error;
using Assignment.Interface;
using Assignment.Request;
using DataAccess;
using Models;

namespace Assignment.Service
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly DatabaseContext _context;
        private CategoryErrorResponseHandler _response;
        public ProductCategoryService(DatabaseContext context)
        {
            _context = context;
        }

        //Get All categories
        public List<Category> GetAllProductcategories() 
        {
            return _context.Categories.ToList();
        }

        //Add Category to database
        public CategoryErrorResponseHandler SaveCategory(ProductCategoryRequest request)
        {
            if (_context.Categories.Any(c => c.name == request.name))
            {
                 _response = SetResponse(false, "Category already exists", request.name, null);
                 return _response;
            }

            try
            {

                var category = new Category
                {
                    name = request.name,
                    description = request.description,

                };

                _context.Categories.Add(category);
                _context.SaveChangesAsync();

                _response = SetResponse(true, "Category added successfully", request.name, category);

            }
            catch (Exception ex)
            {
                _response = SetResponse(false, "Something went wrong", request.name, null);

            }

             return _response;
        }

        //Update Category

        public CategoryErrorResponseHandler UpdateCategory(int id, UpdateProductCategoryRequest request)
        {

            var productcatergory = SelectProductcategory(id);

            if (request.updateName == null && request.updateDescription == null)
            {
                _response = SetResponse(false, "Nothing to Update", null, null);
                return _response;

            }
            
            if(request.updateName != null)
            {
                productcatergory.name = request.updateName;
            }

            if (request.updateDescription != null)
            {
                productcatergory.description = request.updateDescription;
            }
                            
            _context.Categories.Update(productcatergory);
            _context.SaveChangesAsync();

            productcatergory = SelectProductcategory(id);

            _response = SetResponse(true, "Category updated successfully", "Updated", productcatergory);
            return _response;

        }

        //Delete Product Category

        public CategoryErrorResponseHandler DeleteCategory(int id)
        {
            var productcatergory = SelectProductcategory(id);

            try 
            {
                _context.Categories.Remove(productcatergory);
                _context.SaveChangesAsync();
                _response = SetResponse(true, "Category deleted successfully", "Deleted", productcatergory);

            }
            catch(Exception e) 
            {
                _response = SetResponse(false, "Category delete faild", "faild", productcatergory);
            }

            return _response;
        }

        //Search ProductCategory by Id 

        public Category SelectProductcategory(int id)
        {
            return _context.Categories.Find(id);

        }

        //Set Response

        private CategoryErrorResponseHandler SetResponse(bool state, string message, string name, Category detail)
        {
            CategoryErrorResponseHandler response = new CategoryErrorResponseHandler
            {
                State = state,
                Message = message,
                Name = name,
                Detail = detail,
            };

            return response;
        }

    }
}
