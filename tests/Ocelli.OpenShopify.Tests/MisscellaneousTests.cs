using System;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Text;
using RichardSzalay.MockHttp;

namespace Ocelli.OpenShopify.Tests;

public class MiscellaneousFixture : SharedFixture, IAsyncLifetime
{
    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}
public class MiscellaneousTests : IClassFixture<MiscellaneousFixture>
{
    private readonly HttpClient _mockClient;
    private readonly ITestOutputHelper _testOutputHelper;


    public MiscellaneousTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper; 
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("*").Respond(HttpStatusCode.OK);
        _mockClient = mockHttp.ToHttpClient();
    }
    
    [Fact]
    public void AdditionalProperties_CanUpdate()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => a.FullName != null && a.FullName.StartsWith("Ocelli.OpenShopify") && !a.FullName.Contains("Test"));
        foreach (var assembly in assemblies)
        {
            foreach (var type in assembly.GetTypes())
            {
                var properties = type.GetProperties().Where(p => p.Name == nameof(AccessScope.AdditionalProperties));
                foreach (var property in properties)
                {
                    _testOutputHelper.WriteLine($@"{type.Name}.{property.Name}");
                    var c = Activator.CreateInstance(type);
                    c?.GetType().GetProperty(property.Name)?.SetValue(c, null, null);
                }
            }
        }
    }

    [Fact]
    public void ConvertToString_Works()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => a.FullName != null && a.FullName.StartsWith("Ocelli.OpenShopify") && !a.FullName.Contains("Test"));
        foreach (var assembly in assemblies)
        {
            foreach (var type in assembly.GetTypes().Where(t => t.IsClass && t.BaseType == typeof(ShopifyClientBase)))
            {
                var client = Activator.CreateInstance(type, _mockClient);
                var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
                var method = methods.FirstOrDefault(x => x.Name == "ConvertToString");

                if (method == null) continue;

                //Act
                var baValue = Encoding.ASCII.GetBytes("Sample");
                var oValue = new {Name = "Sample" };
                var oaValue = new[] { oValue };
                _ = method.Invoke(client, new object?[] { null, CultureInfo.InvariantCulture })!;
                _ = method.Invoke(client, new object[] { "string", CultureInfo.InvariantCulture })!;
                _ = method.Invoke(client, new object[] { true, CultureInfo.InvariantCulture })!;
                _ = method.Invoke(client, new object[] { baValue, CultureInfo.InvariantCulture })!;
                _ = method.Invoke(client, new object[] { oaValue, CultureInfo.InvariantCulture })!;
                _ = method.Invoke(client, new object[] { ApplicationChargeStatus.Accepted, CultureInfo.InvariantCulture })!;
            }
        }
    }
}
