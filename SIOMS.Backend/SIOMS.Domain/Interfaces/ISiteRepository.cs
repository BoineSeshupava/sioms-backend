using SIOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Domain.Interfaces
{
    public interface ISiteRepository
    {
        Task<IEnumerable<Site>> GetAllAsync();
        Task<Site> GetByIdAsync(int id);
        Task AddAsync(Site item);
        Task UpdateAsync(Site item);
        Task DeleteAsync(int id);
    }
}
