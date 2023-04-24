using MediatR;

namespace SquidAdminPanel.Api.Core.Users.Query.UserExists;

public sealed record UserExistsQuery(string UserName) : IRequest<bool>;
