using Assignment.Interface;
using Assignment.Request;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OderController : ControllerBase
    {
        private readonly IOrderService _IOrderService;

        public OderController(IOrderService IOrderService)
        {
            _IOrderService = IOrderService;
        }

        //place order by customer

        [HttpPost("PlaceOrder/{productId}")]
        public IActionResult PlaceOrders(int productId, OrderRequest request)
        {

            var Response = _IOrderService.PlaceOrder(productId, request);

            return Response.State == false ? BadRequest(Response) : Ok(Response);

        }

        //Update order state by admin

        [HttpPut("UpdateOrderState/{orderId}/{orderState}")]
        public IActionResult UpdateOrdersState(int orderId, string orderState)
        {

            var Response = _IOrderService.UpdateOrderState(orderId, orderState);

            return Response.State == false ? BadRequest(Response) : Ok(Response);

        }

        //Get all orders

        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders()
        {

            var Response = _IOrderService.GetAllOrders();

            return Ok(Response);

        }


    }
}
