using Bas24.CommandQuery;
using DomnerTech.IdentityService.Application.DTOs;
using DomnerTech.IdentityService.Application.DTOs.Users;
using DomnerTech.IdentityService.Application.Features.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DomnerTech.IdentityService.Api.Controllers;

public sealed class UserController(ICommandQuery commandQuery) : BaseApiController
{
    [HttpPost("get-user"), AllowAnonymous]
    public async Task<ActionResult<BaseResponse<UserDto>>> GetUser([FromBody] GetUserReqDto r)
    {
        var user = await commandQuery.Send(new GetUserQuery(r.UserId), HttpContext.RequestAborted);
        return user.ReturnJson();
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<bool>>> CreateUser([FromBody] CreateUserDto r)
    {
        var result = await commandQuery.Send(new CreateUserCommand(r.Username, r.Age), HttpContext.RequestAborted);
        return result.ReturnJson();
    }
}