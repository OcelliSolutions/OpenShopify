using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Orders;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class DraftOrderTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly OrdersService _service;

    public DraftOrderTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
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
    public async Task CountDraftOrdersAsync_CanGet()
    {
        var response = await _service.DraftOrder.CountDraftOrdersAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Assert.True(count > 0);
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListDraftOrdersAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await _service.DraftOrder.ListDraftOrdersAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var draftOrder in response.Result.DraftOrders)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(draftOrder, Fixture.MyShopifyUrl);
        }
        var list = response.Result.DraftOrders;
        Assert.True(list.Any());
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetDraftOrderAsync_AdditionalPropertiesAreEmpty()
    {
        var draftOrderListResponse = await _service.DraftOrder.ListDraftOrdersAsync(limit: 1);
        var response = await _service.DraftOrder.GetDraftOrderAsync(draftOrderListResponse.Result.DraftOrders.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.DraftOrder, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete
}
