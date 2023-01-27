using Assignment.Error;
using Assignment.Model;
using Assignment.Request;
using Azure.Core;
using Models;

namespace Assignment.Interface
{
    public interface IOrderService
    {
        public OrderErrorResponseHandler PlaceOrdersDirect(int productId, OrderRequest request);
        public OrderErrorResponseHandler PlaceOrdersByCart(List<int> cartIds, string userEmail);
        public OrderErrorResponseHandler UpdateOrderState(int orderId, string orderState);
        public OrderErrorResponseHandler AddToCart(int productId, string userEmail,int quantity);
        public List<NewOrder> GetAllOrders();
        public List<Cart> GetAllProductsInCart(string userEmail);

    }
}
