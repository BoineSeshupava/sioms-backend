using AutoMapper;
using SIOMS.Application.DTOs;
using SIOMS.Application.Interfaces;
using SIOMS.Domain.Entities;
using SIOMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<int> AddOrderAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            return await _orderRepository.AddOrderAsync(order);
        }

        public async Task<bool> UpdateOrderAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            return await _orderRepository.UpdateOrderAsync(order);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            return await _orderRepository.DeleteOrderAsync(id);
        }
    }
}
