using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppDIWithoutInterfaces.Models;
using WebAppDIWithoutInterfaces.Services;

namespace WebAppDIWithoutInterfaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SalesService _salesService;

        public SalesController(SalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpPost]
        public IActionResult AddSale([FromBody] Sale sale)
        {
            _salesService.AddSale(sale);
            return Ok("Sale added!");
        }

        [HttpGet]
        public IActionResult GetSales()
        {
            var sales= _salesService.GetSales();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public IActionResult GetSaleById(int id)
        {
            var sale=_salesService.GetSaleById(id);
            if (sale == null)
            {
                return NotFound("Sale not found");
            }
            return Ok(sale);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSale(int id, [FromBody] Sale updateSale)
        {
            var result = _salesService.UpdateSale(id, updateSale);
            if (!result)
            {
                return NotFound("Sale not found");
            }
            return Ok("Sale updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            var result= _salesService.DeleteSale(id);
            if (!result)
            {
                return NotFound("Sale not found");
            }
            return Ok("Sale deleted!");
        }
    }
}
