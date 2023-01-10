using Assignment.Interface;
using Assignment.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Assignment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _context;
        public ProductController(IProductService context) 
        {
            _context = context;
        }

        //Get All Products

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var response = _context.GetAllProduct();

            return response.Count == 0 ? BadRequest("No any Product") : Ok(response);
        }

        //Add Product

        [HttpPost("AddProduct")]
        public IActionResult AddProductCategory(ProductRequest request)
        {
            var response = _context.SaveProduct(request);

            return response.State == false ? BadRequest(response) : Ok(response);
        }

        //Get Product

        [HttpGet("GetProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            var response = _context.SelectProduct(id);

            return Ok(response);
        }

        //Update Product

        [HttpPut("UpdateProduct/{id}")]
        public IActionResult UpdatProduct(int id, UpdateProductRequest request)
        {
            var response = _context.UpdateProduct(id, request);

            return response.State == false ? BadRequest(response) : Ok(response);
        }

        //Delete Product

        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var response = _context.DeleteProduct(id);

            return response.State == false ? BadRequest(response) : Ok(response);
        }

        //Search Product by product name or category name

        [HttpPost("SearchProduct")]
        public IActionResult SearchProduct(SearchProductRequest request)
        {
             var response = _context.SearchProduct(request);

            return response.Count == 0 ? BadRequest("Product is not existed") : Ok(response);
        }
    }
}
