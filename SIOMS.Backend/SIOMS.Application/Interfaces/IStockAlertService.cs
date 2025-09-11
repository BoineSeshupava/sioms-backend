using SIOMS.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIOMS.Application.Interfaces
{
    public interface IStockAlertService
    {
        Task<IEnumerable<StockAlertDto>> GetStockAlertsAsync();
    }
}
