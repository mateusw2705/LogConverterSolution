using Application.Validators;
using Domain.Interfaces;
using Domain.Request;
using Infrastructure.Fetchers;
using Infrastructure.Parsers;
using Infrastructure.Writers;
using LogConverter.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace ConsoleApp;

public static class ServiceRegistration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ILogFetcher, HttpLogFetcher>();
        services.AddTransient<ILogParser, MinhaCdnLogParser>();
        services.AddTransient<ILogFormatter, AgoraLogFormatter>();
        services.AddTransient<ILogWriter, FileLogWriter>();
        services.AddTransient<ILogConverter, LogConversionService>();
        services.AddTransient<IValidator<LogConversionRequest>, LogConversionRequestValidator>();
    }
}
