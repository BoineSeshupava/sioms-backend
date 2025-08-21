using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIOMS.Application.DTOs;
using SIOMS.Application.Interfaces;

namespace SIOMS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public AdminController(
            ICustomerService customerService,
            IProductService productService,
            IOrderService orderService)
        {
            _customerService = customerService;
            _productService = productService;
            _orderService = orderService;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboardStats()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            var products = await _productService.GetAllProductsAsync();
            var orders = await _orderService.GetAllOrdersAsync();

            var stats = new
            {
                TotalCustomers = customers.Count(),
                TotalProducts = products.Count(),
                TotalOrders = orders.Count(),
                TotalRevenue = orders.Sum(o => o.TotalAmount)
            };

            return Ok(stats);
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpPost("products")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            await _productService.AddProductAsync(productDto);
            return Ok(new { message = "Product added successfully." });
        }

        [HttpPut("products/{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductDto productDto)
        {
            if (id != productDto.ProductId)
                return BadRequest("Product ID mismatch.");

            await _productService.UpdateProductAsync(productDto);
            return NoContent();
        }

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }
    }
}