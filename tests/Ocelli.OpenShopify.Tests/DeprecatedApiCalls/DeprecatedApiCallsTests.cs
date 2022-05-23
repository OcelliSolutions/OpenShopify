using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.DeprecatedApiCalls;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class DeprecatedApiCallsTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly DeprecatedApiCallsService _service;

    public DeprecatedApiCallsTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _testOutputHelper = testOutputHelper;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new DeprecatedApiCallsService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }

    #region Read
    [SkippableFact(Skip = "The Deprecated API calls resource is available only for private apps and currently just returns 404."), TestPriority(20)]
    public async Task ListDeprecatedAPICallsAsync_CanList()
    {
        var response = await _service.DeprecatedApiCalls.ListDeprecatedAPICallsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var call in response.Result.DeprecatedApiCalls)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(call, Fixture.MyShopifyUrl);
        }
    }
    #endregion Read
}
