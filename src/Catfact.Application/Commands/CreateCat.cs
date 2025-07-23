using Catfact.Application.Abstractions;
using Catfact.Core.Models;

namespace Catfact.Application.Commands;

public sealed record CreateCat(Cat Cat) : ICommand;