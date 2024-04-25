using Microsoft.Extensions.Options;
using TestFrameworkBoilerplate.Tests.Integration.Configuration;

namespace TestFrameworkBoilerplate.Tests.Integration.Steps;

[Binding]
public class HttpExamplesSteps
{
    private readonly RestSharpDriver _restSharpDriver;
    private readonly ScenarioContext _scenarioContext;
    private readonly IOptions<DirectoryPathSettings> _directoryPathSettings;

    public HttpExamplesSteps(RestSharpDriver restSharpDriver, ScenarioContext scenarioContext, IOptions<DirectoryPathSettings> directoryPathSettings)
    {
        _restSharpDriver = restSharpDriver;
        _scenarioContext = scenarioContext;
        _directoryPathSettings = directoryPathSettings;
    }

    [Given(@"the HTTP '(.*)' to the endpoint '(.*)' is being send")]
    public async Task GivenTheHttpToTheEndpointIsBeingSend(string request, string endpoint)
    {
        var response = await SelectRequest(request, _restSharpDriver, endpoint);
        _scenarioContext.SetHttpResponse(response);
    }
    
    [Then(@"the result match expected json '(.*)' and status code '(.*)'")]
    public void ThenTheResultShouldBe(string expectedJsonName, string statusCode)
    {
        var response = _scenarioContext.GetHttpResponse();
        response.StatusCode.Equals(Int32.Parse(statusCode));

        string path = Path.Combine(_directoryPathSettings.Value.ExpectedExampleJsonDirectory, expectedJsonName);
        
        string jsonString = File.ReadAllText(path);
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
        "POST" => restSharpDriver.PostAsync(endpoint, request),
        "PUT" => restSharpDriver.PutAsync(endpoint, request),
        _ => throw new ArgumentOutOfRangeException(nameof(request), $"Not expected http request: {request}")
    };
}