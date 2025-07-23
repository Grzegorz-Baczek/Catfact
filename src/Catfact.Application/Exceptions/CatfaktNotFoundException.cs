using Catfact.Core.Exceptions;

namespace Catfact.Application.Exceptions;

public sealed class CatfaktNotFoundException : CustomException
{ 
    public CatfaktNotFoundException() : base("Catfakt is null or empty")
    {
    }
}