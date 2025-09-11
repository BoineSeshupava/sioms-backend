using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIOMS.Application.DTOs;
using SIOMS.Application.Interfaces;

namespace SIOMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;
        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetVendors()
        {
            var vendors = await _vendorService.GetAllAsync();
            return Ok(vendors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendor(int id)
        {
            var vendor = await _vendorService.GetByIdAsync(id);
            if (vendor == null)
                return NotFound();
            return Ok(vendor);
        }
        [HttpPost]
        public async Task<IActionResult> AddVendor([FromBody] VendorDto vendorDto)
        {
            var created = await _vendorService.AddAsync(vendorDto);
            return CreatedAtAction(nameof(GetVendor), new { id = created.Id }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVendor(int id, [FromBody] VendorDto vendorDto)
        {
            if (id != vendorDto.Id)
                return BadRequest("Vendor ID mismatch.");
            await _vendorService.UpdateAsync(vendorDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            await _vendorService.DeleteAsync(id);
            return NoContent();
        }

    }
}
