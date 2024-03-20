using Microsoft.Extensions.DependencyInjection;
using TestFrameworkBoilerplate.Tests.WireMock.Setup;
using WireMock.Server;

namespace TestFrameworkBoilerplate.Tests.WireMock;

public static class Extensions
{
    public static IServiceCollection AddWireMock(this IServiceCollection services)
    {
        services.AddSingleton<WireMockServer>();
        services.AddSingleton<WireMockSetup>();

        return services;
    }
}