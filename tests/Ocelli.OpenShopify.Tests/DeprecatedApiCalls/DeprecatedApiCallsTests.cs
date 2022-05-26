using System.Collections.Generic;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.DeprecatedApiCalls;

public class DeprecatedApiCallsFixture : SharedFixture, IAsyncLifetime
{
    public List<DeprecatedApiCall> CreatedDeprecatedApiCalls = new();
    public DeprecatedApiCallsService Service;

    public DeprecatedApiCallsFixture() =>
        Service = new DeprecatedApiCallsService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class DeprecatedApiCallsTests : IClassFixture<DeprecatedApiCallsFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;


    public DeprecatedApiCallsTests(DeprecatedApiCallsFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    public DeprecatedApiCallsFixture Fixture { get; set; }

    #region Read

    [SkippableFact(Skip =
        "The Deprecated API calls resource is available only for private apps and currently just returns 404.")]
    [TestPriority(20)]
    public async Task ListDeprecatedAPICallsAsync_CanList()
    {
        var response = await Fixture.Service.DeprecatedApiCalls.ListDeprecatedAPICallsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var call in response.Result.DeprecatedApiCalls)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(call, Fixture.MyShopifyUrl);
        }
    }

    #endregion Read
}