using MediatR;

namespace SquidAdminPanel.Api.Core.Users.Commands.DeleteUser;

public sealed record DeleteUserCommand(string Name) : IRequest<string>;
