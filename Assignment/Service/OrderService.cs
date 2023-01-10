using Assignment.Error;
using Assignment.Interface;
using Assignment.Request;
using DataAccess;
using Funq;
using Models;
using ServiceStack.Text;
using System.Security.Cryptography;
using System.Text;

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
        public DateTime PlaceOrder(int id,OrderRequest request)
        {
            var random = new Random();
            var value = random.Next(0, 100000);
            var randomString = value.ToString();
            var date = DateTime.Now;
            var transactionId = SetTransactionId(request.email,date.ToString(),randomString);

            //try 
            //{
                var order = new Order
                {
                    //orderId = 1,
                    //email = request.email,
                    email = "user@gmail.com",
                    //date = date,
                    //state = OrderState.Pending,
                    //transactionid = transactionId,
                    transactionid = "ddfg",

                };

                _context.Orders.Add(order);
                _context.SaveChangesAsync();

                return date;

              /*  var orderId = _context.Orders.Where(o => o.transactionid == transactionId).Select(o => o.orderId).FirstOrDefault();

                return transactionId;

                var productOrder = new ProductOrder
                    {
                        productId = id,
                        orderId = orderId,
                    };

                _context.ProductOrders.Add(productOrder);
                _context.SaveChangesAsync();

                var stock = _context.Products.Where(p => p.productId == id).Select(p => p.stock).FirstOrDefault();

                stock = stock - request.quantity;

                if (stock < 0)
                    {
                        _response = SetResponse(false,"Quantity exceed stock",null,null);

                       // return _response;
                    }

                var product = _context.Products.Find(id);

                product.stock = stock;

                _context.Products.Update(product);
                _context.SaveChangesAsync();

                _response = SetResponse(true, "Order placed successfully", null, null);*/

           // }
           // catch(Exception e) 
           // {
             //   _response = SetResponse(false, "Order placed faild", null, null);
           // }

            // return _response;
            //return date;
        }

        //Set Response
        private OrderErrorResponseHandler SetResponse(bool state, string message, string name, Order detail)
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

        //Create Transaction Id
        private static string SetTransactionId(string email, string time, string randomString)
        {
            var mySecretString = email + time + randomString;

            return Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(mySecretString)));
        }
    }
}
