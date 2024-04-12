using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HandlebarsDotNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TestFrameworkBoilerplate.Tests.Integration.Configuration;
using TestFrameworkBoilerplate.Tests.Integration.Hooks;
using TestFrameworkBoilerplate.Tests.Integration.Steps;
using TestFrameworkBoilerplate.Tests.WireMock;
using WireMock.Server;

namespace TestFrameworkBoilerplate.Tests.Integration.Support;

[Binding]
public static class DependenciesSetup
{
    [ScenarioDependencies]
    public static void CreateServices(ContainerBuilder containerBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        containerBuilder.RegisterInstance<IConfiguration>(configuration);
        
        containerBuilder.AddWireMock();

        // Setup 
        containerBuilder.RegisterType<Setup>();
        
        // Drivers
        containerBuilder.RegisterType<WireMockDriver>();
        containerBuilder.RegisterType<RestClient>().As<IRestClient>();
        containerBuilder.RegisterType<RestSharpDriver>();

        // Options
        var settings = new Settings();
        var directoryPathSettings = new DirectoryPathSettings();

        configuration.GetSection(nameof(Settings)).Bind(settings);
        configuration.GetSection(nameof(DirectoryPathSettings)).Bind(directoryPathSettings);

        var services = new ServiceCollection();
        
        services
            .AddOptions<Settings>()
            .Configure<IConfiguration>((settings, c) => c.GetSection(nameof(Settings)).Bind(settings));
        
        services
            .AddOptions<DirectoryPathSettings>()
            .Configure<IConfiguration>((settings, c) => c.GetSection(nameof(DirectoryPathSettings)).Bind(settings));
        

        containerBuilder.Register(c => c.Resolve<IOptions<Settings>>().Value).AsImplementedInterfaces()
            .SingleInstance();
        containerBuilder.Register(c => c.Resolve<IOptions<DirectoryPathSettings>>().Value).AsImplementedInterfaces()
            .SingleInstance();
        
        // Steps
        containerBuilder.RegisterType<HttpExamplesSteps>().AsSelf();
        
        containerBuilder.Populate(services);
    }
}
