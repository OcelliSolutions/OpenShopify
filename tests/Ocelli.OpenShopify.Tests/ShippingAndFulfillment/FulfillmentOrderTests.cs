using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;
public class FulfillmentOrderFixture : SharedFixture, IAsyncLifetime
{
    public ShippingAndFulfillmentService Service;
    public List<FulfillmentOrder> CreatedFulfillmentOrders = new();

    public FulfillmentOrderFixture()
    {
        Service = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);
    }
    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
    }
}
/*
 //TODO: This is non-standard and will require some more work.
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class FulfillmentOrderTests : IClassFixture<FulfillmentOrderFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    public FulfillmentOrderTests(FulfillmentOrderFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private FulfillmentOrderFixture Fixture { get; }

    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task CreateFulfillmentOrderAsync_CanCreate()
    {
        var request = Fixture.CreateFulfillmentOrderRequest();
        var response = await Fixture.Service.FulfillmentOrder.CreateFulfillmentOrderAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedFulfillmentOrders.Add(response.Result.FulfillmentOrder);
    }

    [SkippableFact, TestPriority(10)]
    public async Task CreateFulfillmentOrderAsync_IsUnprocessableEntityError()
    {
        var request = new CreateFulfillmentOrderRequest()
        {
            FulfillmentOrder = new()
        };
        await Assert.ThrowsAsync<ApiException<FulfillmentOrderError>>(async () => await Fixture.Service.FulfillmentOrder.CreateFulfillmentOrderAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task CountFulfillmentOrdersAsync_CanGet()
    {
        var response = await Fixture.Service.FulfillmentOrder.CountFulfillmentOrdersAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListFulfillmentOrdersAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.FulfillmentOrder.ListFulfillmentOrdersAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var fulfillmentOrder in response.Result.FulfillmentOrders)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(fulfillmentOrder, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.FulfillmentOrders.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetFulfillmentOrderAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedFulfillmentOrders.Any(), "Must be run with create test");
        var fulfillmentOrder = Fixture.CreatedFulfillmentOrders.First();
        var response = await Fixture.Service.FulfillmentOrder.GetFulfillmentOrderAsync(fulfillmentOrder.Id);
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
                Fields = new List<string> { "id" }
            }
        };
        var response = await Fixture.Service.FulfillmentOrder.UpdateFulfillmentOrderAsync(originalFulfillmentOrder.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedFulfillmentOrders.Remove(originalFulfillmentOrder);
        Fixture.CreatedFulfillmentOrders.Add(response.Result.FulfillmentOrder);
    }

    #endregion Update
}
*/