using MediatR;
using Microsoft.AspNetCore.Mvc;
using SquidAdminPanel.Api.Application.Cache;
using SquidAdminPanel.Api.Core;
using SquidAdminPanel.Api.Core.Logs.Query;
using SquidAdminPanel.Api.Core.Models;
using SquidAdminPanel.Api.Core.Users;
using System.Text;
using System.Text.Json;

namespace SquidAdminPanel.Api.Application
{
    public class LogApi : IApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/streamlogs/{id}", Get)
                .Produces<LogsResponse>(StatusCodes.Status200OK)
                .WithName("CreateEnvetStreamLogs")
                .WithTags("Log"); ;
        }

        private async Task Get(Guid id,HttpContext context,
            [FromServices] IMediator mediator, [FromServices] IGlobalCacheMemory cacheMemory)
        {
            var response = context.Response;
            response.Headers.ContentType = "text/event-stream";
            
            var recentTimeAccess = cacheMemory.GetLastValue(id);
            var logs = await mediator.Send(new GetLogsQuery(recentTimeAccess));
            cacheMemory.SetValue(id, logs.RecentLogs ?? recentTimeAccess);

            var serializeLogs = JsonSerializer.Serialize<LogsResponse>(logs);
            byte[] messageBute = ASCIIEncoding.ASCII.GetBytes($"data: {serializeLogs} \n\n");
            await response.Body.WriteAsync(messageBute, 0, messageBute.Length);
            await response.Body.FlushAsync();
        }
    }
}
