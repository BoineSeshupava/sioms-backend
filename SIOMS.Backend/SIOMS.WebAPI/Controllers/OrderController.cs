using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIOMS.Application.DTOs;
using SIOMS.Application.Interfaces;
using System.Security.Claims;

namespace SIOMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        private Guid GetCustomerId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(userId, out var id) ? id : Guid.Empty;
        }
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDto orderDto)
        {
            orderDto.OrderId = Guid.Empty;
            orderDto.CustomerId = GetCustomerId(); // Assign from claims

            if (orderDto.CustomerId == Guid.Empty)
                return Unauthorized();

            var createdOrder = await _orderService.AddOrderAsync(orderDto);
            return CreatedAtAction(nameof(GetById), new { id = createdOrder.OrderId }, createdOrder);
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateOrderStatus(Guid id, [FromBody] string status)
        {
            var updated = await _orderService.UpdateOrderAsync(id, status);

            if (!updated)
                return NotFound();

            return NoContent();
        }
        [HttpGet("myOrders")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetMyOrders()
        {
            var customerId = GetCustomerId();
            if (customerId == Guid.Empty)
                return Unauthorized();

            var orders = await _orderService.GetAllOrdersAsync();
            var myOrders = orders.Where(o => o.CustomerId == customerId);
            return Ok(myOrders);
        }
    }
}
