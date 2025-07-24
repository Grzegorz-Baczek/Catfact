using Catfact.Web.Dtos;

namespace Catfact.Web.Services;

internal sealed class CatService : ICatService
{
    private readonly HttpClient _httpClient;

    public CatService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddCatAsync()
    {
        await _httpClient.PostAsync("api/cat", null);
    }

    public async Task<List<CatDto>?> GetCatsAsync()
    {
        var cats = await _httpClient.GetFromJsonAsync<List<CatDto>>("api/cats");
        return cats;
    }
}