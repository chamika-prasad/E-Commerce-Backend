using Assignment.Error;
using Assignment.Model;
using Assignment.Request;

namespace Assignment.Interface
{
    public interface IOrderService
    {
        public OrderErrorResponseHandler PlaceOrder(int productId, OrderRequest request);
        public OrderErrorResponseHandler UpdateOrderState(int orderId, string orderState);
        public List<NewOrder> GetAllOrders();

    }
}
