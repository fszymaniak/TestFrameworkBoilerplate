namespace TestFrameworkBoilerplate.Tests.Integration.Drivers;

public sealed class RestSharpDriver
{
    private IRestClient _client;
    private WireMockDriver _wireMockDriver;

    public RestSharpDriver(IRestClient client, WireMockDriver wireMockDriver)
    {
        _wireMockDriver = wireMockDriver;
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
        string jsonString = File.ReadAllText("ExampleJsons\\PostExampleRequestJson.json");
        
        var request = new RestRequest(endpoint, Method.Post);
        request.AddHeader("Content-Type", "application/json");
        request.AddBody(jsonString);
        var response = await _client.ExecuteAsync(request);

        return response;
    }
}