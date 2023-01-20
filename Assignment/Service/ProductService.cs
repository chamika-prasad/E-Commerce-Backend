using Assignment.Error;
using Assignment.Interface;
using Assignment.Request;
using DataAccess;
using Models;

namespace Assignment.Service
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _context;
        private ProductErrorResponseHandler _response;

        public ProductService(DatabaseContext context)
        {
            _context = context;
        }

        //Get All categories
        public List<Product> GetAllProduct()
        {
            return _context.Products.ToList();
        }

        //Add Product to database
        public ProductErrorResponseHandler SaveProduct(ProductRequest request)
        {
            if (_context.Products.Any(p => p.name == request.name && p.categoryId == request.categoryId))
            {
                _response = SetResponse(false, "Product already exists in the category", request.name, null);
                return _response;
            }

            var categary = _context.Categories.Any(c => c.categoryId == request.categoryId);

            if (categary == false)
            {
                _response = SetResponse(false, "Category not valid", request.name, null);
                return _response;
            }

            try
            {

                var product = new Product
                {
                    name = request.name,
                    description = request.description,
                    stock = request.stock,
                    categoryId = request.categoryId,

                };

                _context.Products.Add(product);
                _context.SaveChangesAsync();

                _response = SetResponse(true, "Product added successfully", request.name, product);

            }
            catch (Exception ex)
            {
                _response = SetResponse(false, "Something went wrong", request.name, null);

            }
            return _response;
        }


        //Select Product by Id 

        public Product SelectProduct(int productId)
        {
            return _context.Products.Find(productId);

        }

        //Update Product

        public ProductErrorResponseHandler UpdateProduct(int productId, UpdateProductRequest request)
        {

            var product = SelectProduct(productId);

            if (request.updateName == null && request.updateDescription == null && request.updateStock == null && request.updateCategoryId == null)
            {
                _response = SetResponse(false, "Nothing to Update", null, null);
                return _response;

            }

            if (request.updateName != null)
            {
                if(request.updateCategoryId > 0)
                {
                    if(_context.Products.Any(p => p.name == request.updateName && p.categoryId == request.updateCategoryId))
                    {
                        _response = SetResponse(false, "Product already exists in the category", request.updateName, null);
                        return _response;
                    }
                }
                else
                {
                    if (_context.Products.Any(p => p.name == request.updateName && p.categoryId == product.categoryId))
                    {
                        _response = SetResponse(false, "Product already exists in the category", request.updateName, null);
                        return _response;
                    }
                }
                product.name = request.updateName;
            }

            if (request.updateDescription != null)
            {
                product.description = request.updateDescription;
            }

            if (request.updateStock > -1)
            {
                product.stock = request.updateStock;
            }

            if (request.updateCategoryId > 0)
            {
                if (_context.Products.Any(p => p.name == product.name && p.categoryId == request.updateCategoryId))
                {
                    _response = SetResponse(false, "Product already exists in the category", request.updateName, null);
                    return _response;
                }

                var category = _context.Categories.Any(c => c.categoryId == request.updateCategoryId);

                if (category == false)
                {
                    _response = SetResponse(false, "Category not valid", null, null);
                    return _response;
                }

                product.categoryId = request.updateCategoryId;
            }

            _context.Products.Update(product);
            _context.SaveChangesAsync();

            product = SelectProduct(productId);

            _response = SetResponse(true, "Product updated successfully", "Updated", product);
            return _response;

        }

        //Delete Product

        public ProductErrorResponseHandler DeleteProduct(int productId)
        {
            var product = SelectProduct(productId);

            try
            {
                _context.Products.Remove(product);
                _context.SaveChangesAsync();
                _response = SetResponse(true, "Product deleted successfully", "Deleted", product);

            }
            catch (Exception e)
            {
                _response = SetResponse(false, "Product delete faild", "faild", product);
            }

            return _response;
        }


        public List<Product> SearchProduct(SearchProductRequest request)
        {
            var categoryId = _context.Categories.Where(c => c.name == request.name).Select(c => c.categoryId).FirstOrDefault();
            var productName = _context.Products.Where(p => p.name == request.name).Select(p => p.name).FirstOrDefault();


            if (categoryId != 0 && productName != null)
            {
                return  _context.Products.Where(p => p.categoryId == categoryId || p.name == productName).ToList();
            }

            if(categoryId != 0)
            {
                return _context.Products.Where(p => p.categoryId == categoryId).ToList();
            }

            return _context.Products.Where(p => p.name == request.name).ToList();
                        
        }


        //Set Response

        private ProductErrorResponseHandler SetResponse(bool state, string message, string name, Product detail)
        {
            ProductErrorResponseHandler response = new ProductErrorResponseHandler
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
