namespace Domain.Interfaces;

public interface ILogConverter
{
    Task Convert(string sourceUrl, string targetPath);
}
