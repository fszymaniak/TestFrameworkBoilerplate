using Microsoft.Extensions.Options;
using TestFrameworkBoilerplate.Tests.Integration.Configuration;
using TestFrameworkBoilerplate.Tests.Integration.Constants;

namespace TestFrameworkBoilerplate.Tests.Integration.Drivers;

public sealed class RestSharpDriver
{
    private readonly IRestClient _client;
    private readonly WireMockDriver _wireMockDriver;
    private readonly IOptions<DirectoryPathSettings> _directoryPathSettings;

    public RestSharpDriver(IRestClient client, WireMockDriver wireMockDriver,
        IOptions<DirectoryPathSettings> directoryPathSettings)
    {
        _wireMockDriver = wireMockDriver;
        _directoryPathSettings = directoryPathSettings;
        _client = new RestClient(_wireMockDriver.GetUrl());
    }

    public async Task<RestResponse> GetAsync(string endpoint)
    {
        var request = new RestRequest(endpoint);
        var response = await _client.ExecuteAsync(request);
        return response;
    }

    public async Task<RestResponse> PostAsync(string endpoint, string requestMethod)
    {
        var jsonString = GetJsonRequest(requestMethod);
        var request = new RestRequest(endpoint, Method.Post);
        request.AddHeader(ResponseConstants.Header.ContentType, ResponseConstants.Header.ApplicationType);
        request.AddBody(jsonString);
        var response = await _client.ExecuteAsync(request);

        return response;
    }

    public async Task<RestResponse> PutAsync(string endpoint, string requestMethod)
    {
        var jsonString = GetJsonRequest(requestMethod);
        var request = new RestRequest(endpoint, Method.Put);
        request.AddHeader(ResponseConstants.Header.ContentType, ResponseConstants.Header.ApplicationType);
        request.AddBody(jsonString);
        var response = await _client.ExecuteAsync(request);

        return response;
    }

    private string GetJsonRequest(string requestMethod)
    {
        var jsonFile = GetJsonFile(requestMethod);
        var path = Path.Combine(_directoryPathSettings.Value.ExpectedExampleJsonDirectory, jsonFile);
        var jsonString = File.ReadAllText(path);
        return jsonString;
    }

    private string GetJsonFile(string requestMethod) => requestMethod switch
    {
        "POST" => JsonRequestFilePaths.PostJsonRequestPath,
        "PUT" => JsonRequestFilePaths.PutJsonRequestPath,
        _ => throw new ArgumentOutOfRangeException(nameof(requestMethod), $"Not expected http request: {requestMethod}")
    };
}