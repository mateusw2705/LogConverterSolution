using Domain.Interfaces;
using Domain.Request;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp;

public class ConvertLog
{
    public static async Task Convert(IServiceProvider serviceProvider, LogConversionRequest request)
    {
        var validator = serviceProvider.GetService<IValidator<LogConversionRequest>>();
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
            await converter!.Convert(request.SourceUrl, request.TargetPath);
            Console.WriteLine($"Log convertido salvo em: {request.TargetPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro durante a conversão: {ex.Message}");
        }
    }
}
