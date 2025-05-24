using SIOMS.Domain.Entities;

namespace SIOMS.Application.Interfaces
{
    public interface ICartService
    {
        Task AddToCartAsync(Guid customerId, Guid productId, int quantity);
        Task<List<CartItem>> GetCartItemsAsync(Guid customerId);
        Task RemoveFromCartAsync(Guid cartItemId);
        Task RemoveFromCartByProductIdAsync(Guid customerId, Guid productId);
        Task UpdateCartAsync(CartItem cartItem);

        Task ClearCartAsync(Guid customerId);
    }
}
