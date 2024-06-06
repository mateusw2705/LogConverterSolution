using Domain.Entities;

namespace Domain.Interfaces;

public interface ILogParser
{
    List<LogEntry> Parse(string[] logLines);
}
