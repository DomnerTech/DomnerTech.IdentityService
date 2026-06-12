using Bas24.CommandQuery;
using DomnerTech.IdentityService.Application.DTOs;
using DomnerTech.IdentityService.Application.IRepo;
using DomnerTech.IdentityService.Application.Services;
using DomnerTech.IdentityService.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace DomnerTech.IdentityService.Application.Features.Users.Handlers;

public sealed class CreateUserCommandHandler(
    ILogger<CreateUserCommandHandler> logger,
    IUserRepo repo,
    IPasswordHasherService passwordHasher) : IRequestHandler<CreateUserCommand, BaseResponse<Guid>>
{
    public async Task<BaseResponse<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var passwordHash = passwordHasher.Hash(request.Password);
            var user = new UserEntity(request.Username, request.Email, passwordHash);
            await repo.AddAsync(user, cancellationToken);
            await repo.SaveChangesAsync(cancellationToken);

            return new BaseResponse<Guid>
            {
                Data = user.Id
            };
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed to create user");
        }

        return new BaseResponse<Guid>
        {
            Status = new ResponseStatus
            {
                Desc = "Failed to create user",
                ErrorCode = "MNT-CRT-USR-FAILED",
                StatusCode = 400
            }
        };
    }
}