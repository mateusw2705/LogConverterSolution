using Domain.Interfaces;
using Infrastructure.Fetchers;
using Infrastructure.Parsers;
using Infrastructure.Writers;
using LogConverter.Application.Services;

namespace ConsoleApp;

public class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: convert <sourceUrl> <targetPath>");
            return;
        }

        string sourceUrl = args[0];
        string targetPath = args[1];

        ILogFetcher fetcher = new HttpLogFetcher();
        ILogParser parser = new MinhaCdnLogParser();
        ILogFormatter formatter = new AgoraLogFormatter();
        ILogWriter writer = new FileLogWriter();

        var converter = new LogConversionService(fetcher, parser, formatter, writer);
        await Task.Run(() => converter.Convert(sourceUrl, targetPath));

        Console.WriteLine($"Log convertido salvo em: {targetPath}");
    }
}


