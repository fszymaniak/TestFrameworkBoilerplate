# TestFrameworkBoilerplate

![.NET 8.0](https://img.shields.io/badge/-.NET%208.0-darkviolet?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![SpecFlow](https://img.shields.io/badge/SpecFlow-blue.svg?style=for-the-badge&logo=specflow&logoColor=white)
![WireMock](https://img.shields.io/badge/WireMock-orange?style=for-the-badge&logo=wiremock&logoColor=white)
![RestSharp](https://img.shields.io/badge/RestSharp-darkgreen?style=for-the-badge&logo=restsharp&logoColor=white)
![Autofac](https://img.shields.io/badge/Autofac-lightgreen.svg?style=for-the-badge&logo=autofac&logoColor=white)

A comprehensive test framework boilerplate built with **SpecFlow BDD**, **WireMock HTTP mocking**, **Autofac DI**, and **RestSharp** for API testing. Get started with integration, contract, UI, and performance testing in minutes!

---

## 🚀 Quick Start

### Prerequisites
- **.NET 8.0 SDK** or later ([Download](https://dotnet.microsoft.com/download))
- IDE: **Visual Studio 2022**, **JetBrains Rider**, or **VS Code** with C# extension

### Running Tests

```bash
# Restore dependencies
dotnet restore

# Build the solution
dotnet build

# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --verbosity detailed

# Run tests with coverage
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

---

## 📁 Project Structure

```
TestFrameworkBoilerplate/
├── TestFrameworkBoilerplate.Tests.Integration/    # Main test project
│   ├── Features/                                  # SpecFlow .feature files (BDD scenarios)
│   ├── Steps/                                     # Step definitions (Given/When/Then)
│   ├── Drivers/                                   # Driver pattern implementations
│   │   ├── RestSharpDriver.cs                     # HTTP client abstraction
│   │   └── WireMockDriver.cs                      # WireMock server lifecycle
│   ├── Hooks/                                     # SpecFlow hooks (BeforeScenario/AfterScenario)
│   ├── Support/                                   # Dependency injection setup
│   ├── Configuration/                             # Strongly-typed settings
│   ├── Constants/                                 # Reusable constants
│   ├── Models/                                    # Data models
│   ├── Extensions/                                # Helper extensions
│   ├── ExampleJsons/                              # Test data fixtures
│   ├── appsettings.json                           # Configuration file
│   └── specflow.json                              # SpecFlow settings
│
└── TestFrameworkBoilerplate.Tests.WireMock/       # WireMock setup (reusable)
    ├── Setup/                                     # WireMock server initialization
    ├── Stubs/                                     # HTTP endpoint stubs
    ├── Constants/                                 # Endpoints, JSON paths
    ├── Models/                                    # Shared data models
    └── WiremockExampleJsons/                      # Mock response payloads
```

---

## 🎯 Key Features

### ✅ **SpecFlow BDD Integration**
- **Gherkin syntax** for readable, business-focused scenarios
- Automated living documentation generation
- NUnit test runner integration
- Per-scenario dependency injection with Autofac

### ✅ **WireMock HTTP Mocking**
- Isolated WireMock server per test scenario
- Fluent stub definition API using extension methods
- File-based response payloads for maintainability
- Automatic server lifecycle management (start/stop hooks)

### ✅ **Driver Pattern**
- Clean abstraction over RestSharp HTTP client
- Separation of test logic from implementation details
- Reusable drivers for different concerns
- Easy to extend for new protocols/tools

### ✅ **Dependency Injection**
- Autofac container with per-scenario scope
- Configuration binding using Options pattern
- Constructor injection throughout
- Clean, testable architecture

### ✅ **Configuration Management**
- Strongly-typed settings classes
- Environment-specific `appsettings.json` support
- Easy configuration updates without code changes

---

## 📝 Writing Your First Test

### 1. Create a Feature File

Create `Features/MyApi.feature`:

```gherkin
Feature: User Management API
  As an API consumer
  I want to manage users via REST endpoints
  So that I can perform CRUD operations

Scenario: Create a new user successfully
    Given I have a valid user payload
    When I POST to '/api/users'
    Then the response status code is 201
    And the response contains a user ID
```

### 2. Implement Step Definitions

Create `Steps/MyApiSteps.cs`:

```csharp
[Binding]
public class MyApiSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly RestSharpDriver _httpDriver;

    public MyApiSteps(ScenarioContext scenarioContext, RestSharpDriver httpDriver)
    {
        _scenarioContext = scenarioContext;
        _httpDriver = httpDriver;
    }

    [Given(@"I have a valid user payload")]
    public void GivenIHaveAValidUserPayload()
    {
        // Payload loaded from JSON file via RestSharpDriver
    }

    [When(@"I POST to '(.*)'")]
    public async Task WhenIPostTo(string endpoint)
    {
        var response = await _httpDriver.PostAsync(endpoint, "CreateUser");
        _scenarioContext.SetHttpResponse(response);
    }

    [Then(@"the response status code is (.*)")]
    public void ThenTheResponseStatusCodeIs(int expectedStatusCode)
    {
        var response = _scenarioContext.GetHttpResponse();
        response.StatusCode.ShouldBe((HttpStatusCode)expectedStatusCode);
    }
}
```

### 3. Create WireMock Stub

In `TestFrameworkBoilerplate.Tests.WireMock/Stubs/UserStubs.cs`:

```csharp
public static class UserStubs
{
    public static void CreateUserStub(this WireMockServer server)
    {
        server.Given(
            Request.Create()
                .WithPath("/api/users")
                .UsingPost()
        )
        .RespondWith(
            Response.Create()
                .WithStatusCode(StatusCodes.Status201Created)
                .WithHeader("Content-Type", "application/json")
                .WithBodyFromFile("WiremockExampleJsons\\CreateUserResponse.json")
        );
    }
}
```

### 4. Register Stub in Setup

Update `WireMockSetup.cs`:

```csharp
public void StartServer()
{
    _server = WireMockServer.Start();
    _server.CreateUserStub(); // Add your new stub
    // ... other stubs
}
```

---

## ⚙️ Configuration

### appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning"
    }
  },
  "DirectoryPathSettings": {
    "ExpectedExampleJsonDirectory": "TestData",
    "OutputDirectory": "TestResults"
  },
  "Settings": {
    "ApiBaseUrl": "http://localhost:9876",
    "Timeout": 30,
    "RetryAttempts": 3
  }
}
```

### Environment-Specific Configs

Create `appsettings.Development.json`, `appsettings.Staging.json`, etc. for environment-specific settings.

---

## 🧪 Testing Patterns

### Driver Pattern
The framework uses the **Driver Pattern** from SpecFlow best practices:
- **Drivers** abstract away implementation details (HTTP, UI, database)
- **Steps** focus on business logic and readability
- **Hooks** manage lifecycle (setup/teardown)

### Dependency Injection
All dependencies are injected via constructor:
```csharp
public class MySteps
{
    private readonly IRestSharpDriver _driver;
    private readonly IOptions<Settings> _settings;

    public MySteps(IRestSharpDriver driver, IOptions<Settings> settings)
    {
        _driver = driver;
        _settings = settings;
    }
}
```

### Test Data Management
- Store request/response JSON in `TestData/` or `ExampleJsons/`
- Reference by filename in step definitions
- Use JSON Schema validation for complex payloads

---

## 📦 NuGet Packages Used

| Package | Purpose |
|---------|---------|
| **SpecFlow** | BDD framework for Gherkin scenarios |
| **SpecFlow.Autofac** | Dependency injection integration |
| **SpecFlow.NUnit** | NUnit test runner adapter |
| **WireMock.Net** | HTTP mocking server |
| **RestSharp** | HTTP client library |
| **Autofac** | IoC container |
| **Shouldly** | Fluent assertion library |
| **Coverlet** | Code coverage collector |

---

## 🔧 Extending the Framework

### Adding New Drivers
1. Create interface in `Drivers/I{Name}Driver.cs`
2. Implement driver class
3. Register in `Support/DependenciesSetup.cs`
4. Inject into step definitions

### Adding Custom Assertions
Create extension methods in `Extensions/`:
```csharp
public static class ResponseExtensions
{
    public static void ShouldHaveHeader(this RestResponse response, string header)
    {
        response.Headers
            .ShouldContain(h => h.Name == header,
                $"Response should contain header '{header}'");
    }
}
```

### Database Testing
Add a database driver for entity operations:
```csharp
public class DatabaseDriver
{
    private readonly DbContext _context;

    public async Task SeedData(params Entity[] entities) { }
    public async Task CleanupData() { }
}
```

---

## 📚 Documentation & Resources

### SpecFlow
- [SpecFlow Documentation](https://docs.specflow.org/)
- [Driver Pattern Guide](https://docs.specflow.org/projects/specflow/en/latest/Guides/DriverPattern.html)
- [Autofac Integration](https://docs.specflow.org/projects/specflow/en/latest/Integrations/Autofac.html)

### WireMock
- [WireMock.Net GitHub](https://github.com/WireMock-Net/WireMock.Net)
- [Request Matching](https://github.com/WireMock-Net/WireMock.Net/wiki/Request-Matching)
- [Response Templating](https://github.com/WireMock-Net/WireMock.Net/wiki/Response-Templating)

### RestSharp
- [RestSharp Documentation](https://restsharp.dev/)
- [Getting Started Guide](https://restsharp.dev/intro#getting-started)

### Autofac
- [Autofac Documentation](https://autofac.readthedocs.io/)
- [Registration Concepts](https://autofac.readthedocs.io/en/latest/register/registration.html)

---

## 🤝 Contributing

Contributions are welcome! Please:
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

---

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

---

## 🐛 Issues & Support

If you encounter any issues or have questions:
- Check existing [Issues](https://github.com/fszymaniak/TestFrameworkBoilerplate/issues)
- Open a new issue with detailed description
- Include logs, stack traces, and reproduction steps

---

## 🎓 Learning Path

1. **Start with Examples** - Run existing `HttpExamples.feature` scenarios
2. **Understand Structure** - Explore Drivers, Steps, and Hooks
3. **Write Simple Test** - Create a basic GET request scenario
4. **Add WireMock Stub** - Mock your own endpoint
5. **Extend Framework** - Add custom drivers and helpers
6. **Integrate with CI/CD** - Use GitHub Actions or Azure Pipelines

---

## ⭐ Acknowledgments

Built with best practices from:
- [SpecFlow Driver Pattern](https://docs.specflow.org/projects/specflow/en/latest/Guides/DriverPattern.html)
- [100 Commitów Challenge](https://100commitow.pl)
- Clean Architecture principles
- Domain-Driven Design patterns

---

**Happy Testing! 🚀**
