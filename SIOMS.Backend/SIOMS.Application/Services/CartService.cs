using AutoMapper;
using SIOMS.Application.Interfaces;
using SIOMS.Domain.Entities;
using SIOMS.Domain.Interfaces;

namespace SIOMS.Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartService(
            ICartItemRepository cartItemRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddToCartAsync(Guid customerId, Guid productId, int quantity)
        {
            // Check if item already exists
            var existingItems = await _cartItemRepository.GetCartItemsByCustomerIdAsync(customerId);
            var existingItem = existingItems.Find(c => c.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                await _cartItemRepository.UpdateAsync(existingItem);
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
                await _cartItemRepository.AddAsync(cartItem);
            }

            await _unitOfWork.CommitAsync();
        }

        public async Task<List<CartItem>> GetCartItemsAsync(Guid customerId)
        {
            return await _cartItemRepository.GetCartItemsByCustomerIdAsync(customerId);
        }

        public async Task RemoveFromCartAsync(Guid cartItemId)
        {
            await _cartItemRepository.DeleteAsync(cartItemId);
            await _unitOfWork.CommitAsync();
        }

        public async Task ClearCartAsync(Guid customerId)
        {
            await _cartItemRepository.ClearCartAsync(customerId);
        }

    }
}
