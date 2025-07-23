using Catfact.Application.Abstractions;
using Catfact.Application.Queries;
using Catfact.Core.Models;
using Catfact.Core.Repositories;

namespace Catfact.Infrastructure.Handlers;

internal class GetCatsHandler : IQueryHandler<GetCats, List<Cat>>
{
    private readonly ICatRepository _catRepository;

    public GetCatsHandler(ICatRepository catRepository)
    {
        _catRepository = catRepository;
    }

    public async Task<List<Cat>> HandleAsync(GetCats query)
    {
        return await _catRepository.GetCatsAsync();
    }
} 