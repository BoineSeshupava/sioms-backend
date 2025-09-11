using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIOMS.Domain.Interfaces
{
    public interface IStockAlertRepository
    {
        Task<IEnumerable<object>> GetStockAlertsAsync();
    }
}
