using Shouldly;
using SquidAdminPanel.Api.Core.Models;
using SquidAdminPanel.Api.Core.Users;
using SquidAdminPanel.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquidAdminPanel.Tests.Query.Users;

public class GetUsersQueryTest
{

    [Test]
    public async Task GetUsersQueryHandler_ShouldReturn_ListWithUsersAsync()
    {
        var context = FileContextFactory.CreateUserContext("users.txt");

        var handler = new GetUsersQueryHandler(context);

        var result = await handler.Handle(new GetUsersQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<User>>();
        result.Count.ShouldBeGreaterThan(0);
    }
}
