using MediatR;
using SquidAdminPanel.Api.Core.Exceptions;
using SquidAdminPanel.Api.Core.Models;
using SquidAdminPanel.Api.Core.Processes;
using SquidAdminPanel.Api.Core.Users.Query.UserExists;
using SquidAdminPanel.Api.Data;

namespace SquidAdminPanel.Api.Core.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly IMediator _mediator;
    private readonly HtpasswdManager _htpasswd;

    public CreateUserCommandHandler(IMediator mediator,HtpasswdManager htpasswd) =>
        (_mediator, _htpasswd) = (mediator, htpasswd);

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _mediator.Send(new UserExistsQuery(request.UserName));
        if(userExists)
            throw new UserExistsException($"Пользователь с именем {request.UserName} уже существует");

        await _htpasswd.CreateNewUserAsync(request.UserName, request.Password);
        return request.UserName;
    }
}
