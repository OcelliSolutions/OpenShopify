using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Orders;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class RefundTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly OrdersService _service;

    public RefundTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
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
    public async Task ListRefundsAsync_AdditionalPropertiesAreEmpty()
    {
        var testable = false;
        var orderResponse = await _service.Order.ListOrdersAsync();
        foreach (var order in orderResponse.Result.Orders)
        {
            var response = await _service.Refund.ListRefundsForOrderAsync(order.Id);
            _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
            foreach (var refund in response.Result.Refunds)
            {
                _additionalPropertiesHelper.CheckAdditionalProperties(refund, Fixture.MyShopifyUrl);
            }
            testable = response.Result.Refunds.Any() || testable;
        }
        Skip.If(!testable, "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetRefundAsync_AdditionalPropertiesAreEmpty()
    {
        var testable = false;
        var orderResponse = await _service.Order.ListOrdersAsync();
        foreach (var order in orderResponse.Result.Orders)
        {
            var orderRefundListResponse = await _service.Refund.ListRefundsForOrderAsync(order.Id);
            testable = orderRefundListResponse.Result.Refunds.Any() || testable;
            if (!orderRefundListResponse.Result.Refunds.Any()) continue;

            var orderRefund = orderRefundListResponse.Result.Refunds.First();
            var response = await _service.Refund.GetRefundAsync(order.Id, orderRefund.Id);

            _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
            _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Refund, Fixture.MyShopifyUrl);
        }
        Skip.If(!testable, "No results returned. Unable to test");
    }

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete
}
