using MediatR;
using SquidAdminPanel.Api.Core.Processes;

namespace SquidAdminPanel.Api.Core.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly HtpasswdManager _htpasswd;

    public CreateUserCommandHandler(HtpasswdManager htpasswd) =>
        _htpasswd = htpasswd;

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await _htpasswd.CreateNewUserAsync(request.UserName, request.Password);
        return request.UserName;
    }
}
