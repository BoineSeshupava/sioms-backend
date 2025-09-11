using SIOMS.Domain.Entities;
using SIOMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Infrastructure.Persistence.Repositories
{
    public class InventoryRepository : GenericRepository<InventoryItem>, IInventoryRepository
    {
        public InventoryRepository(SIOMSDbContext context) : base(context)
        {
        }
    }
}
