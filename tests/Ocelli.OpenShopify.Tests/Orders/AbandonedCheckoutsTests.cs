using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Orders;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class AbandonedCheckoutsTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly OrdersService _service;

    public AbandonedCheckoutsTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new OrdersService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }

    #region Create

    #endregion Create

    #region Read
    
    [SkippableFact, TestPriority(20)]
    public async Task ListAbandonedCheckoutsAsync_AdditionalPropertiesIsEmpty()
    {
        var response = await _service.AbandonedCheckouts.ListAbandonedCheckoutsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var abandonedCheckouts in response.Result.Checkouts)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(abandonedCheckouts, Fixture.MyShopifyUrl);
        }
        var list = response.Result.Checkouts;
        Skip.If(!list.Any(), "No data returned. Unable to test.");
    }

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete
}
