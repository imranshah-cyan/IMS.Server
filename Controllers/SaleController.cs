using IMSSPM.Services.SaleService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMSSPM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sale>>> GetSales()
        {
            var result = await _saleService.GetSales();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            var result = await _saleService.GetSale(id);
            if (result == null)
                return NotFound("Record doesn't exist.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Sale>> AddSale(Sale sale)
        {
            var result = await _saleService.AddSale(sale);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Sale>> UpdateSale(Sale sale)
        {
            var result = await _saleService.UpdateSale(sale);
            if (result == null)
                return NotFound("Unable to delete.");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Sale>> DeleteSale(int id)
        {
            var result = await _saleService.DeleteSale(id);
            if (result == null)
                return NotFound("Unable to delete.");
            return Ok(result);
        }
    }
}
