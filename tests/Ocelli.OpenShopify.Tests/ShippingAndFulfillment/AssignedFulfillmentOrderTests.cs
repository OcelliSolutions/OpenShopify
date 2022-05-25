using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class AssignedFulfillmentOrderTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ShippingAndFulfillmentService _service;

    public AssignedFulfillmentOrderTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new ShippingAndFulfillmentService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }

    #region Create

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task ListAssignedFulfillmentOrdersAsync_AdditionalPropertiesAreEmpty()
    {
        var fulfillmentServiceRequest = Fixture.CreateFulfillmentServiceRequest;
        var fulfillmentServiceResponse = await _service.FulfillmentService.CreateFulfillmentServiceAsync(fulfillmentServiceRequest);
        Fixture.CreatedFulfillmentServices.Add(fulfillmentServiceResponse.Result.FulfillmentService);
        var response = await _service.AssignedFulfillmentOrder.ListFulfillmentOrdersOnShopForSpecificAppAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var assignedFulfillmentOrder in response.Result.FulfillmentOrders)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(assignedFulfillmentOrder, Fixture.MyShopifyUrl);
        }
        var list = response.Result.FulfillmentOrders;
        Skip.If(!list.Any(), "No results returned. Unable to test");
    }

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete
}