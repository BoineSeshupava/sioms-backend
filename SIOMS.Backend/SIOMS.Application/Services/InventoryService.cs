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
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _repository;
        private readonly IMapper _mapper;

        public InventoryService(IInventoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventoryItemDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<InventoryItemDto>>(items);
        }

        public async Task<InventoryItemDto> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return _mapper.Map<InventoryItemDto>(item);
        }

        public async Task AddAsync(InventoryItemDto itemDto)
        {
            var entity = _mapper.Map<InventoryItem>(itemDto);
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(InventoryItemDto itemDto)
        {
            var entity = _mapper.Map<InventoryItem>(itemDto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
