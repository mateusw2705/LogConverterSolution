using Application.Validators;
using ConsoleApp.Config;
using ConsoleApp;

namespace LogConverter.ConsoleApp;

class Program
{
    static async Task Main(string[] args)
    {
        if (!ValidateArguments.ValidateArgument(args, out var request))
        {
            return;
        }

        var serviceProvider = ConfigureServices.SetupDependencyInjection();

        await ConvertLog.Convert(serviceProvider, request);
    }
}
