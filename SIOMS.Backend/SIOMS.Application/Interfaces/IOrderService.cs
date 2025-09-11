using SIOMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(Guid id);
        Task<OrderDto> AddOrderAsync(OrderDto orderDto);
        Task<bool> UpdateOrderAsync(Guid orderId, string status);
        Task DeleteOrderAsync(Guid id);
    }
}
