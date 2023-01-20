using Assignment.Interface;
using Assignment.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Assignment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _IProductCategoryService;

        public ProductCategoryController(IProductCategoryService IProductCategoryService)
        {
            _IProductCategoryService = IProductCategoryService;
        }

        //Get Productcategory


        [HttpGet("GetProductcategory/{categoryId}")]
       // [Authorize(Roles = "Admin || Customer")]
        public IActionResult GetProductcategory(int categoryId) 
        {
            var response = _IProductCategoryService.SelectProductcategory(categoryId);

            return Ok(response);
        }

        //Get Productcategories

        [HttpGet("GetAllProductcategories")]
       // [Authorize(Roles = "Admin || Customer")]
        public IActionResult GetAllProductcategories()
        {
            var response = _IProductCategoryService.GetAllProductcategories();

            return Ok(response);
        }

        //Add ProductCategory

        [HttpPost("AddProductCategory")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddProductCategory(ProductCategoryRequest request)
        {
            var response = _IProductCategoryService.SaveCategory(request);

            return response.State == false ? BadRequest(response) : Ok(response);
        }

        //Update ProductCategory

        [HttpPut("UpdateProductCategory/{categoryId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdatProductCategory(int categoryId, UpdateProductCategoryRequest request)
        {
            var response = _IProductCategoryService.UpdateCategory(categoryId, request);

            return response.State == false ? BadRequest(response) : Ok(response);
        }

        //Delete Productcategory

        [HttpDelete("DeleteProductcategory/{categoryId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProductcategory(int categoryId)
        {
            var response = _IProductCategoryService.DeleteCategory(categoryId);

            return response.State == false ? BadRequest(response) : Ok(response);
        }
    }
}
