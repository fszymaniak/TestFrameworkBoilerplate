using Microsoft.AspNetCore.Http;
using TestFrameworkBoilerplate.Tests.WireMock.Constants;
using WireMock.RequestBuilders;
using WireMock.Server;
using Response = WireMock.ResponseBuilders.Response;

namespace TestFrameworkBoilerplate.Tests.WireMock.Stubs;

public static class GetHttpStub
{
    public static void CreateGetEndpointExampleStub(this WireMockServer server)
    {
        server.Given(
                Request.Create().WithPath(Endpoints.GetEndpointExample).UsingGet()
            )
            .RespondWith(
                Response.Create()
                    .WithStatusCode(StatusCodes.Status200OK)
                    .WithHeader(ResponseConstants.Header.ContentType, ResponseConstants.Header.ApplicationType)
                    .WithBodyFromFile(JsonPaths.GetAllJsonPath)
            );
    }
    
    public static void CreateGetSingleObjectEndpointExampleStub(this WireMockServer server)
    {
        server.Given(
                Request.Create().WithPath(Endpoints.GetSingleObjectEndpointExample).UsingGet()
            )
            .RespondWith(
                Response.Create()
                    .WithStatusCode(StatusCodes.Status200OK)
                    .WithHeader(ResponseConstants.Header.ContentType, ResponseConstants.Header.ApplicationType)
                    .WithBodyFromFile(JsonPaths.GetSingleJsonPath)
            );
    }
}