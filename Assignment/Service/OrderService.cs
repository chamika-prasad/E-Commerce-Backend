using Assignment.Error;
using Assignment.Interface;
using Assignment.Model;
using Assignment.Request;
using Azure.Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        //place order directly

        public OrderErrorResponseHandler PlaceOrdersDirect(int productId, OrderRequest request)
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
                state = State.Pending,
            };

            _context.NewOrders.Add(order);
            _context.SaveChangesAsync();

            Thread.Sleep(1000);

            var oderId = _context.NewOrders.Where(o => o.date == date && o.userEmail == request.userEmail && o.state == State.Pending).Select(o => o.Id).FirstOrDefault();

            var orderproduct = new OrderProduct
            {
                ProductId = productId,
                OrderId = oderId,
            };

            _context.OrderProducts.Add(orderproduct);
            _context.SaveChangesAsync();

            Thread.Sleep(2000);

            //update stock

            var product = _context.Products.Find(productId);

            product.stock = stock;

            _context.Products.Update(product);
            _context.SaveChangesAsync();

            _response = SetResponse(true, "Order placed successful", null, null);
            return _response;
        }

        //place order using cart
        public OrderErrorResponseHandler PlaceOrdersByCart(List<int> cartIds, string userEmail)
        {

            var date = DateTime.Now;
            var order = new NewOrder 
            { 
                 date = date,
                 userEmail = userEmail,
                 state = State.Pending
            };

            _context.NewOrders.Add(order);
            _context.SaveChangesAsync();

            Thread.Sleep(1000);

            var oderId = _context.NewOrders.Where(o => o.date == date && o.userEmail == userEmail && o.state == State.Pending).Select(o => o.Id).FirstOrDefault();


            List<Cart> productsList = _context.Cart.Where(c => cartIds.Contains(c.Id)).ToList();    


            if (productsList.Count > 0)
            {
                foreach (var product in productsList)
                {

                    var stock = _context.Products.Where(p => p.productId == product.ProductId).Select(p => p.stock).FirstOrDefault();

                    if(product.quantity > stock)
                    {
                        _response = SetResponse(true, "Quantity exeed stock", null, null);
                        return _response;
                    }

                    Thread.Sleep(500);

                }

            }


            if (productsList.Count > 0)
            {
                foreach (var productItem in productsList)
                {

                    var orderproduct = new OrderProduct
                    {
                        ProductId= productItem.ProductId,
                        OrderId= oderId,
                    };

                    _context.OrderProducts.Add(orderproduct);
                    _context.SaveChangesAsync();
                    Thread.Sleep(3000);

                    var stock = _context.Products.Where(p => p.productId == productItem.ProductId).Select(p => p.stock).FirstOrDefault();

                    stock = stock - productItem.quantity;

                    //update stock

                    var product = _context.Products.Find(productItem.ProductId);

                    product.stock = stock;

                    _context.Products.Update(product);
                    _context.SaveChangesAsync();

                    Thread.Sleep(3000);

                    var cart = _context.Cart.Find(productItem.Id); ;
                    _context.Cart.Remove(cart);
                    _context.SaveChangesAsync();
                    Thread.Sleep(2000);
                }

                _response = SetResponse(true, "Order placed successful", null, null);

            }
            else
            {
                _response = SetResponse(false, "Cart is empty", null, null);
            }

           
            return _response;

        }


        //Add to cart

        public OrderErrorResponseHandler AddToCart(int productId, string userEmail, int quantity)
        {
            var stock = _context.Products.Where(p => p.productId == productId).Select(p => p.stock).FirstOrDefault();

            if(stock < quantity)
            {
                _response = SetResponse(false, "Quantity exeed stock", null, null);
                return _response;
            }

            var item = new Cart
            {
                ProductId= productId,
                userEmail= userEmail,
                quantity= quantity
            };

            _context.Cart.Add(item);
            _context.SaveChangesAsync();
            Thread.Sleep(1000);
            _response = SetResponse(true, "Item added to cart successfully", null, null);
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
