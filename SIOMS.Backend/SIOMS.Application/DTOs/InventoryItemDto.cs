using System;

namespace SIOMS.Application.DTOs
{
    public class InventoryItemDto
    {
        public Guid InventoryItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }

        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; }

        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; }

        public int WarehouseId { get; set; }
        public WarehouseDto Warehouse { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
