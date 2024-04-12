using Microsoft.AspNetCore.Http;
using TestFrameworkBoilerplate.Tests.WireMock.Constants;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace TestFrameworkBoilerplate.Tests.WireMock.Stubs;

public static class PostHttpStub
{
    public static void CreatePostEndpointExampleStub(this WireMockServer server)
    {
        string jsonPath = "WiremockExampleJsons\\PostExampleJson.json";
        
        server.Given(
                Request.Create().WithPath(Endpoints.PostEndpointExample)
                    .UsingPost()
            )
            .RespondWith(
                Response.Create()
                    .WithStatusCode(StatusCodes.Status201Created)
                    .WithHeader(ResponseConstants.Header.ContentType, ResponseConstants.Header.ApplicationType)
                    .WithBodyFromFile(jsonPath)
            );
    }
}