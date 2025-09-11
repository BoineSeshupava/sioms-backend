using System.Collections.Generic;
using System.Threading.Tasks;

public interface IReportRepository
{
    Task<List<Object>> GetSalesReportAsync();
    Task<List<Object>> GetInventoryReportAsync();
}
