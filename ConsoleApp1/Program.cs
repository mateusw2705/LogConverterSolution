using Microsoft.Extensions.DependencyInjection;
using LogConverter.Application.Services;
using Domain.Interfaces;
using Infrastructure.Fetchers;
using Infrastructure.Parsers;
using Infrastructure.Writers;

namespace LogConverter.ConsoleApp;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<ILogFetcher, HttpLogFetcher>()
            .AddTransient<ILogParser, MinhaCdnLogParser>()
            .AddTransient<ILogFormatter, AgoraLogFormatter>()
            .AddTransient<ILogWriter, FileLogWriter>()
            .AddTransient<ILogConverter, LogConversionService>()
            .BuildServiceProvider();

        var converter = serviceProvider.GetService<ILogConverter>();

        string sourceUrl = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt"; // Exemplo de URL de teste

        // Definir o caminho de destino na pasta "Documentos" do usuário
        string targetDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ConvertedLogs");
        Directory.CreateDirectory(targetDirectory); // Cria o diretório se não existir
        string targetPath = Path.Combine(targetDirectory, "teste.txt");

        try
        {
            Console.WriteLine("Starting conversion...");
            await converter.Convert(sourceUrl, targetPath);
            Console.WriteLine($"Log convertido salvo em: {targetPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during conversion: {ex.Message}");
        }
    }
}
