using Microsoft.EntityFrameworkCore;
using SIOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Infrastructure.Persistence
{
    public class SIOMSDbContext : DbContext
    {
        public SIOMSDbContext(DbContextOptions<SIOMSDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                        .Property(p => p.Price)
                        .HasPrecision(18, 2);
            modelBuilder.Entity<Role>().HasData(
            new Role { RoleId = Guid.Parse("11111111-1111-1111-1111-111111111111"), RoleName = "Admin" },
            new Role { RoleId = Guid.Parse("22222222-2222-2222-2222-222222222222"), RoleName = "Customer" }
        );
        }
    }
}
