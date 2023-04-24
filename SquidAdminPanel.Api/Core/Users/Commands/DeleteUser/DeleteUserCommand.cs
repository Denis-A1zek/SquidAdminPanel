using FluentValidation;
using MediatR;
using SquidAdminPanel.Api.Core.Users.Commands.CreateUser;

namespace SquidAdminPanel.Api.Core.Users.Commands.DeleteUser;

public sealed record DeleteUserCommand(string Name) : IRequest<string>;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(40);
    }
}
