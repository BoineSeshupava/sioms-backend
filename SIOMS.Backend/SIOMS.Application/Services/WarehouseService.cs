using AutoMapper;
using SIOMS.Application.DTOs;
using SIOMS.Application.Interfaces;
using SIOMS.Domain.Entities;
using SIOMS.Domain.Interfaces;

namespace SIOMS.Application.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WarehouseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WarehouseDto>> GetAllAsync()
        {
            var warehouses = await _unitOfWork.warehouse.GetAllAsync();
            return _mapper.Map<IEnumerable<WarehouseDto>>(warehouses);
        }

        public async Task<WarehouseDto?> GetByIdAsync(int id)
        {
            var warehouse = await _unitOfWork.warehouse.GetByIdAsync(id);
            return warehouse == null ? null : _mapper.Map<WarehouseDto>(warehouse);
        }

        public async Task<WarehouseDto> AddAsync(WarehouseDto warehouseDto)
        {
            var entity = _mapper.Map<Warehouse>(warehouseDto);
            var created = await _unitOfWork.warehouse.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<WarehouseDto>(created);
        }

        public async Task UpdateAsync(WarehouseDto warehouseDto)
        {
            var entity = _mapper.Map<Warehouse>(warehouseDto);
            await _unitOfWork.warehouse.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.warehouse.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }
    }
}
