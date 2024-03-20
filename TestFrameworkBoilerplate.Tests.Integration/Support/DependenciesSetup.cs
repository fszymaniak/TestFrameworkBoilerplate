using RestSharp;
using TestFrameworkBoilerplate.Tests.Integration.Drivers;

namespace TestFrameworkBoilerplate.Tests.Integration.Support;

public static class DependenciesSetup
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();
        
        services.AddWireMock();
        
        // Drivers 
        services.AddSingleton<WireMockDriver>();
        services.AddSingleton<IRestClient, RestClient>();
        services.AddSingleton<RestSharpDriver>();
        
        return services;
    }
}
