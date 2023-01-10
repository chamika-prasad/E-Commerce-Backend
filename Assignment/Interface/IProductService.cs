using Assignment.Error;
using Assignment.Request;
using Models;

namespace Assignment.Interface
{
    public interface IProductService
    {
        public List<Product> GetAllProduct();
        public ProductErrorResponseHandler SaveProduct(ProductRequest request);
        public Product SelectProduct(int id);
        public ProductErrorResponseHandler UpdateProduct(int id, UpdateProductRequest request);
        public ProductErrorResponseHandler DeleteProduct(int id);
        public List<Product> SearchProduct(SearchProductRequest request);
    }
}
