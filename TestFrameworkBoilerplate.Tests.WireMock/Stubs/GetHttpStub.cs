using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace TestFrameworkBoilerplate.Tests.WireMock.Stubs;

public class GetHttpStub
{
    private readonly WireMockServer _server;

    public GetHttpStub(WireMockServer server)
    {
        _server = server;
    }

    public void CreateGetEndpointExampleStub()
    {
        _server.Given(
                Request.Create().WithPath("/getEndpointExample").UsingGet()
            )
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithHeader("Content-Type", "text/plain")
                    .WithBody("getEndpointExample working fine!")
            );
    }
}