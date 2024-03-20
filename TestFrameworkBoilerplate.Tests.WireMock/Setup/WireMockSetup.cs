using TestFrameworkBoilerplate.Tests.WireMock.Stubs;
using WireMock.Server;

namespace TestFrameworkBoilerplate.Tests.WireMock.Setup;

public class WireMockSetup
{
    private WireMockServer _server;

    public void StartServer()
    {
        _server = WireMockServer.Start(1010);
        var getHttpStub = new GetHttpStub(_server);
        getHttpStub.CreateGetEndpointExampleStub();
    }
    
    public void StopServer()
    {
        _server.Stop();
    }
}