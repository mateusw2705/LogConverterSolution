using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILogFormatter
    {
        string Format(List<LogEntry> logEntries);
    }
}
