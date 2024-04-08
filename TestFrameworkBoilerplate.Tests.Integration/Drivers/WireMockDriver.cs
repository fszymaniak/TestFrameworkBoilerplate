namespace TestFrameworkBoilerplate.Tests.Integration.Drivers;

public sealed class WireMockDriver
{
    private readonly WireMockSetup _wireMockSetup;

    public WireMockDriver(WireMockSetup wireMockSetup)
    {
        this._wireMockSetup = wireMockSetup;
    }

    public void WireMockStartServer() => _wireMockSetup.StartServer();
    
    public void WireMockEndServer() => _wireMockSetup.StopServer();

    public string GetUrl() => _wireMockSetup.GetWireMockUrl();
}