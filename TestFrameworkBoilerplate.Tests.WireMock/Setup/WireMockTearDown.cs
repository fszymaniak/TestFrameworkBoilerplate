using WireMock.Server;

namespace TestFrameworkBoilerplate.Tests.WireMock.Setup;

public class WireMockTearDown
{
    private readonly WireMockServer _server;

    public WireMockTearDown(WireMockServer server)
    {
        _server = server;
    }
    
    public void StopServer()
    {
        _server.Stop();
    }
}