﻿using SharpEcommerce.Core.Entities;
using System.Text.Json;

namespace SharpEcommerce.Infrastructure.Data
{
    public class EcommerceContextSeed
    {
        public static async Task SeedAsync(EcommerceDbContext context) 
        {
            if(!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("/Users/ehlkara/Documents/GitHub/SharpEcommerce/SharpEcommerce.Infrastructure/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands);
            }
            if (!context.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("/Users/ehlkara/Documents/GitHub/SharpEcommerce/SharpEcommerce.Infrastructure/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types);
            }
            if (!context.Products.Any())
            {
                var productsData = File.ReadAllText("/Users/ehlkara/Documents/GitHub/SharpEcommerce/SharpEcommerce.Infrastructure/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);
            }

            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}
