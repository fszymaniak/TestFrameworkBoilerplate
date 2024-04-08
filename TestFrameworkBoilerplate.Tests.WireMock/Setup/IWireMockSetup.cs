namespace TestFrameworkBoilerplate.Tests.WireMock.Setup;

public interface IWireMockSetup
{
    public void StartServer();

    public void StopServer();
}