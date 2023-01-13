using Assignment.Error;
using Assignment.Request;
using Models;

namespace Assignment.Interface
{
    public interface IProductService
    {
        public List<Product> GetAllProduct();
        public ProductErrorResponseHandler SaveProduct(ProductRequest request);
        public Product SelectProduct(int productId);
        public ProductErrorResponseHandler UpdateProduct(int productId, UpdateProductRequest request);
        public ProductErrorResponseHandler DeleteProduct(int productId);
        public List<Product> SearchProduct(SearchProductRequest request);
    }
}
