using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        ICartItemRepository CartItems { get; }
        IWarehouseRepository warehouse { get; }
        IVendorRepository Vendors { get; }
        IInventoryRepository InventoryRepository { get; }
        Task CommitAsync();
    }
}
