using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIOMS.Application.Interfaces;
using System.Threading.Tasks;

namespace SIOMS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/stock-alerts")]
    [Authorize(Roles = "Admin")]
    public class StockAlertController : ControllerBase
    {
        private readonly IStockAlertService _service;

        public StockAlertController(IStockAlertService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetStockAlerts()
        {
            var alerts = await _service.GetStockAlertsAsync();
            return Ok(alerts);
        }
    }
}
