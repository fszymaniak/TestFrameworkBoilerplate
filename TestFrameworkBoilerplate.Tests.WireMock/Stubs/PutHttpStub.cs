using Microsoft.AspNetCore.Http;
using TestFrameworkBoilerplate.Tests.WireMock.Constants;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace TestFrameworkBoilerplate.Tests.WireMock.Stubs;

public static class PutHttpStub
{
    public static void CreatePutEndpointExampleStub(this WireMockServer server)
    {
        server.Given(
                Request.Create().WithPath(Endpoints.PutEndpointExample)
                    .UsingPut()
            )
            .RespondWith(
                Response.Create()
                    .WithStatusCode(StatusCodes.Status201Created)
                    .WithHeader(ResponseConstants.Header.ContentType, ResponseConstants.Header.ApplicationType)
                    .WithBodyFromFile(JsonPaths.PutJsonPath)
            );
    }
}