﻿using RestSharp;

namespace TestFrameworkBoilerplate.Tests.Integration.Drivers;

public sealed class RestSharpDriver
{
    private RestClient _client;

    public RestSharpDriver(IRestClient client)
    {
        _client = new RestClient("http://localhost:1010");
    }

    public async Task<RestResponse> GetAsync(string endpoint)
    {
        var request = new RestRequest(endpoint, Method.Get);
        var response = await _client.ExecuteAsync(request);

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