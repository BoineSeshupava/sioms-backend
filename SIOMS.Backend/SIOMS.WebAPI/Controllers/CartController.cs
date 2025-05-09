using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIOMS.Application.DTOs;
using SIOMS.Application.Interfaces;
using SIOMS.Domain.Entities;
using System.Security.Claims;

namespace SIOMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Customer")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        private Guid GetCustomerId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.Parse(userId);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] CartItemDto item)
        {
            var customerId = GetCustomerId();
            await _cartService.AddToCartAsync(customerId, item.ProductId, item.Quantity);
            return Ok(new { message = "Item added to cart." });
        }

        [HttpGet]
        public async Task<ActionResult<List<CartItem>>> GetCartItems()
        {
            var customerId = GetCustomerId();
            var items = await _cartService.GetCartItemsAsync(customerId);
            return Ok(items);
        }

        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> RemoveFromCart(Guid cartItemId)
        {
            await _cartService.RemoveFromCartAsync(cartItemId);
            return Ok(new { message = "Item removed from cart." });
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCart()
        {
            var customerId = GetCustomerId();
            await _cartService.ClearCartAsync(customerId);
            return Ok(new { message = "Cart cleared." });
        }
    }
}
