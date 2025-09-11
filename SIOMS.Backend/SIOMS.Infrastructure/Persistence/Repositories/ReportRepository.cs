using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIOMS.Application.DTOs;
using SIOMS.Domain.Interfaces;
using SIOMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace SIOMS.Infrastructure.Persistence.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly SIOMSDbContext _context;
        public ReportRepository(SIOMSDbContext context)
        {
            _context = context;
        }

        public async Task<List<object>> GetSalesReportAsync()
        {
            return await _context.SalesReport.Cast<object>().ToListAsync();
        }

        public async Task<List<object>> GetInventoryReportAsync()
        {
            return await _context.InventoryReport.Cast<object>().ToListAsync();
        }
    }
}
