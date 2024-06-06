namespace Domain.Interfaces;

public interface ILogWriter
{
    void WriteLog(string path, string content);
}
