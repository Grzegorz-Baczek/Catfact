using Catfact.Core.Models;
using System.Text.Json;
using Catfact.Core.Repositories;

namespace Catfact.Infrastructure.Repositories;

internal sealed class CatRepository : ICatRepository
{
    private readonly string _filePath = "catfacts.txt";

    public async Task AddCatAsync(Cat cat)
    {
        var catList = new List<Cat>();

        if (File.Exists(_filePath))
        {
            var json = await File.ReadAllTextAsync(_filePath);
            catList = JsonSerializer.Deserialize<List<Cat>>(json) ?? new List<Cat>();
        }

        catList.Add(cat);

        var updatedJson = JsonSerializer.Serialize(catList, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(_filePath, updatedJson);
    }
            
    public async Task<List<Cat>> GetCatsAsync()
    {
        if (!File.Exists(_filePath))
            return new List<Cat>();

        var json = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<List<Cat>>(json) ?? new List<Cat>();
    }
}