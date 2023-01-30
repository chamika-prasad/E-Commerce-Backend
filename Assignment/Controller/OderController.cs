using Assignment.Interface;
using Assignment.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Data;
using Assignment.Service;

namespace Assignment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class OderController : ControllerBase
    {
        private readonly IOrderService _IOrderService;

        public OderController(IOrderService IOrderService)
        {
            _IOrderService = IOrderService;
        }

        //place order by customer

        [HttpPost("PlaceOrdersDirectly/{productId}")]
       // [Authorize(Roles = "Admin" || "Customer")]
        public IActionResult PlaceOrdersDirectly(int productId, OrderRequest request)
        {

            var Response = _IOrderService.PlaceOrdersDirect(productId, request);

            return Response.State == false ? BadRequest(Response) : Ok(Response);

        }


        //place order using cart

        [HttpPost("PlaceOrderInCart/{userEmail}")]
        // [Authorize(Roles = "Admin || Customer")]
        // public IActionResult PlaceOrdersByCart([FromBody] List<int> cartIds, string userEmail)
        public IActionResult PlaceOrdersByCart(List<int> cartIds, string userEmail)
        {

            var Response = _IOrderService.PlaceOrdersByCart(cartIds, userEmail); 

            return Response.State == false ? BadRequest(Response) : Ok(Response);

        }


        //Get all products in cart

        [HttpGet("GetAllProductsInCart/{userEmail}")]
        // [Authorize(Roles = "Admin || Customer")]
        public IActionResult GetAllProductsInCart(string userEmail)
        {

            var Response = _IOrderService.GetAllProductsInCart(userEmail);

            return Response.Count == 0 ? BadRequest("No any Product in cart") : Ok(Response);

        }

        //add to cart

        [HttpPost("AddToCart/{productId}/{userEmail}/{quantity}")]
       // [Authorize(Roles = "Admin || Customer")]
        public IActionResult AddToCart(int productId, string userEmail,int quantity)
        {

            var Response = _IOrderService.AddToCart(productId, userEmail, quantity);

            return Response.State == false ? BadRequest(Response) : Ok(Response);

        }

        //Update order state by admin

        [HttpPut("UpdateOrderState/{orderId}/{orderState}")]
       // [Authorize(Roles = "Admin")]
        public IActionResult UpdateOrdersState(int orderId, string orderState)
        {

            var Response = _IOrderService.UpdateOrderState(orderId, orderState);

            return Response.State == false ? BadRequest(Response) : Ok(Response);

        }

        //Get all orders

        [HttpGet("GetAllOrders")]
  //      [Authorize(Roles = "Admin")]
        public IActionResult GetAllOrders()
        {

            var Response = _IOrderService.GetAllOrders();

            return Ok(Response);

        }


    }
}
