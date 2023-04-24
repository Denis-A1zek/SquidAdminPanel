using FluentValidation;
using MediatR;

namespace SquidAdminPanel.Api.Core.Users.Commands.CreateUser;

public sealed record CreateUserCommand(string UserName, string Password) : IRequest<string>;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().MinimumLength(2).MaximumLength(40);
    }
}
