using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class CatalogContextSeed
{
    public static void SeedData(IMongoCollection<Product> productCollection)
    {
        var checkProducts = productCollection.Find(b => true).Any();
        var path = Path.Combine("Data", "SeedData", "products.json");
        if (checkProducts) return;
        var productsData = File.ReadAllText(path);
        var products = JsonSerializer.Deserialize<List<Product>>(productsData);
        if (products == null) return;
        foreach (var item in products)
        {
            productCollection.InsertOneAsync(item);
        }
    }
}