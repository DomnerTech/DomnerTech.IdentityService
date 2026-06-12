using Bas24.CommandQuery;
using DomnerTech.IdentityService.Application.Abstractions;
using DomnerTech.IdentityService.Application.DTOs;

namespace DomnerTech.IdentityService.Application.Features.Users;

public sealed record CreateUserCommand(
    string Username,
    string Email,
    string Password) :
    IRequest<BaseResponse<Guid>>,
    ILogCreator, 
    IValidatableRequest;