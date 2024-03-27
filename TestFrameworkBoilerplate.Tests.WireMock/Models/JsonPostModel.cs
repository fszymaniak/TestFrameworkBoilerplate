namespace TestFrameworkBoilerplate.Tests.WireMock.Models;

public sealed class JsonPostModel
{
    public Guid Id { get; set; }
    
    public string Type { get; set; }
    
    public JsonAttributes Attributes { get; set; }
}