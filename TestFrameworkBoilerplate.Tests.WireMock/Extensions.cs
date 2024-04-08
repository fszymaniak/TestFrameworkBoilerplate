using Autofac;
using Autofac.Core;
using SpecFlow.Autofac;
using SpecFlow.Autofac.SpecFlowPlugin;
using TechTalk.SpecFlow;
using TestFrameworkBoilerplate.Tests.WireMock.Setup;
using WireMock.Server;

namespace TestFrameworkBoilerplate.Tests.WireMock;

[Binding]
public static class Extensions
{
    public static ContainerBuilder AddWireMock(this ContainerBuilder builder)
    {
        builder.RegisterType<WireMockServer>();
        
        builder.RegisterType<WireMockSetup>()
            .AsSelf()
            .AsImplementedInterfaces()
            .SingleInstance();
        
        return builder;
    }
}