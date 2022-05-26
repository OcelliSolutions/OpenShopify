using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Orders;

public class DraftOrderFixture : SharedFixture, IAsyncLifetime
{
    public List<DraftOrder> CreatedDraftOrders = new();
    public OrdersService Service;

    public DraftOrderFixture() =>
        Service = new OrdersService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync() => await DeleteDraftOrderAsync_CanDelete();
    
    public async Task DeleteDraftOrderAsync_CanDelete()
    {
        foreach (var draftOrder in CreatedDraftOrders)
        {
            _ = await Service.DraftOrder.DeleteDraftOrderAsync(draftOrder.Id);
        }
        CreatedDraftOrders.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class DraftOrderTests : IClassFixture<DraftOrderFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public DraftOrderTests(DraftOrderFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private DraftOrderFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateDraftOrderAsync_CanUpdate()
    {
        var originalDraftOrder = Fixture.CreatedDraftOrders.First();
        var request = new UpdateDraftOrderRequest
        {
            DraftOrder = new UpdateDraftOrder
            {
                Id = originalDraftOrder.Id,
                Note = "Customer contacted us about a custom engraving on this iPod"
            }
        };
        var response = await Fixture.Service.DraftOrder.UpdateDraftOrderAsync(originalDraftOrder.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedDraftOrders.Remove(originalDraftOrder);
        Fixture.CreatedDraftOrders.Add(response.Result.DraftOrder);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateDraftOrderAsync_CanCreate()
    {
        var request = Fixture.CreateDraftOrderRequest();
        var response = await Fixture.Service.DraftOrder.CreateDraftOrderAsync(body: request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedDraftOrders.Add(response.Result.DraftOrder);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateDraftOrderAsync_IsUnprocessableEntityError()
    {
        var request = new CreateDraftOrderRequest
        {
            DraftOrder = new CreateDraftOrder()
        };
        await Assert.ThrowsAsync<ApiException<DraftOrderError>>(async () =>
            await Fixture.Service.DraftOrder.CreateDraftOrderAsync(body: request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountDraftOrdersAsync_CanGet()
    {
        var response = await Fixture.Service.DraftOrder.CountDraftOrdersAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListDraftOrdersAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.DraftOrder.ListDraftOrdersAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var draftOrder in response.Result.DraftOrders)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(draftOrder, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.DraftOrders.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetDraftOrderAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedDraftOrders.Any(), "Must be run with create test");
        var draftOrder = Fixture.CreatedDraftOrders.First();
        var response = await Fixture.Service.DraftOrder.GetDraftOrderAsync(draftOrder.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.DraftOrder, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteDraftOrderAsync_CanDelete()
    {
        await Fixture.DeleteDraftOrderAsync_CanDelete();
    }

    #endregion Delete
    }