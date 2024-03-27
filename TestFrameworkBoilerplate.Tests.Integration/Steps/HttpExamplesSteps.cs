using Microsoft.AspNetCore.Http;
using RestSharp;
using Shouldly;
using TestFrameworkBoilerplate.Tests.Integration.Drivers;
using TestFrameworkBoilerplate.Tests.Integration.Extensions;

namespace TestFrameworkBoilerplate.Tests.Integration.Steps;

[Binding]
public class HttpExamplesSteps
{
    private readonly RestSharpDriver _restSharpDriver;
    private readonly ScenarioContext _scenarioContext;

    public HttpExamplesSteps(RestSharpDriver restSharpDriver, ScenarioContext scenarioContext)
    {
        _restSharpDriver = restSharpDriver;
        _scenarioContext = scenarioContext;
    }

    [Given(@"the HTTP '(.*)' to the endpoint '(.*)' is being send")]
    public async Task GivenTheHttpToTheEndpointIsBeingSend(string request, string endpoint)
    {
        var response = await SelectRequest(request, _restSharpDriver, endpoint);
        _scenarioContext.SetHttpResponse(response);
    }
    
    [Then(@"the result match expected json '(.*)' and status code '(.*)'")]
    public void ThenTheResultShouldBe(string expectedJsonPath, string statusCode)
    {
        var response = _scenarioContext.GetHttpResponse();
        response.StatusCode.Equals(Int32.Parse(statusCode));
        
        string jsonString = File.ReadAllText(expectedJsonPath);
        response.Content.ShouldBe(jsonString);
    }
    
    [Then(@"the result is created")]
    public void ThenTheResultShouldBe()
    {
        var response = _scenarioContext.GetHttpResponse();
        response.StatusCode.Equals(StatusCodes.Status201Created);
    }

    private static Task<RestResponse> SelectRequest(string request, RestSharpDriver restSharpDriver, string endpoint) => request switch
    {
        "GET" => restSharpDriver.GetAsync(endpoint),
        "POST" => restSharpDriver.PostAsync(endpoint),
        _ => throw new ArgumentOutOfRangeException(nameof(request), $"Not expected http request: {request}")
    };
}