using SquidAdminPanel.Api.Core.Interfaces;
using SquidAdminPanel.Api.Core.Models;
using SquidAdminPanel.Api.Data;
using System.Globalization;

namespace SquidAdminPanel.Api.Core.Helpers;

public sealed class LogReader : ILogReader
{
    private LogsContext _logsContext { get; set; }
    
    private Dictionary<string, string> _decodingStatusCodes = new()
    {
         { "TCP_TUNNEL", "Для этой транзакции был установлен бинарный туннель." },
         { "TCP_DENIED", "Запрос был отклонен системой контроля доступа." },
    };

    public LogReader(LogsContext logsContext) => _logsContext = logsContext;

    public async Task<LogsResponse> Read(string recentLogs)
    {
        var log = new LogsResponse();
        var recentLogsDate = Converter.SecondsToDateConverter(recentLogs);

        await _logsContext.QueryReadLineAsync(line =>
        {
            var currentTime = line.AsSpan().Slice(0, line.IndexOf(" ")).ToString();
            var currentLogsDate = Converter.SecondsToDateConverter(currentTime);

            if (currentLogsDate.Ticks > recentLogsDate.Ticks)
            {
                var splitLine = line.Split(' ').Where(c => c != "").ToArray();
                var splitMethodeAndCode = splitLine[3].Split('/');

                var createdLog = CreateLog(splitLine, currentLogsDate);
                if (createdLog is not null)
                {
                    log.Logs.Add(createdLog);
                }
            }
            log.RecentLogs = currentTime;
        });       

        return log;
    }

    private Log CreateLog(string[] splitLines, DateTime logDate)
    {
        var splitMethodeAndCode = splitLines[3].Split('/');
        var methodeMessage = _decodingStatusCodes.TryGetValue(splitMethodeAndCode[0], out var message);
        
        if (methodeMessage)
        {
            var logLine = new Log()
            {
                Time = $"{logDate.ToShortDateString()} {logDate.ToShortTimeString()}",
                Address = splitLines[2],
                StatusCode = splitLines[3],
                Description = message,
                User = splitLines[7],
                FromAddress = splitLines[6]
            };

            return logLine;
        }

        return null;
    }
}