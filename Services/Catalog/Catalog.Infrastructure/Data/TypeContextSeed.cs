using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class TypeContextSeed
{
    public static void SeedData(IMongoCollection<ProductType> typeCollection)
    {
        var checkTypes = typeCollection.Find(b => true).Any();
        var path = Path.Combine("Data", "SeedData", "types.json");
        if (checkTypes) return;
        var typesData = File.ReadAllText(path);
        var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
        if (types == null) return;
        foreach (var item in types)
        {
            typeCollection.InsertOneAsync(item);
        }
    }
}