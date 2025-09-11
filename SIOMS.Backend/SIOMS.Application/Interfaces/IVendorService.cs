using SIOMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Application.Interfaces
{
    public interface IVendorService
    {
        Task<IEnumerable<VendorDto>> GetAllAsync();
        Task<VendorDto?> GetByIdAsync(int id);
        Task<VendorDto> AddAsync(VendorDto warehouseDto);
        Task UpdateAsync(VendorDto warehouseDto);
        Task DeleteAsync(int id);
    }
}
