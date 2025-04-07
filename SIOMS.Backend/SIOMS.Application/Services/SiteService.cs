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
    public class SiteService : ISiteService
    {
        private readonly ISiteRepository _repository;
        private readonly IMapper _mapper;

        public SiteService(ISiteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SiteDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SiteDto>>(items);
        }

        public async Task<SiteDto> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return _mapper.Map<SiteDto>(item);
        }

        public async Task AddAsync(SiteDto itemDto)
        {
            var entity = _mapper.Map<Site>(itemDto);
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(SiteDto itemDto)
        {
            var entity = _mapper.Map<Site>(itemDto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
