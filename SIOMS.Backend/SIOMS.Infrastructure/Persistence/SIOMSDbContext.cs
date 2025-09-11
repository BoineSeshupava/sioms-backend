using Microsoft.EntityFrameworkCore;
using SIOMS.Application.DTOs;
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
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<StockAlertDto> StockAlerts { get; set; }
        public DbSet<SalesReportDto> SalesReport { get; set; }
        public DbSet<InventoryReportDto> InventoryReport { get; set; }



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

            modelBuilder.Entity<StockAlertDto>().HasNoKey().ToView("vw_StockAlerts");
            modelBuilder.Entity<SalesReportDto>().HasNoKey().ToView("vw_SalesReport");
            modelBuilder.Entity<InventoryReportDto>().HasNoKey().ToView("vw_InventoryReport");
        }
    }
}
