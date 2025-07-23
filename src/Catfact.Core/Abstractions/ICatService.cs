using Catfact.Core.Models;

namespace Catfact.Core.Abstractions;

public interface ICatService
{
    Task<Cat?> GetCatAsync();
}