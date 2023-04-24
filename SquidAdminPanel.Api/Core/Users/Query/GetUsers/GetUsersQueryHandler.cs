using MediatR;
using SquidAdminPanel.Api.Core.Models;
using SquidAdminPanel.Api.Data;
using SquidAdminPanel.Api.Data.Base;

namespace SquidAdminPanel.Api.Core.Users.Query.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        private readonly UserContext _userContext;

        public GetUsersQueryHandler(UserContext context) => _userContext = context;

        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userContext.QueryReadAllLineAsync(usersFile =>
            {
                var usersList = new List<User>();
                foreach (var (user, i) in usersFile.Select((user, i) => (user, i)))
                {
                    var splitUser = user.Split(':');
                    usersList.Add(new User(i, splitUser[0]));
                }

                return usersList;
            });
        }
    }
}
