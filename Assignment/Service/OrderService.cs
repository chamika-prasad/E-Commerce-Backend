using Assignment.Error;
using Assignment.Interface;
using Assignment.Model;
using Assignment.Request;
using DataAccess;

namespace Assignment.Service
{
    public class OrderService : IOrderService
    {

        private readonly DatabaseContext _context;
        private OrderErrorResponseHandler _response;

        public OrderService(DatabaseContext context)
        {
            _context = context;
        }

        //place order
        public OrderErrorResponseHandler PlaceOrder(int productId, OrderRequest request)
        {

            var stock = _context.Products.Where(p => p.productId == productId).Select(p => p.stock).FirstOrDefault();

            stock = stock - request.quantity;

            if (stock < 0)
            {
                _response = SetResponse(false, "Quantity exceed stock", null, null);
                return _response;
            }
            var date = DateTime.Now;

            var order = new NewOrder
            {
                date = date,
                userEmail = request.userEmail,
                productId = productId,
                quantity = request.quantity,
                state = State.Pending,
            };

            _context.NewOrders.Add(order);
            _context.SaveChangesAsync();

            Thread.Sleep(5000);

            //update stock

            var product = _context.Products.Find(productId);

            product.stock = stock;

            _context.Products.Update(product);
            _context.SaveChangesAsync();

            _response = SetResponse(true, "Order placed successful", null, null);
            return _response;

        }

        //Get all orders

        public List<NewOrder> GetAllOrders()
        {
            return _context.NewOrders.ToList();
        }

        //Update order state

        public OrderErrorResponseHandler UpdateOrderState(int orderId,string orderState)
        {
            var order = _context.NewOrders.Find(orderId);

            if(orderState == "accepted") 
            {
                order.state = State.Accept;
            }
            else if (orderState == "decline")
            {
                order.state = State.Decline;
            }
            else
            {
                _response = SetResponse(false, "Order updated faild", null, null);
            }

            _context.NewOrders.Update(order);
            _context.SaveChangesAsync();

            _response = SetResponse(true, "Order updated successful", null, order);
            return _response;
        }


            //Set Response
            private OrderErrorResponseHandler SetResponse(bool state, string message, string name, NewOrder detail)
            {
                OrderErrorResponseHandler response = new OrderErrorResponseHandler
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
