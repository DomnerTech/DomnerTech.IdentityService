using Bas24.CommandQuery;
using DomnerTech.IdentityService.Application.DTOs;

namespace DomnerTech.IdentityService.Application.Features.Users.Handlers;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseResponse<bool>>
{
    public async Task<BaseResponse<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new BaseResponse<bool>
        {
            Data = true
        });
    }
}