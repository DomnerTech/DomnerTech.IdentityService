using DomnerTech.IdentityService.Application.Errors;
using Microsoft.AspNetCore.Http;

namespace DomnerTech.IdentityService.Application.Exceptions;

public sealed class NotFoundException(string message) : BaseErrorException(message)
{
    public override int StatusCode => StatusCodes.Status404NotFound;
    public override string Code => ErrorCodes.NotFound;
}