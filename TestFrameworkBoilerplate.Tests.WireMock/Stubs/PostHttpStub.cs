using Microsoft.AspNetCore.Http;
using TestFrameworkBoilerplate.Tests.WireMock.Constants;
using TestFrameworkBoilerplate.Tests.WireMock.Models;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace TestFrameworkBoilerplate.Tests.WireMock.Stubs;

public sealed class PostHttpStub
{
    private readonly WireMockServer _server;

    public PostHttpStub(WireMockServer server)
    {
        _server = server;
    }
    
    public void CreatePostEndpointExampleStub()
    {
        var postBody = new JsonPostModel
        {
            Type = "test1",
            Attributes = new JsonAttributes()
            {
                Title = "test title 1",
                Body = "test body 1"
            }
        };

        string jsonPath = "ExampleJsons\\PostExampleJson.json";
        string jsonString = File.ReadAllText(jsonPath);
        
        _server.Given(
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