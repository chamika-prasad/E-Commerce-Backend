using Assignment.Error;
using Assignment.Request;

namespace Assignment.Interface
{
    public interface IOrderService
    {
        public DateTime PlaceOrder(int id, OrderRequest request);
    }
}
