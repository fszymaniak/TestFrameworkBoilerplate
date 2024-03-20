using TestFrameworkBoilerplate.Tests.Integration.Drivers;
using WireMock.Server;

namespace TestFrameworkBoilerplate.Tests.Integration.Hooks;

[Binding]
public sealed class Setup
{
    private readonly WireMockDriver _wireMockDriver;

    public Setup(WireMockDriver wireMockDriver)
    {
        _wireMockDriver = wireMockDriver;
    }

    [BeforeScenario]
    public void WireMockStart()
    {
        _wireMockDriver.WireMockStartServer();
    }
    
    [AfterScenario]
    public void WireMockEnd()
    {
        _wireMockDriver.WireMockEndServer();
    }
}