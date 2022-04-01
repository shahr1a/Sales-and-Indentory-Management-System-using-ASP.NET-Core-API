using BusinessLogicLayer.BusinessEntities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesAndInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private BusinessLogicLayer.Services.CategoryService _BLL;

        public CategoryController()
        {
            _BLL = new BusinessLogicLayer.Services.CategoryService();
        }

        [Route("All")]
        [HttpGet]
        public async Task<ActionResult<List<CategoryModel>>> GetAll()
        {
            var data = await _BLL.GetAll();

            if (data == null)
            {
                return NotFound("No data found");
            }
            return Ok(data);
        }

        [Route("GetProductById/{id}")]
        [HttpGet]
        public async Task<ActionResult<CategoryModel>> GetCategoryById(int id)
        {
            var data = await _BLL.GetCategoryById(id);

            if (data == null)
            {
                return NotFound($"Category with Id: {id} was not found");
            }

            return Ok(data);

        }

        [Route("PostCategory")]
        [HttpPost]
        public async Task<IActionResult> PostPerson([FromBody] CategoryModel categoryModel)
        {
            bool success = await _BLL.PostCategory(categoryModel);
            if (success) return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + categoryModel.CategoryId, categoryModel);
            return BadRequest();

        }

        [Route("UpdateCategory/{id}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateProduct(int id, CategoryModel categoryModel)
        {
            var category = await _BLL.GetCategoryById(id);

            if (category != null)
            {
                categoryModel.CategoryId = category.CategoryId;
                var data = await _BLL.UpdateCategory(categoryModel);

                //var data = _BLL.GetProductById(uProduct.Id);
                if (data == null)
                {
                    return NotFound($"Category not updated");
                }
                return Ok(data);
            }
            return NotFound($"Category with Id: {id} was not found");
        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            CategoryModel? category = await _BLL.GetCategoryById(id);
            if (category != null)
            {
                await _BLL.DeleteCategory(category);
                return Ok("Object Deleted");
            }

            return NotFound($"Category with Id: {id} was not found");
        }
    }
}
