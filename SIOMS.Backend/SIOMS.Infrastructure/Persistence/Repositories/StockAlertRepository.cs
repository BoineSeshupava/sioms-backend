using SIOMS.Application.DTOs;
using SIOMS.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SIOMS.Infrastructure.Persistence.Repositories
{
    public class StockAlertRepository : IStockAlertRepository
    {
        private readonly SIOMSDbContext _context;

        public StockAlertRepository(SIOMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetStockAlertsAsync()
        {
            return await _context.StockAlerts.ToListAsync();
        }
    }
}
