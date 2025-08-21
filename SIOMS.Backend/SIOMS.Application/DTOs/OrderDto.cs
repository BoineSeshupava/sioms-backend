using System;
using System.Collections.Generic;

namespace SIOMS.Application.DTOs
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = "Pending";
        public List<OrderItemDto> OrderItems { get; set; } = new();
    }
}
