using MediatR;
using SquidAdminPanel.Api.Core.Models;
using SquidAdminPanel.Api.Data;

namespace SquidAdminPanel.Api.Core.Users
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        private readonly FileContext _fileContext;

        public GetUsersQueryHandler(FileContext context) => _fileContext = context;

        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _fileContext.QueryReadAllLineAsync<List<User>>(usersFile =>
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
