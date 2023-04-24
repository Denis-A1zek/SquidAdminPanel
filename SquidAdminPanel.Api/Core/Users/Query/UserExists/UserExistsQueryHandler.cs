using MediatR;
using SquidAdminPanel.Api.Core.Models;
using SquidAdminPanel.Api.Data;

namespace SquidAdminPanel.Api.Core.Users.Query.UserExists;

public class UserExistsQueryHandler : IRequestHandler<UserExistsQuery, bool>
{
    private readonly UserContext _userContext;

    public UserExistsQueryHandler(UserContext context) => _userContext = context;

    public async Task<bool> Handle(UserExistsQuery request, CancellationToken cancellationToken)
    {
        return await _userContext.QueryReadAllLineAsync<bool>(usersFile =>
        {
            foreach (var (user, i) in usersFile.Select((user, i) => (user, i)))
            {
                var splitUser = user.Split(':');
                if (splitUser[0].Equals(request.UserName))
                    return true;
            }

            return false;
        });
    }
}
