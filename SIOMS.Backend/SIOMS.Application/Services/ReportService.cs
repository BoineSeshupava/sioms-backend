using SIOMS.Application.DTOs;

namespace SIOMS.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<List<SalesReportDto>> GetSalesReportAsync()
        {
            var salesReport = await _reportRepository.GetSalesReportAsync();
            return salesReport.Cast<SalesReportDto>().ToList();
        }

        public async Task<List<InventoryReportDto>> GetInventoryReportAsync()
        {
            var inventoryReport = await _reportRepository.GetInventoryReportAsync();
            return inventoryReport.Cast<InventoryReportDto>().ToList();
        }
    }
}
