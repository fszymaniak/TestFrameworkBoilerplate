﻿using Microsoft.AspNetCore.Http;
using RestSharp;
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
    
    [Then(@"the result should be '(.*)'")]
    public void ThenTheResultShouldBe(string expectedString)
    {
        var response = _scenarioContext.GetHttpResponse();
        response.StatusCode.Equals(StatusCodes.Status200OK);
        response.Content.Equals(expectedString);
    }

    private static Task<RestResponse> SelectRequest(string request, RestSharpDriver restSharpDriver, string endpoint) => request switch
    {
        "GET" => restSharpDriver.GetAsync(endpoint),
        _ => throw new ArgumentOutOfRangeException(nameof(request), $"Not expected http request: {request}")
    };

   
}