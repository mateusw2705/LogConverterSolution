using Domain.Entities;
using Domain.Interfaces;
using System.Text;

namespace Infrastructure.Parsers;

public class AgoraLogFormatter : ILogFormatter
{
    public string Format(List<LogEntry> logEntries)
    {
        var builder = new StringBuilder();
        builder.AppendLine("#Version: 1.0");
        builder.AppendLine($"#Date: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
        builder.AppendLine("#Fields: provider http-method status-code uri-path time-taken response-size cache-status");
        builder.AppendLine();

        foreach (var entry in logEntries)
        {
            builder.AppendLine($"\"MINHA CDN\" {entry.HttpMethod} {entry.StatusCode} {entry.UriPath} {Math.Round(entry.TimeTaken)} {entry.ResponseSize} {entry.CacheStatus}");
        }
        return builder.ToString();
    }
}

