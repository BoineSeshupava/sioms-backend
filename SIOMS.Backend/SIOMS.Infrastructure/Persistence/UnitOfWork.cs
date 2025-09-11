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

        public IWarehouseRepository warehouse { get; }
        public IVendorRepository Vendors { get; }
        public IInventoryRepository InventoryRepository { get; }

        public UnitOfWork(SIOMSDbContext context,
            IProductRepository products,
            ICategoryRepository categories,
            IOrderRepository orders,
            ICustomerRepository customers,
            ICartItemRepository cartItems,
            IWarehouseRepository warehouse,
            IVendorRepository vendors,
            IInventoryRepository inventoryRepository
            )
        {
            _context = context;
            Products = products;
            Categories = categories;
            Orders = orders;
            Customers = customers;
            CartItems = cartItems;
            this.warehouse = warehouse;
            Vendors = vendors;
            InventoryRepository = inventoryRepository;
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
