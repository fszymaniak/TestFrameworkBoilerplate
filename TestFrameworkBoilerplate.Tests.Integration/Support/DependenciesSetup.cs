using System.Reflection;
using Autofac;
using SpecFlow.Autofac.SpecFlowPlugin;
using TestFrameworkBoilerplate.Tests.Integration.Hooks;
using TestFrameworkBoilerplate.Tests.Integration.Steps;
using TestFrameworkBoilerplate.Tests.WireMock;

namespace TestFrameworkBoilerplate.Tests.Integration.Support;

[Binding]
public static class DependenciesSetup
{
    [ScenarioDependencies]
    public static void CreateServices(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddWireMock();
        
        // Setup 
        containerBuilder.RegisterType<Setup>();
        
        // Drivers
        containerBuilder.RegisterType<WireMockDriver>();
        containerBuilder.RegisterType<RestClient>().As<IRestClient>(); 
        containerBuilder.RegisterType<RestSharpDriver>();
        
        // Steps
        containerBuilder.RegisterType<HttpExamplesSteps>();
    }
}
