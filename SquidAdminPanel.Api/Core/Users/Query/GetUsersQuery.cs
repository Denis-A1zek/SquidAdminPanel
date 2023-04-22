using MediatR;
using SquidAdminPanel.Api.Core.Models;

namespace SquidAdminPanel.Api.Core.Users;

public sealed class GetUsersQuery : IRequest<List<User>> { }
