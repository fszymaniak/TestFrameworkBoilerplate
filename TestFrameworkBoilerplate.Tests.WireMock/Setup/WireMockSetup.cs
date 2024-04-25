using TestFrameworkBoilerplate.Tests.WireMock.Stubs;
using WireMock.Server;

namespace TestFrameworkBoilerplate.Tests.WireMock.Setup;

public class WireMockSetup : IWireMockSetup
{
    private WireMockServer _server;

    public void StartServer()
    {
        _server = WireMockServer.Start();
        
        _server.CreateGetEndpointExampleStub();
        _server.CreateGetSingleObjectEndpointExampleStub();
        _server.CreatePostEndpointExampleStub();
        _server.CreatePutEndpointExampleStub();
    }
    
    public void StopServer()
    {
        _server.Stop();
    }

    public string GetWireMockUrl()
    {
        return _server.Urls[0];
    }
}