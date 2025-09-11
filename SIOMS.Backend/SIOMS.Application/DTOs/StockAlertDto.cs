using System;

namespace SIOMS.Application.DTOs
{
    public class StockAlertDto
    {
        public Guid InventoryItemId { get; set; }
        public string ItemName { get; set; }
        public string ProductName { get; set; }
        public string WarehouseName { get; set; }
        public int CurrentStock { get; set; }
        public int Threshold { get; set; }
    }
}
