namespace Domain.Interfaces;

public interface ILogFetcher
{
    Task<string[]> FetchLogAsync(string url);
}
