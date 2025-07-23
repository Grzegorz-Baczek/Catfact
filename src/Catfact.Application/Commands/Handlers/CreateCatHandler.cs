using Catfact.Application.Abstractions;
using Catfact.Application.Exceptions;
using Catfact.Core.Abstractions;
using Catfact.Core.Repositories;

namespace Catfact.Application.Commands.Handlers;

public sealed class CreateCatHandler : ICommandHandler<CreateCat> //sprawdz czy sealed moze byc z public i moze w inny sposob zarejstroj di skoro ta klasa musi byc publiczna do tego
{
    private readonly ICatService _catService;
    private readonly ICatRepository _catRepository;

    public CreateCatHandler(ICatService catService, ICatRepository catRepository)
    {
        _catService = catService;
        _catRepository = catRepository;
    }

    public async Task HandleAsync(CreateCat command)
    {
        var cat = await _catService.GetCatAsync();
        if (string.IsNullOrEmpty(cat?.Fact))
        {
            throw new CatfaktNotFoundException(); 
        }

        await _catRepository.AddCatAsync(cat);
    }
}