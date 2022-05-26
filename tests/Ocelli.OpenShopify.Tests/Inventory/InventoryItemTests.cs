using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Inventory;

public class InventoryItemFixture : SharedFixture, IAsyncLifetime
{
    public List<InventoryItem> CreatedInventoryItems = new();
    public InventoryService Service;

    public InventoryItemFixture() =>
        Service = new InventoryService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class InventoryItemTests : IClassFixture<InventoryItemFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public InventoryItemTests(InventoryItemFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private InventoryItemFixture Fixture { get; }

    //TODO: Figure out how to create an Inventory Item

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateInventoryItemAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedInventoryItems.Any(), "Must be run with create test");
        var originalInventoryItem = Fixture.CreatedInventoryItems.First();
        var request = new UpdateInventoryItemRequest
        {
            InventoryItem = new UpdateInventoryItem
            {
                Id = originalInventoryItem.Id,
                Sku = Fixture.BatchId
            }
        };
        var response = await Fixture.Service.InventoryItem.UpdateInventoryItemAsync(originalInventoryItem.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedInventoryItems.Remove(originalInventoryItem);
        Fixture.CreatedInventoryItems.Add(response.Result.InventoryItem);
    }

    #endregion Update

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListInventoryItemsAsync_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedInventoryItems.Any(), "Must be run with create test");
        var response = await Fixture.Service.InventoryItem.ListInventoryItemsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var inventoryItem in response.Result.InventoryItems)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(inventoryItem, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.InventoryItems.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetInventoryItemAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedInventoryItems.Any(), "Must be run with create test");
        var inventoryItem = Fixture.CreatedInventoryItems.First();
        var response = await Fixture.Service.InventoryItem.GetInventoryItemAsync(inventoryItem.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.InventoryItem, Fixture.MyShopifyUrl);
    }

    #endregion Read
}