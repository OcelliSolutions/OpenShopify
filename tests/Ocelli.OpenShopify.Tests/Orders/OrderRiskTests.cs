using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Orders;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class OrderRiskTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly OrdersService _service;

    public OrderRiskTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
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
    public async Task ListOrderRisksAsync_AdditionalPropertiesAreEmpty()
    {
        var testable = false;
        var orderResponse = await _service.Order.ListOrdersAsync();
        foreach (var order in orderResponse.Result.Orders)
        {
            var response = await _service.OrderRisk.ListOrderRisksForOrderAsync(order.Id);
            _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
            foreach (var orderRisk in response.Result.Risks)
            {
                _additionalPropertiesHelper.CheckAdditionalProperties(orderRisk, Fixture.MyShopifyUrl);
            }
            testable = response.Result.Risks.Any() || testable;
        }
        Skip.If(!testable, "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetOrderRiskAsync_AdditionalPropertiesAreEmpty()
    {
        var testable = false;
        var orderResponse = await _service.Order.ListOrdersAsync();
        foreach (var order in orderResponse.Result.Orders)
        {
            var orderRiskListResponse = await _service.OrderRisk.ListOrderRisksForOrderAsync(order.Id);
            testable = orderRiskListResponse.Result.Risks.Any() || testable;
            if(!orderRiskListResponse.Result.Risks.Any()) continue;
            
            var orderRisk = orderRiskListResponse.Result.Risks.First();
            var response = await _service.OrderRisk.GetOrderRiskAsync(order.Id, orderRisk.Id);
            
            _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
            _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Risk, Fixture.MyShopifyUrl);
        }
        Skip.If(!testable, "No results returned. Unable to test");
    }

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete
}
