using SIOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Domain.Interfaces
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task<List<CartItem>> GetCartItemsByCustomerIdAsync(Guid customerId);
        Task ClearCartAsync(Guid customerId);
    }
}
