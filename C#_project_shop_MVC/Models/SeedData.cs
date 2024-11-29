using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using project_shop_MVC.Data;
using project_shop_MVC.Models;
using System;
using System.Linq;

namespace project_shop_MVC.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new project_shop_MVC_Context(
                serviceProvider.GetRequiredService<DbContextOptions<project_shop_MVC_Context>>()))
            {
                // Look for any existing data.
                if (context.Shoes.Any())
                {
                    return;   
                }

                // Shoes data
                context.Shoes.AddRange(
                    new Shoes
                    {
                        SaleId = 1,
                        Name = "Casual Sneakers",
                        Price = 59,
                        Season = "Spring",
                        Material = "Canvas",
                        Description = "Comfortable sneakers for everyday wear."
                    },
                    new Shoes
                    {
                        SaleId = 1,
                        Name = "Formal Loafers",
                        Price = 79,
                        Season = "Summer",
                        Material = "Leather",
                        Description = "Elegant loafers for formal occasions."
                    },
                    new Shoes
                    {
                        SaleId = 3,
                        Name = "Running Shoes",
                        Price = 69,
                        Season = "Fall",
                        Material = "Mesh",
                        Description = "Lightweight running shoes for fitness enthusiasts."
                    },
                    new Shoes
                    {
                        SaleId = 1,
                        Name = "Winter Boots",
                        Price = 89,
                        Season = "Winter",
                        Material = "Leather",
                        Description = "Warm and stylish boots for winter days."
                    },
                    new Shoes
                    {
                        SaleId = 1,
                        Name = "Office Pumps",
                        Price = 74,
                        Season = "All Seasons",
                        Material = "Suede",
                        Description = "Classic pumps suitable for any season."
                    },
                    new Shoes
                    {
                        SaleId = 1,
                        Name = "Basketball Shoes",
                        Price = 89,
                        Season = "All Seasons",
                        Material = "Synthetic",
                        Description = "High-performance basketball shoes for the court."
                    },
                    new Shoes
                    {
                        SaleId = 3,
                        Name = "Hiking Boots",
                        Price = 99,
                        Season = "Fall",
                        Material = "Waterproof Leather",
                        Description = "Durable hiking boots for outdoor adventures."
                    },
                    new Shoes
                    {
                        SaleId = 1,
                        Name = "Sandals",
                        Price = 49,
                        Season = "Summer",
                        Material = "Rubber",
                        Description = "Comfortable sandals for hot summer days."
                    },
                    new Shoes
                    {
                        SaleId = 2,
                        Name = "Dress Shoes",
                        Price = 69,
                        Season = "All Seasons",
                        Material = "Patent Leather",
                        Description = "Stylish dress shoes for formal occasions."
                    },
                    new Shoes
                    {
                        SaleId = 3,
                        Name = "Skate Shoes",
                        Price = 79,
                        Season = "All Seasons",
                        Material = "Canvas",
                        Description = "Skateboard shoes for street-style enthusiasts."
                    },
                    new Shoes
                    {
                        SaleId = 1,
                        Name = "Rain Boots",
                        Price = 59,
                        Season = "Spring",
                        Material = "Rubber",
                        Description = "Waterproof rain boots for wet weather."
                    },
                    new Shoes
                    {
                        SaleId = 4,
                        Name = "Espadrilles",
                        Price = 39,
                        Season = "Summer",
                        Material = "Jute",
                        Description = "Lightweight espadrilles for a casual look."
                    },
                    new Shoes
                    {
                        SaleId = 1,
                        Name = "Sneaker Boots",
                        Price = 69,
                        Season = "Fall",
                        Material = "Leather",
                        Description = "Stylish boots with a sneaker-inspired design."
                    },
                    new Shoes
                    {
                        SaleId = 3,
                        Name = "Golf Shoes",
                        Price = 89,
                        Season = "All Seasons",
                        Material = "Synthetic",
                        Description = "Specialized golf shoes for the golf course."
                    },
                    new Shoes
                    {
                        SaleId = 1,
                        Name = "Moccasins",
                        Price = 59,
                        Season = "All Seasons",
                        Material = "Suede",
                        Description = "Comfortable moccasins for a relaxed style."
                    });

                // Sales data
                context.Sales.AddRange(
                    new Sales
                    {
                        SalePercent = 0,
                        StartDate = DateTime.Parse("2024-01-01"),
                        EndDate = DateTime.Parse("2024-12-31"),
                        Description = "No sale"
                    },
                    new Sales
                    {
                        SalePercent = 15,
                        StartDate = DateTime.Parse("2024-02-15"),
                        EndDate = DateTime.Parse("2024-02-28"),
                        Description = "Spring Sale - 10% off on selected items."
                    },
                    new Sales
                    {
                        SalePercent = 20,
                        StartDate = DateTime.Parse("2024-03-01"),
                        EndDate = DateTime.Parse("2024-03-15"),
                        Description = "March Madness - 20% off on sports shoes."
                    },
                    new Sales
                    {
                        SalePercent = 25,
                        StartDate = DateTime.Parse("2024-04-05"),
                        EndDate = DateTime.Parse("2024-04-20"),
                        Description = "Spring Clearance - 25% off on clearance items."
                    });

                context.SaveChanges();
            }
        }
    }
}
