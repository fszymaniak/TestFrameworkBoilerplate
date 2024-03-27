#nullable enable
using RestSharp;

namespace TestFrameworkBoilerplate.Tests.Integration.Extensions;

public static class ScenarioContextExtensions
{
    public static void SetHttpResponse(this ScenarioContext context, RestResponse? response) => context[nameof (response)] = (object) response!;
    
    public static RestResponse GetHttpResponse(this ScenarioContext context) => context.Get<RestResponse>("response");
}