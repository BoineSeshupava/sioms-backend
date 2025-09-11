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

            if (!context.Warehouses.Any())
            {
                var warehouses = new List<Warehouse>
                {
                    new() { Name = "Central Warehouse", Location = "Downtown" },
                    new() { Name = "North Warehouse", Location = "Northside" },
                    new() { Name = "South Warehouse", Location = "Southside" }
                };

                context.Warehouses.AddRange(warehouses);
                context.SaveChanges();
            }

            if (!context.Vendors.Any())
            {
                var vendors = new List<Vendor>
                {
                    new() { Name = "ABC Supplies", Address = "123 Main St", ContactEmail = "contact@abcsupplies.com", Phone = 1234567890 },
                    new() { Name = "Global Traders", Address = "456 Market Ave", ContactEmail = "info@globaltraders.com", Phone = 9876543210 },
                    new() { Name = "Prime Distributors", Address = "789 Commerce Rd", ContactEmail = "sales@primedist.com", Phone = 5551234567 }
                };

                context.Set<Vendor>().AddRange(vendors);
                context.SaveChanges();
            }

            // Seed InventoryItems if none exist
            if (!context.InventoryItems.Any())
            {
                var products = context.Products.ToList();
                var categories = context.Categories.ToList();
                var warehouses = context.Warehouses.ToList();

                var inventoryItems = new List<InventoryItem>();

                // Assign each product to a warehouse and category for demo purposes
                for (int i = 0; i < products.Count; i++)
                {
                    var product = products[i];
                    var category = categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);
                    var warehouse = warehouses[i % warehouses.Count];

                    inventoryItems.Add(new InventoryItem
                    {
                        InventoryItemId = Guid.NewGuid(),
                        ItemName = product.ProductName,
                        Quantity = product.StockQuantity,
                        ProductId = product.ProductId,
                        CategoryId = product.CategoryId,
                        WarehouseId = warehouse.Id,
                        CreatedDate = DateTime.UtcNow
                    });
                }

                context.InventoryItems.AddRange(inventoryItems);
                context.SaveChanges();
            }
        }
    }
}
