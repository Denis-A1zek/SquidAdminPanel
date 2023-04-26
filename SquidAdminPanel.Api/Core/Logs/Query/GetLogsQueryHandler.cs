using MediatR;
using SquidAdminPanel.Api.Core.Interfaces;
using SquidAdminPanel.Api.Core.Models;
using System.Globalization;

namespace SquidAdminPanel.Api.Core.Logs.Query;

public class GetLogsQueryHandler : IRequestHandler<GetLogsQuery, LogsResponse>
{
    private readonly ILogReader _logReader;
    
    public GetLogsQueryHandler(ILogReader logReader)
        => _logReader = logReader;
    
    public async Task<LogsResponse> Handle(GetLogsQuery request, CancellationToken cancellationToken)
        => await _logReader.Read(request.RecentLogs);
}
