using SquidAdminPanel.Api.Core.Models;
using SquidAdminPanel.Api.Core.Users.Query.GetUsers;
using SquidAdminPanel.Api.Core.Users;
using SquidAdminPanel.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SquidAdminPanel.Api.Core.Logs.Query;
using SquidAdminPanel.Api.Core.Interfaces;
using SquidAdminPanel.Api.Core.Helpers;
using Shouldly;
using SquidAdminPanel.Api.Core;
using NUnit.Framework;

namespace SquidAdminPanel.Tests.Query.Logs;

public class GetLogsQueryHandlerTest
{
    [Test]
    public async Task GetLogsQueryHandler_ShouldReturn_ListWithLogs()
    {
        var context = FileContextFactory.CreateLogsContext("logs.txt");
        ILogReader reader = new LogReader(context);

        var handler = new GetLogsQueryHandler(reader);

        var result = await handler.Handle(new GetLogsQuery("1"), CancellationToken.None);

        result.ShouldBeOfType<LogsResponse>();
        result.Logs.ShouldNotBeEmpty();
        result.Logs.Count.ShouldBe(FileContextFactory.CountOfLogs);
    }

    [Test]
    public async Task GetLogsQueryHandler_ShouldReturn_ListWithLogs_LessThan9AndTheFirstElementMustBe1681538160914()
    {
        var context = FileContextFactory.CreateLogsContext("logs.txt");
        ILogReader reader = new LogReader(context);

        var handler = new GetLogsQueryHandler(reader);

        var result = await handler.Handle(new GetLogsQuery(FileContextFactory.LogTime), CancellationToken.None);

        result.ShouldBeOfType<LogsResponse>();
        result.Logs.ShouldNotBeEmpty();
        result.Logs.Count.ShouldBeLessThan(FileContextFactory.CountOfLogs);
        result.Logs.Count.ShouldBeGreaterThan(0);
        var logDate = Converter.SecondsToDateConverter(FileContextFactory.LogTime);
        result.Logs.First().Time.ShouldBe($"{logDate.ToShortDateString()} {logDate.ToShortTimeString()}");
    }
}
