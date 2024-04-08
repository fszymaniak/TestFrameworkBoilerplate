using TestFrameworkBoilerplate.Tests.WireMock.Stubs;
using WireMock.Server;

namespace TestFrameworkBoilerplate.Tests.WireMock.Setup;

public class WireMockSetup : IWireMockSetup
{
    private WireMockServer _server;
    // private GetHttpStub _getHttpStub;
    // private PostHttpStub _postHttpStub;
    //
    // public WireMockSetup()
    // {
    //     _getHttpStub = new GetHttpStub(_server);
    //     _postHttpStub = new PostHttpStub(_server);
    //
    // }

    public void StartServer()
    {
        _server = WireMockServer.Start(1010);
        
        var getHttpStub = new GetHttpStub(_server);
        getHttpStub.CreateGetEndpointExampleStub();
        getHttpStub.CreateGetSingleObjectEndpointExampleStub();
        
        var postHttpStub = new PostHttpStub(_server);
        postHttpStub.CreatePostEndpointExampleStub();
    }
    
    public void StopServer()
    {
        _server.Stop();
    }
}