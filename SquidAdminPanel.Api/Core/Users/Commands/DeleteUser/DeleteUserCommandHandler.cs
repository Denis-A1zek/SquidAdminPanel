using MediatR;
using SquidAdminPanel.Api.Core.Exceptions;
using SquidAdminPanel.Api.Core.Processes;
using SquidAdminPanel.Api.Core.Users.Query.UserExists;

namespace SquidAdminPanel.Api.Core.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, string>
{
    private readonly IMediator _mediator;
    private readonly HtpasswdManager _htpasswd;

    public DeleteUserCommandHandler(IMediator mediator, HtpasswdManager htpasswd) =>
        (_mediator, _htpasswd) = (mediator, htpasswd);
    public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _mediator.Send(new UserExistsQuery(request.Name));
        if (!userExists)
            throw new NotFoundException(request.Name);

        await _htpasswd.DeleteUser(request.Name);
        return request.Name;
    }
}
