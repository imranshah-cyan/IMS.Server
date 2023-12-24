using IMSSPM.Services.PurchaseService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMSSPM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Purchase>>> GetPurchases()
        {
            var result = await _purchaseService.GetPurchases();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetPurchase(int id)
        {
            var result = await _purchaseService.GetPurchase(id);
            if (result == null)
                return NotFound("Record doesn't exist.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Purchase>> AddPurchase(Purchase purchase)
        {
            var result = await _purchaseService.AddPurchase(purchase);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Purchase>> UpdatePurchase(Purchase purchase)
        {
            var result = await _purchaseService.UpdatePurchase(purchase);
            if (result == null)
                return NotFound("Unable to delete.");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Purchase>> DeletePurchase(int id)
        {
            var result = await _purchaseService.DeletePurchase(id);
            if (result == null)
                return NotFound("Unable to delete.");
            return Ok(result);
        }
    }
}