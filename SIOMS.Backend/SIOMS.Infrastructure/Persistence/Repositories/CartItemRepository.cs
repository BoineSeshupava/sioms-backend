using Microsoft.EntityFrameworkCore;
using SIOMS.Domain.Entities;
using SIOMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Infrastructure.Persistence.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        private readonly SIOMSDbContext _context;

        public CartItemRepository(SIOMSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<CartItem>> GetCartItemsByCustomerIdAsync(Guid customerId)
        {
            return await _context.CartItems
                .Where(c => c.CustomerId == customerId)
                .Include(c => c.Product)
                .ToListAsync();
        }

        public async Task ClearCartAsync(Guid customerId)
        {
            var items = _context.CartItems.Where(c => c.CustomerId == customerId);
            _context.CartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
