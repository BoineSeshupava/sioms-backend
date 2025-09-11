using SIOMS.Domain.Entities;
using SIOMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Infrastructure.Persistence.Repositories
{
    public class VendorRepository : GenericRepository<Vendor>, IVendorRepository
    {
        public VendorRepository(SIOMSDbContext context) : base(context)
        {
        }

        public Task DeleteAsync(int id)
        {
            var vendor = _dbSet.FirstOrDefault(w => w.Id == id);
            if (vendor != null)
            {
                _dbSet.Remove(vendor);
                return _context.SaveChangesAsync();
            }
            return Task.CompletedTask;
        }

        public Task<Vendor?> GetByIdAsync(int id)
        {
            var vendor = _dbSet.FirstOrDefault(w => w.Id == id);
            return Task.FromResult(vendor);
        }
    }
}
