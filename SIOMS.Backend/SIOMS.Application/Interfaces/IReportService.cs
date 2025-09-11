using SIOMS.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IReportService
{
    Task<List<SalesReportDto>> GetSalesReportAsync();
    Task<List<InventoryReportDto>> GetInventoryReportAsync();
}
