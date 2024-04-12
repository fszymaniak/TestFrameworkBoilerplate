using Autofac;
using TechTalk.SpecFlow;
using TestFrameworkBoilerplate.Tests.WireMock.Setup;
using TestFrameworkBoilerplate.Tests.WireMock.Stubs;

namespace TestFrameworkBoilerplate.Tests.WireMock;

[Binding]
public static class Extensions
{
    public static ContainerBuilder AddWireMock(this ContainerBuilder builder)
    {
        builder.RegisterType<WireMockSetup>()
            .AsSelf()
            .AsImplementedInterfaces()
            .SingleInstance();
        
        return builder;
    }
}