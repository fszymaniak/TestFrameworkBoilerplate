using Microsoft.Extensions.Options;
using TestFrameworkBoilerplate.Tests.Integration.Configuration;

namespace TestFrameworkBoilerplate.Tests.Integration.Drivers;

public sealed class RestSharpDriver
{
    private IRestClient _client;
    private WireMockDriver _wireMockDriver;
    private readonly IOptions<DirectoryPathSettings> _directoryPathSettings;

    public RestSharpDriver(IRestClient client, WireMockDriver wireMockDriver, IOptions<DirectoryPathSettings> directoryPathSettings)
    {
        _wireMockDriver = wireMockDriver;
        _directoryPathSettings = directoryPathSettings;
        _client = new RestClient(_wireMockDriver.GetUrl());
    }

    public async Task<RestResponse> GetAsync(string endpoint)
    {
        var request = new RestRequest(endpoint, Method.Get);
        var response = await _client.ExecuteAsync(request);

        var a = _wireMockDriver.GetUrl();
        return response;
    }
    
    public async Task<RestResponse> PostAsync(string endpoint)
    {
        string path = Path.Combine(_directoryPathSettings.Value.ExpectedExampleJsonDirectory, "PostExampleRequestJson.json");
        string jsonString = File.ReadAllText(path);
        
        var request = new RestRequest(endpoint, Method.Post);
        request.AddHeader("Content-Type", "application/json");
        request.AddBody(jsonString);
        var response = await _client.ExecuteAsync(request);

        return response;
    }
}