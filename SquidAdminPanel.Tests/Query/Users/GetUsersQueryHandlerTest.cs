using Shouldly;
using SquidAdminPanel.Api.Core.Models;
using SquidAdminPanel.Api.Core.Users;
using SquidAdminPanel.Api.Core.Users.Query.GetUsers;
using SquidAdminPanel.Api.Core.Users.Query.UserExists;
using SquidAdminPanel.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquidAdminPanel.Tests.Query.Users;

public class GetUsersQueryHandlerTest
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

    [Test]
    public async Task UserExistsQueryHandler_ShouldReturn_True()
    {
        var context = FileContextFactory.CreateUserContext("users.txt");

        var handler = new UserExistsQueryHandler(context);

        var result = await handler.Handle(new UserExistsQuery(FileContextFactory.UserNameForSearch), CancellationToken.None);

        result.ShouldBeTrue();
    }

    [Test]
    public async Task UserExistsQueryHandler_ShouldReturn_False()
    {
        var context = FileContextFactory.CreateUserContext("users.txt");

        var handler = new UserExistsQueryHandler(context);

        var result = await handler.Handle(new UserExistsQuery("Some user"), CancellationToken.None);

        result.ShouldBeFalse();
    }

}
