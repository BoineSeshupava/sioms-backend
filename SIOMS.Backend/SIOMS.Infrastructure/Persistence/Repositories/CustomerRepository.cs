using Microsoft.EntityFrameworkCore;
using SIOMS.Domain.Entities;
using SIOMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SIOMSDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetCustomerOrdersAsync(Guid customerId)
        {
            return await _context.Orders
                .Where(order => order.CustomerId == customerId)
                .ToListAsync();
        }
    }
}
