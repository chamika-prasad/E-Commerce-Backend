using Assignment.Interface;
using Assignment.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OderController : ControllerBase
    {
        private readonly IOrderService _context;

        public OderController(IOrderService context)
        {
            _context = context;
        }

        //place order by customer

        [HttpPost("PlaceOrder/{id}")]
        public IActionResult PlaceOrder(int id,OrderRequest request) 
        {
            var response = _context.PlaceOrder(id,request);
            return Ok(response);
        }



    }
}
