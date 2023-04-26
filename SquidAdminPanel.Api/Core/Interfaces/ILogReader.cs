namespace SquidAdminPanel.Api.Core.Interfaces;

public interface ILogReader
{
    Task<LogsResponse> Read(string recentLogs);
}
