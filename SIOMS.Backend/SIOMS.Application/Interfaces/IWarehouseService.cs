using SIOMS.Application.DTOs;

namespace SIOMS.Application.Interfaces
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseDto>> GetAllAsync();
        Task<WarehouseDto?> GetByIdAsync(int id);
        Task<WarehouseDto> AddAsync(WarehouseDto warehouseDto);
        Task UpdateAsync(WarehouseDto warehouseDto);
        Task DeleteAsync(int id);
    }
}
