using MediatR;

namespace SquidAdminPanel.Api.Core.Users.Commands.CreateUser;

public sealed record CreateUserCommand(string UserName, string Password) : IRequest<string>;
