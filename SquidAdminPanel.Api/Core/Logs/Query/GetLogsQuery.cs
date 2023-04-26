using MediatR;

namespace SquidAdminPanel.Api.Core.Logs.Query;

public sealed record GetLogsQuery(string RecentLogs) : IRequest<LogsResponse>;
