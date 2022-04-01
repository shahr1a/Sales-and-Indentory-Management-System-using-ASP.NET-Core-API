using BusinessLogicLayer.BusinessEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SalesAndInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerController : ControllerBase
    {
        #region variables
        private BusinessLogicLayer.Services.DealerService _BLL;
        #endregion

        #region public DealerController()
        public DealerController()
        {
            _BLL = new BusinessLogicLayer.Services.DealerService();
        }
        #endregion

        #region public async Task<ActionResult<List<DealerModel>>> GetAll()
        [Route("All")]
        [HttpGet]
        public async Task<ActionResult<List<DealerModel>>> GetAll()
        {
            var data = await _BLL.GetAll();

            if (data == null)
            {
                return NotFound("No data found");
            }
            return Ok(data);
        }
        #endregion

        #region public async Task<ActionResult<DealerModel>> GetDealerById(int id)
        [Route("GetDealerById/{id}")]
        [HttpGet]
        public async Task<ActionResult<DealerModel>> GetDealerById(int id)
        {
            var data = await _BLL.GetDealerById(id);

            if (data == null)
            {
                return NotFound($"Dealer with Id: {id} was not found");
            }

            return Ok(data);

        }
        #endregion

        #region public async Task<IActionResult> PostDealer([FromBody] DealerModel dealerModel)
        [Route("PostDealer")]
        [HttpPost]
        public async Task<IActionResult> PostDealer([FromBody] DealerModel dealerModel)
        {
            bool success = await _BLL.PostDealer(dealerModel);
            if (success) return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + dealerModel.DealerId, dealerModel);
            return BadRequest();

        }
        #endregion

        #region public async Task<IActionResult> DeleteDealer(int id)
        [HttpDelete]
        [Route("DeleteDealer/{id}")]
        public async Task<IActionResult> DeleteDealer(int id)
        {
            DealerModel? dealer = await _BLL.GetDealerById(id);
            if (dealer != null)
            {
                await _BLL.DeleteDealer(dealer);
                return Ok("Object Deleted");
            }

            return NotFound($"Dealer with Id: {id} was not found");
        }
        #endregion

        #region public async Task<IActionResult> UpdateDealer(int id, DealerModel uDealer)
        [Route("UpdateDealer/{id}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateDealer(int id, DealerModel uDealer)
        {
            var existingDealer = await _BLL.GetDealerById(id);

            if (existingDealer != null)
            {
                uDealer.DealerId = existingDealer.DealerId;
                var data = await _BLL.UpdateDealer(uDealer);

                //var data = _BLL.GetProductById(uProduct.Id);
                if (data == null)
                {
                    return NotFound($"Dealer not updated");
                }
                return Ok(data);
            }
            return NotFound($"Dealer with Id: {id} was not found");
        }
        #endregion

        #region public async Task<IActionResult> CreateDealerAccount([FromBody] DealerSelfCreateModel dealerSelfCreate)

        [Route("CreateDealerAccount")]
        [HttpPost]
        public async Task<IActionResult> CreateDealerAccount([FromBody] DealerSelfCreateModel dealerSelfCreate)
        {
            bool success = await _BLL.CreateDealerAccount(dealerSelfCreate);
            if (success) return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + dealerSelfCreate.DealerId, dealerSelfCreate);
            return BadRequest();
        }

        #endregion
    }
}
