using SIOMS.Domain.Entities;
using SIOMS.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Infrastructure.Data
{
    public static class SeedData
    {
        public static void SeedDatabase(SIOMSDbContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new() { Id = Guid.NewGuid(), Name = "Electronics" },
                    new() { Id = Guid.NewGuid(), Name = "Clothing" },
                    new() { Id = Guid.NewGuid(), Name = "Groceries" },
                    new() { Id = Guid.NewGuid(), Name = "Furniture" },
                    new() { Id = Guid.NewGuid(), Name = "Stationery" },
                    new() { Id = Guid.NewGuid(), Name = "Sports" },
                    new() { Id = Guid.NewGuid(), Name = "Toys" },
                    new() { Id = Guid.NewGuid(), Name = "Kitchenware" },
                    new() { Id = Guid.NewGuid(), Name = "Footwear" },
                    new() { Id = Guid.NewGuid(), Name = "Accessories" },
                };

                context.Categories.AddRange(categories);
                context.SaveChanges();

                var products = new List<Product>
                {
                    new() { Id = Guid.NewGuid(), ProductName="Laptop", ProductCode="ELEC001", StockQuantity=10, Price=50000, CategoryId=categories[0].Id },
                    new() { Id = Guid.NewGuid(), ProductName="Mobile", ProductCode="ELEC002", StockQuantity=50, Price=20000, CategoryId=categories[0].Id },
                    new() { Id = Guid.NewGuid(), ProductName="Shirt", ProductCode="CLOTH001", StockQuantity=30, Price=1000, CategoryId=categories[1].Id },
                    new() { Id = Guid.NewGuid(), ProductName="Rice Bag", ProductCode="GROC001", StockQuantity=100, Price=500, CategoryId=categories[2].Id },
                    new() { Id = Guid.NewGuid(), ProductName="Table", ProductCode="FURN001", StockQuantity=20, Price=2000, CategoryId=categories[3].Id },
                    new() { Id = Guid.NewGuid(), ProductName="Pen", ProductCode="STAT001", StockQuantity=200, Price=20, CategoryId=categories[4].Id },
                    new() { Id = Guid.NewGuid(), ProductName="Football", ProductCode="SPORT001", StockQuantity=15, Price=800, CategoryId=categories[5].Id },
                    new() { Id = Guid.NewGuid(), ProductName="Toy Car", ProductCode="TOY001", StockQuantity=25, Price=300, CategoryId=categories[6].Id },
                    new() { Id = Guid.NewGuid(), ProductName="Mixer Grinder", ProductCode="KITCH001", StockQuantity=10, Price=2500, CategoryId=categories[7].Id },
                    new() { Id = Guid.NewGuid(), ProductName="Shoes", ProductCode="FOOT001", StockQuantity=40, Price=1200, CategoryId=categories[8].Id }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }

            if (!context.Customers.Any())
            {
                var customers = new List<Customer>
                {
                    new() { Id = Guid.NewGuid(), Name="Ravi Kumar", Email="ravi@gmail.com" },
                    new() { Id = Guid.NewGuid(), Name="Sita Devi", Email="sita@gmail.com" },
                    new() { Id = Guid.NewGuid(), Name="Mahesh Gupta", Email="mahesh@gmail.com" },
                    new() { Id = Guid.NewGuid(), Name="Sunita", Email="sunita@gmail.com" },
                    new() { Id = Guid.NewGuid(), Name="Arjun Reddy", Email="arjun@gmail.com" }
                };

                context.Customers.AddRange(customers);
                context.SaveChanges();
            }
        }
    }
}
