using SIOMS.Domain.Entities;
using SIOMS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly SIOMSDbContext _context;

        public ProductRepository(SIOMSDbContext context) : base(context)
        {
        }

        public async Task<Product> GetProductWithCategoryAsync(Guid productId)
        {
            return await _context.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.ProductId == productId);
        }
    }
}
