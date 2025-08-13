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
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserProfileDto> GetProfileAsync(Guid userId)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(userId);
            if (customer == null) throw new Exception("User not found");

            return new UserProfileDto
            {
                Id = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email
            };
        }

        public async Task UpdateProfileAsync(Guid userId, UserProfileDto updatedProfile)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(userId);
            if (customer == null) throw new Exception("User not found");

            customer.Name = updatedProfile.Name;
            customer.Email = updatedProfile.Email;

            await _unitOfWork.CommitAsync();
        }
    }
}
