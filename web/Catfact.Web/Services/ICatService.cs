using Catfact.Web.Dtos;

namespace Catfact.Web.Services;

public interface ICatService
{
    Task AddCatAsync();
    Task<List<CatDto>?> GetCatsAsync();
}
