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
                    new() { CategoryId = Guid.NewGuid(), Name = "Electronics" },
                    new() { CategoryId = Guid.NewGuid(), Name = "Clothing" },
                    new() { CategoryId = Guid.NewGuid(), Name = "Groceries" },
                    new() { CategoryId = Guid.NewGuid(), Name = "Furniture" },
                    new() { CategoryId = Guid.NewGuid(), Name = "Stationery" },
                    new() { CategoryId = Guid.NewGuid(), Name = "Sports" },
                    new() { CategoryId = Guid.NewGuid(), Name = "Toys" },
                    new() { CategoryId = Guid.NewGuid(), Name = "Kitchenware" },
                    new() { CategoryId = Guid.NewGuid(), Name = "Footwear" },
                    new() { CategoryId = Guid.NewGuid(), Name = "Accessories" },
                };

                context.Categories.AddRange(categories);
                context.SaveChanges();

                var products = new List<Product>
                {
                    new() { ProductId = Guid.NewGuid(), ProductName="Laptop", ProductCode="ELEC001", StockQuantity=10, Price=50000, CategoryId=categories[0].CategoryId },
                    new() { ProductId = Guid.NewGuid(), ProductName="Mobile", ProductCode="ELEC002", StockQuantity=50, Price=20000, CategoryId=categories[0].CategoryId },
                    new() { ProductId = Guid.NewGuid(), ProductName="Shirt", ProductCode="CLOTH001", StockQuantity=30, Price=1000, CategoryId=categories[1].CategoryId },
                    new() { ProductId = Guid.NewGuid(), ProductName="Rice Bag", ProductCode="GROC001", StockQuantity=100, Price=500, CategoryId=categories[2].CategoryId },
                    new() { ProductId = Guid.NewGuid(), ProductName="Table", ProductCode="FURN001", StockQuantity=20, Price=2000, CategoryId=categories[3].CategoryId },
                    new() { ProductId = Guid.NewGuid(), ProductName="Pen", ProductCode="STAT001", StockQuantity=200, Price=20, CategoryId=categories[4].CategoryId },
                    new() { ProductId = Guid.NewGuid(), ProductName="Football", ProductCode="SPORT001", StockQuantity=15, Price=800, CategoryId=categories[5].CategoryId },
                    new() { ProductId = Guid.NewGuid(), ProductName="Toy Car", ProductCode="TOY001", StockQuantity=25, Price=300, CategoryId=categories[6].CategoryId },
                    new() { ProductId = Guid.NewGuid(), ProductName="Mixer Grinder", ProductCode="KITCH001", StockQuantity=10, Price=2500, CategoryId=categories[7].CategoryId },
                    new() { ProductId = Guid.NewGuid(), ProductName="Shoes", ProductCode="FOOT001", StockQuantity=40, Price=1200, CategoryId=categories[8].CategoryId }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
