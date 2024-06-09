using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces;
using FluentValidation;
using ConsoleApp;
using Domain.Request;

namespace LogConverter.ConsoleApp;

class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Erro: Você deve fornecer exatamente 2 argumentos: <sourceUrl> e <targetPath>.");
            return;
        }

        var sourceUrl = args[0];
        var targetPath = args[1];

        var serviceCollection = new ServiceCollection();
        ServiceRegistration.ConfigureServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var validator = serviceProvider.GetService<IValidator<LogConversionRequest>>();
        var request = new LogConversionRequest { SourceUrl = sourceUrl, TargetPath = targetPath };
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            foreach (var failure in validationResult.Errors)
            {
                Console.WriteLine($"Erro de validação: {failure.ErrorMessage}");
            }
            return;
        }

        var converter = serviceProvider.GetService<ILogConverter>();

        try
        {
            Console.WriteLine("Iniciando a conversão...");
            await converter.Convert(sourceUrl, targetPath);
            Console.WriteLine($"Log convertido salvo em: {targetPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro durante a conversão: {ex.Message}");
        }
    }
}
