using FluentValidation;
using MediatR;
using SquidAdminPanel.Api.Core.Users.Commands.DeleteUser;

namespace SquidAdminPanel.Api.Core.Users.Query.UserExists;

public sealed record UserExistsQuery(string UserName) : IRequest<bool>;

public class UserExistsQueryValidator : AbstractValidator<UserExistsQuery>
{
    public UserExistsQueryValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().MinimumLength(2).MaximumLength(40);
    }
}