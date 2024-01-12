using Microsoft.Extensions.Configuration;
using NotificationMicroservice.API.Factories;

namespace NotificationMicroserviceUnitTests.FactoriesTests;
public sealed class ConnectionStringFactoryTests
{
    [Fact]
    public void GetConnectionString_ReturnsContainerConnection()
    {
        // A
        const string containerConnection = "test";
        var inMemoryCollection = new Dictionary<string, string>()
        {
            {"ConnectionStrings:ContainerConnection", containerConnection }
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemoryCollection!)
            .Build();

        Environment.SetEnvironmentVariable("DOCKER_ENVIROMENT", "DEV_DOCKER_NOTIFICATION");

        // A
        var connectionStringResult = configuration.GetConnectionString();

        // A
        Assert.Equal(containerConnection, connectionStringResult);
    }

    [Fact]
    public void GetConnectionString_ReturnsLocalConnection()
    {
        // A
        const string localConnection = "joao";
        var inMemoryCollection = new Dictionary<string, string>()
        {
            {"ConnectionStrings:LocalConnection", localConnection}
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemoryCollection!)
            .Build();

        Environment.SetEnvironmentVariable("DOCKER_ENVIROMENT", "any value");

        // A
        var connectionStringResult = configuration.GetConnectionString();

        // A
        Assert.Equal(localConnection, connectionStringResult);
    }
}
