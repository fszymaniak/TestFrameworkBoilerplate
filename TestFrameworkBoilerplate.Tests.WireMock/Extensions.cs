using Microsoft.Extensions.DependencyInjection;
using WireMock.Server;

namespace TestFrameworkBoilerplate.Tests.WireMock;

public static class Extensions
{
    public static IServiceCollection AddWireMock(this IServiceCollection services)
    {
        services.AddScoped<WireMockServer>();

        return services;
    }
}