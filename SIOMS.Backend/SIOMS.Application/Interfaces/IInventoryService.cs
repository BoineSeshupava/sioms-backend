using SIOMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Application.Interfaces
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryItemDto>> GetAllAsync();
        Task<InventoryItemDto> GetByIdAsync(Guid id);
        Task AddAsync(InventoryItemDto itemDto);
        Task UpdateAsync(InventoryItemDto itemDto);
        Task DeleteAsync(Guid id);
    }
}
