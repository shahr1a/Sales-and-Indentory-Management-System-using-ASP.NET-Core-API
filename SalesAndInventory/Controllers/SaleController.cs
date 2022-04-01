using BusinessLogicLayer.BusinessEntities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesAndInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private BusinessLogicLayer.Services.SaleService _BLL;

        public SaleController()
        {
            _BLL = new BusinessLogicLayer.Services.SaleService();
        }

        [Route("All")]
        [HttpGet]
        public async Task<ActionResult<List<SaleModel>>> GetAll()
        {
            var data = await _BLL.GetAll();

            if (data == null)
            {
                return NotFound("No data found");
            }
            return Ok(data);
        }

        [Route("GetSaleById/{id}")]
        [HttpGet]
        public async Task<ActionResult<SaleModel>> GetSaleById(int id)
        {
            var data = await _BLL.GetSaleById(id);

            if (data == null)
            {
                return NotFound($"Sale with Id: {id} was not found");
            }

            return Ok(data);

        }

        [Route("PostSale")]
        [HttpPost]
        public async Task<IActionResult> PostSale([FromBody] SaleModel saleModel)
        {
            bool success = await _BLL.PostSale(saleModel);
            if (success) return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + saleModel.SaleId, saleModel);
            return BadRequest();

        }

        [Route("UpdateSale/{id}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateSale(int id, SaleModel saleModel)
        {
            var sale = await _BLL.GetSaleById(id);

            if (sale != null)
            {
                saleModel.SaleId = sale.SaleId;
                var data = await _BLL.UpdateSale(saleModel);

                if (data == null)
                {
                    return NotFound($"Sale not updated");
                }
                return Ok(data);
            }
            return NotFound($"Sale with Id: {id} was not found");
        }

        [HttpDelete]
        [Route("DeleteSale/{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            SaleModel? sale = await _BLL.GetSaleById(id);
            if (sale != null)
            {
                await _BLL.DeleteSale(sale);
                return Ok("Object Deleted");
            }

            return NotFound($"Sale with Id: {id} was not found");
        }
    }
}
