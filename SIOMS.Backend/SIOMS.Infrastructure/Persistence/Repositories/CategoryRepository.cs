using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIOMS.Domain.Entities;
using SIOMS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SIOMS.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SIOMSDbContext context) : base(context)
        {
        }
    }
}
