using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Parsers;

public class MinhaCdnLogParser : ILogParser
{
    public List<LogEntry> Parse(string[] logLines)
    {
        var logEntries = new List<LogEntry>();
        foreach (var line in logLines)
        {
            var parts = line.Split('|');
            var logEntry = new LogEntry
            {
                ResponseSize = int.Parse(parts[0]),
                StatusCode = int.Parse(parts[1]),
                CacheStatus = parts[2] == "INVALIDATE" ? "REFRESH_HIT" : parts[2],
                HttpMethod = parts[3].Split(' ')[0].Replace("\"", ""),
                UriPath = parts[3].Split(' ')[1],
                TimeTaken = double.Parse(parts[4])
            };
            logEntries.Add(logEntry);
        }
        return logEntries;
    }
}

