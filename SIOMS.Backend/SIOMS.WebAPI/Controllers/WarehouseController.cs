using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIOMS.Application.DTOs;
using SIOMS.Application.Interfaces;

namespace SIOMS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/warehouses")]
    [Authorize(Roles = "Admin")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWarehouses()
        {
            var warehouses = await _warehouseService.GetAllAsync();
            return Ok(warehouses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWarehouse(int id)
        {
            var warehouse = await _warehouseService.GetByIdAsync(id);
            if (warehouse == null)
                return NotFound();
            return Ok(warehouse);
        }

        [HttpPost]
        public async Task<IActionResult> AddWarehouse([FromBody] WarehouseDto warehouseDto)
        {
            var created = await _warehouseService.AddAsync(warehouseDto);
            return CreatedAtAction(nameof(GetWarehouse), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWarehouse(int id, [FromBody] WarehouseDto warehouseDto)
        {
            if (id != warehouseDto.Id)
                return BadRequest("Warehouse ID mismatch.");
            await _warehouseService.UpdateAsync(warehouseDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse(int id)
        {
            await _warehouseService.DeleteAsync(id);
            return NoContent();
        }
    }
}
