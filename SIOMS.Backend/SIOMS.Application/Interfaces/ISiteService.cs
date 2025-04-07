using SIOMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Application.Interfaces
{
    public interface ISiteService
    {
        Task<IEnumerable<SiteDto>> GetAllAsync();
        Task<SiteDto> GetByIdAsync(int id);
        Task AddAsync(SiteDto itemDto);
        Task UpdateAsync(SiteDto itemDto);
        Task DeleteAsync(int id);
    }
}
