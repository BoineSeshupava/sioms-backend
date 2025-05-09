using SIOMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SIOMSDbContext _context;

        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }
        public IOrderRepository Orders { get; }
        public ICustomerRepository Customers { get; }
        public ICartItemRepository CartItems { get; }

        public UnitOfWork(SIOMSDbContext context,
            IProductRepository products,
            ICategoryRepository categories,
            IOrderRepository orders,
            ICustomerRepository customers,
            ICartItemRepository cartItems
            )
        {
            _context = context;
            Products = products;
            Categories = categories;
            Orders = orders;
            Customers = customers;
            CartItems = cartItems;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        
    }
}
