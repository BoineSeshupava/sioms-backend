using AutoMapper;
using SIOMS.Application.Interfaces;
using SIOMS.Domain.Entities;
using SIOMS.Domain.Interfaces;

namespace SIOMS.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddToCartAsync(Guid customerId, Guid productId, int quantity)
        {
            // Check if item already exists
            var existingItems = await _unitOfWork.CartItems.GetCartItemsByCustomerIdAsync(customerId);
            var existingItem = existingItems.Find(c => c.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                await _unitOfWork.CartItems.UpdateAsync(existingItem);
            }
            else
            {
                var cartItem = new CartItem
                {
                    CartItemId = Guid.NewGuid(),
                    CustomerId = customerId,
                    ProductId = productId,
                    Quantity = quantity
                };
                await _unitOfWork.CartItems.AddAsync(cartItem);
            }

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateCartAsync(CartItem cartItem)
        {
            // Check if item already exists
            var existingItems = await _unitOfWork.CartItems.GetCartItemsByCustomerIdAsync(cartItem.CustomerId);
            var existingItem = existingItems.Find(c => c.ProductId == cartItem.ProductId);

            if (existingItem != null)
            {
                await _unitOfWork.CartItems.UpdateAsync(cartItem);
            }
            await _unitOfWork.CommitAsync();
        }
        public async Task<List<CartItem>> GetCartItemsAsync(Guid customerId)
        {
            return await _unitOfWork.CartItems.GetCartItemsByCustomerIdAsync(customerId);
        }

        public async Task RemoveFromCartAsync(Guid cartItemId)
        {
            await _unitOfWork.CartItems.DeleteAsync(cartItemId);
            await _unitOfWork.CommitAsync();
        }

        public async Task ClearCartAsync(Guid customerId)
        {
            await _unitOfWork.CartItems.ClearCartAsync(customerId);
        }

        public async Task RemoveFromCartByProductIdAsync(Guid customerId, Guid productId)
        {
            var cartItems = await _unitOfWork.CartItems.GetCartItemsByCustomerIdAsync(customerId);
            var item = cartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (item != null)
            {
                await _unitOfWork.CartItems.DeleteAsync(item.CartItemId);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
