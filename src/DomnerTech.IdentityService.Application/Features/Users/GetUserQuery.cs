using Bas24.CommandQuery;
using DomnerTech.IdentityService.Application.Abstractions;
using DomnerTech.IdentityService.Application.DTOs;
using DomnerTech.IdentityService.Application.DTOs.Users;

namespace DomnerTech.IdentityService.Application.Features.Users;

public sealed record GetUserQuery(Guid UserId) : IRequest<BaseResponse<UserDto>>, ILogCreator, IValidatableRequest;