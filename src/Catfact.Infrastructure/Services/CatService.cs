using System.Net.Http.Json;
using Catfact.Core.Abstractions;
using Catfact.Core.Models;

namespace Catfact.Infrastructure.Services;

internal class CatService : ICatService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CatService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Cat?> GetCatAsync()
    {
        var client = _httpClientFactory.CreateClient("client");
        var url = $"/fact";

        var response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Cat>();
        }

        return null; 
    }
}