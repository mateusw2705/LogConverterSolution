using Domain.Interfaces;

namespace Infrastructure.Fetchers;

public class HttpLogFetcher : ILogFetcher
{
    public async Task<string[]> FetchLogAsync(string url)
    {
        try
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            var logLines = responseBody.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return logLines;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            throw;
        }
    }
}

