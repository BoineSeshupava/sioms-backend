using Microsoft.EntityFrameworkCore;
using SIOMS.Domain.Entities;
using SIOMS.Domain.Interfaces;

namespace SIOMS.Infrastructure.Persistence.Repositories
{
    public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(SIOMSDbContext context) : base(context)
        {
        }

        public async Task DeleteAsync(int id)
        {
            var warehouse = await _dbSet.FirstOrDefaultAsync(w => w.Id == id);
            if (warehouse != null)
            {
                _dbSet.Remove(warehouse);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Warehouse?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(w => w.Id == id);
        }

    }
}
