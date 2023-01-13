using Assignment.Interface;
using Assignment.Request;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _IProductCategoryService;

        public ProductCategoryController(IProductCategoryService IProductCategoryService)
        {
            _IProductCategoryService = IProductCategoryService;
        }

        //Get Productcategory

        [HttpGet("GetProductcategory/{categoryId}")]
        public IActionResult GetProductcategory(int categoryId) 
        {
            var response = _IProductCategoryService.SelectProductcategory(categoryId);

            return Ok(response);
        }

        //Get Productcategories

        [HttpGet("GetAllProductcategories")]
        public IActionResult GetAllProductcategories()
        {
            var response = _IProductCategoryService.GetAllProductcategories();

            return Ok(response);
        }

        //Add ProductCategory

        [HttpPost("AddProductCategory")]
        public IActionResult AddProductCategory(ProductCategoryRequest request)
        {
            var response = _IProductCategoryService.SaveCategory(request);

            return response.State == false ? BadRequest(response) : Ok(response);
        }

        //Update ProductCategory

        [HttpPut("UpdateProductCategory/{categoryId}")]
        public IActionResult UpdatProductCategory(int categoryId, UpdateProductCategoryRequest request)
        {
            var response = _IProductCategoryService.UpdateCategory(categoryId, request);

            return response.State == false ? BadRequest(response) : Ok(response);
        }

        //Delete Productcategory

        [HttpDelete("DeleteProductcategory/{categoryId}")]
        public IActionResult DeleteProductcategory(int categoryId)
        {
            var response = _IProductCategoryService.DeleteCategory(categoryId);

            return response.State == false ? BadRequest(response) : Ok(response);
        }
    }
}
