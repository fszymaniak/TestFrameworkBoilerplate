using WireMock.Server;

namespace TestFrameworkBoilerplate.Tests.WireMock.Setup;

public class WireMockSetup
{
    private WireMockServer _server;

    public WireMockSetup(WireMockServer server)
    {
        this._server = server;
    }

    public void StartServer()
    {
        _server = WireMockServer.Start(1010);
    }
}