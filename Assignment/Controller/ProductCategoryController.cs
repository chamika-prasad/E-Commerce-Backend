using Assignment.Interface;
using Assignment.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _context;

        public ProductCategoryController(IProductCategoryService context)
        {
            _context = context;
        }

        //Get Productcategory

        [HttpGet("GetProductcategory/{id}")]
        public IActionResult GetProductcategory(int id) 
        {
            var response = _context.SelectProductcategory(id);

            return Ok(response);
        }

        //Get Productcategories

        [HttpGet("GetAllProductcategories")]
        public IActionResult GetAllProductcategories()
        {
            var response = _context.GetAllProductcategories();

            return Ok(response);
        }

        //Add ProductCategory

        [HttpPost("AddProductCategory")]
        public IActionResult AddProductCategory(ProductCategoryRequest request)
        {
            var response = _context.SaveCategory(request);

            return response.State == false ? BadRequest(response) : Ok(response);
        }

        //Update ProductCategory

        [HttpPut("UpdateProductCategory/{id}")]
        public IActionResult UpdatProductCategory(int id, UpdateProductCategoryRequest request)
        {
            var response = _context.UpdateCategory(id,request);

            return response.State == false ? BadRequest(response) : Ok(response);
        }

        //Delete Productcategory

        [HttpDelete("DeleteProductcategory/{id}")]
        public IActionResult DeleteProductcategory(int id)
        {
            var response = _context.DeleteCategory(id);

            return response.State == false ? BadRequest(response) : Ok(response);
        }
    }
}
