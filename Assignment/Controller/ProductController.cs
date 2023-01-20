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
        private readonly IProductService _IProductService;
        public ProductController(IProductService IProductService) 
        {
            _IProductService = IProductService;
        }

        //Get All Products

        [HttpGet("GetAllProducts")]
       // [Authorize(Roles = "Admin || Customer")]
        public IActionResult GetAllProducts()
        {
            var response = _IProductService.GetAllProduct();

            return response.Count == 0 ? BadRequest("No any Product") : Ok(response);
        }

        //Add Product

        [HttpPost("AddProduct")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddProduct(ProductRequest request)
        {
            var response = _IProductService.SaveProduct(request);

            return response.State == false ? BadRequest(response) : Ok(response);
        }

        //Get Product

        [HttpGet("GetProduct/{productId}")]
       // [Authorize(Roles = "Admin || Customer")]
        public IActionResult GetProduct(int productId)
        {
            var response = _IProductService.SelectProduct(productId);

            return Ok(response);
        }

        //Update Product

        [HttpPut("UpdateProduct/{productId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdatProduct(int productId, UpdateProductRequest request)
        {
            var response = _IProductService.UpdateProduct(productId, request);

            return response.State == false ? BadRequest(response) : Ok(response);
        }

        //Delete Product

        [HttpDelete("DeleteProduct/{productId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProduct(int productId)
        {
            var response = _IProductService.DeleteProduct(productId);

            return response.State == false ? BadRequest(response) : Ok(response);
        }

        //Search Product by product name or category name

        [HttpPost("SearchProduct")]
       // [Authorize(Roles = "Admin || Customer")]
        public IActionResult SearchProducts(SearchProductRequest request)
        {
            var _object = new 
            {
                state = false,
                message = "Product is not existed",
            };

            var response = _IProductService.SearchProduct(request);

            return response.Count == 0 ? BadRequest(_object) : Ok(response);
        }
    }
}
