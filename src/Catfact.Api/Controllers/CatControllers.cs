using Catfact.Application.Abstractions;
using Catfact.Application.Commands;
using Catfact.Application.Queries;
using Catfact.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catfact.Api.Controllers;

[Route("api")]
[ApiController]
public class CatControllers : ControllerBase
{
    private readonly ICommandHandler<CreateCat> _createCat;
    private readonly IQueryHandler<GetCats, List<Cat>> _getCats;

    public CatControllers(ICommandHandler<CreateCat> createCat,
        IQueryHandler<GetCats, List<Cat>> getCats)
    {
        _createCat = createCat;
        _getCats = getCats;
    }

    [HttpPost("cat")]
    public async Task<ActionResult> CreateCat()
    {
        await _createCat.HandleAsync(new CreateCat());
        return NoContent();
    }

    [HttpGet("cats")]
    public async Task<List<Cat>> GetCats()
    {
        var cats = await _getCats.HandleAsync(new GetCats());
        return cats;
    }
}