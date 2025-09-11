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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InventoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventoryItemDto>> GetAllAsync()
        {
            var items = await _unitOfWork.InventoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<InventoryItemDto>>(items);
        }

        public async Task<InventoryItemDto> GetByIdAsync(Guid id)
        {
            var item = await _unitOfWork.InventoryRepository.GetByIdAsync(id);
            return _mapper.Map<InventoryItemDto>(item);
        }

        public async Task AddAsync(InventoryItemDto itemDto)
        {
            var entity = _mapper.Map<InventoryItem>(itemDto);
            await _unitOfWork.InventoryRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(InventoryItemDto itemDto)
        {
            var entity = _mapper.Map<InventoryItem>(itemDto);
            await _unitOfWork.InventoryRepository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.InventoryRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }
    }
}
