using BusinessLogicLayer.BusinessEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SalesAndInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        #region variables
        private BusinessLogicLayer.Services.InventoryService _BLL;
        #endregion

        #region Constructor
        public InventoryController()
        {
            _BLL = new BusinessLogicLayer.Services.InventoryService();
        }
        #endregion

        #region GetAll
        [Route("All")]
        [HttpGet]
        public async Task<ActionResult<List<InventoryModel>>> GetAll()
        {
            var data = await _BLL.GetAll();

            if (data == null)
            {
                return NotFound("No data found");
            }
            return Ok(data);
        }
        #endregion

        #region GetByID
        [Route("GetProductById/{id}")]
        [HttpGet]
        public async Task<ActionResult<InventoryModel>> GetProductById(int id)
        {
            var data = await _BLL.GetProductById(id);

            if (data == null)
            {
                return NotFound($"Product with Id: {id} was not found");
            }

            return Ok(data);

        }
        #endregion

        #region Add
        [Route("PostProduct")]
        [HttpPost]
        public async Task<IActionResult> PostPerson([FromBody] InventoryPostModel inventoryPostModel)
        {
            bool success = await _BLL.PostProduct(inventoryPostModel);
            if (success) return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + inventoryPostModel.ProductId, inventoryPostModel);
            return BadRequest();

        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            InventoryModel? product = await _BLL.GetProductById(id);
            if (product != null)
            {
                await _BLL.DeleteProduct(product);
                return Ok("Object Deleted");
            }

            return NotFound($"Product with Id: {id} was not found");
        }
        #endregion

        #region Update - public async Task<IActionResult> UpdateProduct(int id, InventoryModel uProduct)
        [Route("UpdateProduct/{id}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateProduct(int id, InventoryPostModel uProduct)
        {
            var existingProduct = await _BLL.GetProductById(id);

            if (existingProduct != null)
            {
                uProduct.ProductId = existingProduct.ProductId;
                var data = await _BLL.UpdateProduct(uProduct);

                //var data = _BLL.GetProductById(uProduct.Id);
                if (data == null)
                {
                    return NotFound($"Product not updated");
                }
                return Ok(data);
            }
            return NotFound($"Product with Id: {id} was not found");
        }
        #endregion
    }
}
