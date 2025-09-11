using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Application.DTOs
{
    public class InventoryReportDto
    {
        public Guid InventoryItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public string WarehouseName { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
    }
}
