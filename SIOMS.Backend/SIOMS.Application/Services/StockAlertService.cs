using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIOMS.Application.DTOs;
using SIOMS.Application.Interfaces;
using SIOMS.Domain.Interfaces;

namespace SIOMS.Application.Services
{
    public class StockAlertService : IStockAlertService
    {
        private readonly IStockAlertRepository _repository;

        public StockAlertService(IStockAlertRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StockAlertDto>> GetStockAlertsAsync()
        {
            return await _repository.GetStockAlertsAsync() as IEnumerable<StockAlertDto>;
        }
    }
}
