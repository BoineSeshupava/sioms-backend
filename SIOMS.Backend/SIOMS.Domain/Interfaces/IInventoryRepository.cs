using SIOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Domain.Interfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<InventoryItem>> GetAllAsync();
        Task<InventoryItem> GetByIdAsync(int id);
        Task AddAsync(InventoryItem item);
        Task UpdateAsync(InventoryItem item);
        Task DeleteAsync(int id);
    }
}
