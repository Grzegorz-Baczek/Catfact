using Catfact.Application.Abstractions;
using Catfact.Core.Models;

namespace Catfact.Application.Queries;

public record GetCats : IQuery<List<Cat>>;