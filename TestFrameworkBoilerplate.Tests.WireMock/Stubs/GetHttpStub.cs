using Microsoft.AspNetCore.Http;
using TestFrameworkBoilerplate.Tests.WireMock.Constants;
using WireMock.RequestBuilders;
using WireMock.Server;
using Response = WireMock.ResponseBuilders.Response;

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
                Request.Create().WithPath(Endpoints.GetEndpointExample).UsingGet()
            )
            .RespondWith(
                Response.Create()
                    .WithStatusCode(StatusCodes.Status200OK)
                    .WithHeader(ResponseConstants.Header.ContentType, ResponseConstants.Header.ApplicationType)
                    .WithBody("getEndpointExample working fine!")
                    .WithBodyFromFile("ExampleJsons\\GetExampleJson.json")
            );
    }
}