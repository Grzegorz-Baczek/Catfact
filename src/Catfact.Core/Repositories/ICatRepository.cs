using Catfact.Core.Models;

namespace Catfact.Core.Repositories;

public interface ICatRepository
{
    Task AddCatAsync(Cat cat);
    Task<List<Cat>> GetCatsAsync();
}