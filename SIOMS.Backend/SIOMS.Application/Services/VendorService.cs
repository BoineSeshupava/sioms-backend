using AutoMapper;
using SIOMS.Application.DTOs;
using SIOMS.Application.Interfaces;
using SIOMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Application.Services
{
    public class VendorService : IVendorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public VendorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<VendorDto> AddAsync(VendorDto vendorDto)
        {
            var entity = _mapper.Map<Domain.Entities.Vendor>(vendorDto);
            var created =  await _unitOfWork.Vendors.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            var result = _mapper.Map<VendorDto>(created);
            return result;
        }

        public async Task DeleteAsync(int id)
        {
            if(id <= 0) throw new ArgumentException("Invalid ID");
            await _unitOfWork.Vendors.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            return;
        }

        public async Task<IEnumerable<VendorDto>> GetAllAsync()
        {
            var vendors = await _unitOfWork.Vendors.GetAllAsync();
            var result = _mapper.Map<IEnumerable<VendorDto>>(vendors);
            return result;
        }

        public async Task<VendorDto?> GetByIdAsync(int id)
        {
            var vendor = await _unitOfWork.Vendors.GetByIdAsync(id);
            var result = vendor == null ? null : _mapper.Map<VendorDto>(vendor);
            return result;
        }

        public async Task UpdateAsync(VendorDto warehouseDto)
        {
            var entity = _mapper.Map<Domain.Entities.Vendor>(warehouseDto);
            if(entity.Id <= 0) throw new ArgumentException("Invalid ID");
            await _unitOfWork.Vendors.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
            return;
        }
    }
}
