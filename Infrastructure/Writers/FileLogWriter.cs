using Domain.Interfaces;

namespace Infrastructure.Writers;

public class FileLogWriter : ILogWriter
{
    public void WriteLog(string path, string content)
    {
        File.WriteAllText(path, content);
    }
}
