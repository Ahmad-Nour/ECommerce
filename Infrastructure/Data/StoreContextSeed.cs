using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context , ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText(@"../Infrastructure/Data/SeedData/Brands.json");
                    var brands = JsonSerializer.Deserialize< List < ProductBrand > > (brandsData);
                    foreach(var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if(!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText(@"../Infrastructure/Data/SeedData/Types.json");
                    var  types = JsonSerializer.Deserialize< List < ProductType > > (typesData);
                    foreach(var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if(!context.Products.Any())
                {
                    var productsData = File.ReadAllText(@"../Infrastructure/Data/SeedData/Products.json");
                    var  product = JsonSerializer.Deserialize< List < Product > > (productsData);
                    foreach(var item in product)
                    {
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger< StoreContextSeed >();
                logger.LogError(ex.Message);
            }
        }
    }
}