using SquidAdminPanel.Api.Core.Models;
using System.Text.Json;

namespace SquidAdminPanel.Api.Core;
public sealed class LogsResponse
{
    public string RecentLogs { get; set; }
    public List<Log> Logs { get; set; } = new();
}

