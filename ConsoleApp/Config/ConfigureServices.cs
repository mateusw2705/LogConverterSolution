using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp.Config;

public class ConfigureServices
{
    public static ServiceProvider SetupDependencyInjection()
    {
        var serviceCollection = new ServiceCollection();
        ServiceRegistration.ConfigureServices(serviceCollection);
        return serviceCollection.BuildServiceProvider();
    }

}
