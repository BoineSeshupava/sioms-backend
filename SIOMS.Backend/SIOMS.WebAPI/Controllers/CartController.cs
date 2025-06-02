using AutoMapper;
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
        private readonly IMapper _mapper;

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
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCart([FromBody] CartItemDto item)
        {
            var customerId = GetCustomerId();
            if (customerId == Guid.Empty)
                return Unauthorized();
            CartItem cartItem = _mapper.Map<CartItem>(item);
            await _cartService.UpdateCartAsync(cartItem);
            return Ok(item);
        }
        [HttpPut("{cartItemId}")]
        [Authorize]
        public async Task<IActionResult> UpdateCartItem(Guid cartItemId, [FromBody] int quantity)
        {
            var customerId = GetCustomerId();
            var cartItems = await _cartService.GetCartItemsAsync(customerId);
            var item = cartItems.FirstOrDefault(c => c.CartItemId == cartItemId);

            if (item == null)
                return NotFound("Cart item not found.");

            item.Quantity = quantity;
            await _cartService.UpdateCartAsync(item);
            return NoContent();
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
        [HttpDelete("by-product/{productId}")]
        public async Task<IActionResult> RemoveFromCartByProductId(Guid productId)
        {
            var customerId = GetCustomerId(); // assuming such a method exists

            if (customerId == Guid.Empty)
                return Unauthorized();

            await _cartService.RemoveFromCartByProductIdAsync(customerId, productId);
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
