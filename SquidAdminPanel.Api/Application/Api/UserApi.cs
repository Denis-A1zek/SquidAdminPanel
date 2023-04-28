using MediatR;
using Microsoft.AspNetCore.Mvc;
using SquidAdminPanel.Api.Core;
using SquidAdminPanel.Api.Core.Models;
using SquidAdminPanel.Api.Core.Users;
using SquidAdminPanel.Api.Core.Users.Commands.CreateUser;
using SquidAdminPanel.Api.Core.Users.Commands.DeleteUser;

namespace SquidAdminPanel.Api.Application;

public class UserApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("api/users", GetAll)
            .Produces<List<User>>(StatusCodes.Status200OK)
            .WithName("GetAllUsers")
            .WithTags("User");

        app.MapPost("api/user", Post)
            .Produces<string>(StatusCodes.Status200OK)
            .WithName("CreateUser")
            .WithTags("User");

        app.MapDelete("api/user/{userName}", Delete)
            .Produces<string>(StatusCodes.Status200OK)
            .WithName("DeleteUser")
            .WithTags("User");
    }



    /// <summary>
    /// Gets users 
    /// </summary>
    /// <remarks>
    /// GET /api/users
    /// </remarks>
    /// <param name="mediator"></param>
    /// <returns>Returns the users of the proxy server</returns>
    /// <response code="200">Success</response>
    private async Task<IResult> GetAll([FromServices]IMediator mediator) =>
        Results.Ok(await mediator.Send(new GetUsersQuery()));

    /// <summary>
    /// Creates a new user
    /// </summary>
    /// <remarks>
    /// POST api/user/
    /// </remarks>
    /// <param name="user">User</param>
    /// <param name="mediator"></param>
    /// <returns>Username</returns>
    private async Task<IResult> Post(UserRequest user, [FromServices] IMediator mediator) =>
        Results.Ok(await mediator.Send(new CreateUserCommand(user.Name, user.Password)));

    /// <summary>
    /// Deletes a user from the proxy
    /// </summary>
    /// <param name="userName">Username</param>
    /// <param name="mediator"></param>
    /// <returns>Username</returns>
    private async Task<IResult> Delete(string userName, [FromServices] IMediator mediator) =>
        Results.Ok(await mediator.Send(new DeleteUserCommand(userName)));
}
