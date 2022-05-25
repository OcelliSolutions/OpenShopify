using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class FulfillmentOrderTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ShippingAndFulfillmentService _service;
    private FulfillmentService? _fulfillmentService;
    public FulfillmentOrderTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new ShippingAndFulfillmentService(Fixture.MyShopifyUrl, Fixture.AccessToken);
        //_fulfillmentService = CreateFulfillmentService().Result;
    }

    private SharedFixture Fixture { get; }

    #region Create - NA

    #endregion Create - NA

    /*
    #region Read
    [SkippableFact, TestPriority(20)]
    public async Task ListFulfillmentOrdersAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await _service.FulfillmentOrder.ListFulfillmentOrdersForSpecificOrderAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var fulfillmentOrder in response.Result.FulfillmentOrders)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(fulfillmentOrder, Fixture.MyShopifyUrl);
            if (fulfillmentOrder.Address != null && fulfillmentOrder.Address.Contains(Domain)
                                        && !Fixture.CreatedFulfillmentOrders.Exists(w => w.Id == fulfillmentOrder.Id))
                Fixture.CreatedFulfillmentOrders.Add(fulfillmentOrder);
        }
        var list = response.Result.FulfillmentOrders;
        Skip.If(!list.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetFulfillmentOrderAsync_AdditionalPropertiesAreEmpty()
    {
        var fulfillmentOrderListResponse = await _service.FulfillmentOrder.ListFulfillmentOrdersAsync(limit: 1);
        Skip.If(!fulfillmentOrderListResponse.Result.FulfillmentOrders.Any(), "No results returned. Unable to test");
        var response = await _service.FulfillmentOrder.GetFulfillmentOrderAsync(fulfillmentOrderListResponse.Result.FulfillmentOrders.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetFulfillmentOrderAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedFulfillmentOrders.Any(), "No results returned. Unable to test");
        var fulfillmentOrder = Fixture.CreatedFulfillmentOrders.First();
        var response = await _service.FulfillmentOrder.GetFulfillmentOrderAsync(fulfillmentOrder.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    [SkippableFact, TestPriority(30)]
    public async Task UpdateFulfillmentOrderAsync_CanUpdate()
    {
        var originalFulfillmentOrder = Fixture.CreatedFulfillmentOrders.First();
        var request = new UpdateFulfillmentOrderRequest()
        {
            FulfillmentOrder = new()
            {
                Id = originalFulfillmentOrder.Id,
                Fields = new List<string>() { "id" }
            }
        };
        var response = await _service.FulfillmentOrder.UpdateFulfillmentOrderAsync(request.FulfillmentOrder.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedFulfillmentOrders.Remove(originalFulfillmentOrder);
        Fixture.CreatedFulfillmentOrders.Add(response.Result.FulfillmentOrder);
    }

    #endregion Update

    #region Delete

    [SkippableFact, TestPriority(40)]
    public async Task DeleteFulfillmentOrderAsync_CanDelete()
    {
        Skip.If(Fixture.CreatedFulfillmentOrders.Count == 0, "WARN: No data returned. Could not test");
        var errors = new List<Exception>();
        foreach (var fulfillmentOrder in Fixture.CreatedFulfillmentOrders)
        {
            try
            {
                _ = await _service.FulfillmentOrder.DeleteFulfillmentOrderAsync(fulfillmentOrder.Id);
            }
            catch (Exception ex)
            {
                errors.Add(ex);
            }
        }

        if (_fulfillmentService != null)
        {
            _ = await _service.FulfillmentService.DeleteFulfillmentServiceAsync(_fulfillmentService.Id);
        }

        foreach (var error in errors)
        {
            _testOutputHelper.WriteLine(error.Message);
        }
        Assert.Empty(errors);
    }

    #endregion Delete

    #region Setup

    private async Task<FulfillmentService> CreateFulfillmentService()
    {
        var request = Fixture.CreateFulfillmentServiceRequest;
        request.FulfillmentService.CallbackUrl += "/fulfillment_service";
        var response = await _service.FulfillmentService.CreateFulfillmentServiceAsync(request);
        return response.Result.FulfillmentService;
    }

    #endregion Setup
    */
}