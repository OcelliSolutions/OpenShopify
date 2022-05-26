using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Inventory;
public class InventoryLevelFixture : SharedFixture, IAsyncLifetime
{
    public InventoryService Service;
    public InventoryItem InventoryItem = new();
    public Location Location = new();
    public List<InventoryLevel> CreatedInventoryLevels = new();

    public InventoryLevelFixture()
    {
        Service = new InventoryService(MyShopifyUrl, AccessToken);
    }
    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteInventoryLevelAsync_CanDelete();
    }
    
    public async Task DeleteInventoryLevelAsync_CanDelete()
    {
        foreach (var inventoryLevel in CreatedInventoryLevels)
        {
            _ = await Service.InventoryLevel.DeleteInventoryLevelFromLocationAsync(inventoryLevel.Id, Location.Id);
        }
        CreatedInventoryLevels.Clear();
    }
}
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class InventoryLevelTests : IClassFixture<InventoryLevelFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    public InventoryLevelTests(InventoryLevelFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private InventoryLevelFixture Fixture { get; }

    /*
        #region Create

        [SkippableFact, TestPriority(10)]
        public async Task CreateInventoryLevelAsync_CanCreate()
        {
            var request = new CreateInventoryLevelRequest()
            {
                InventoryLevel = new()
                {
                    Topic = InventoryLevelTopic.FulfillmentEventsCreate,
                    Address = $@"{Fixture.CallbackUrl}/fulfillment_events_create"
                }
            };
            var response = await Fixture.Service.InventoryLevel.CreateInventoryLevelAsync(request);
            _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

            Fixture.CreatedInventoryLevels.Add(response.Result.InventoryLevel);
        }

        [SkippableFact, TestPriority(10)]
        public async Task CreateInventoryLevelAsync_IsUnprocessableEntityError()
        {
            var request = new CreateInventoryLevelRequest()
            {
                InventoryLevel = new()
            };
            await Assert.ThrowsAsync<ApiException<InventoryLevelError>>(async () => await Fixture.Service.InventoryLevel.CreateInventoryLevelAsync(request));
        }

        #endregion Create

        #region Read

        [SkippableFact, TestPriority(20)]
        public async Task CountInventoryLevelsAsync_CanGet()
        {
            var response = await Fixture.Service.InventoryLevel.CountInventoryLevelsAsync();
            _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
            var count = response.Result.Count;
            Skip.If(count == 0, "No results returned. Unable to test");
        }

        [SkippableFact, TestPriority(20)]
        public async Task ListInventoryLevelsAsync_AdditionalPropertiesAreEmpty()
        {
            var response = await Fixture.Service.InventoryLevel.ListInventoryLevelsAsync();
            _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
            foreach (var inventoryLevel in response.Result.InventoryLevels)
            {
                _additionalPropertiesHelper.CheckAdditionalProperties(inventoryLevel, Fixture.MyShopifyUrl);
            }
            Skip.If(!response.Result.InventoryLevels.Any(), "No results returned. Unable to test");
        }

        [SkippableFact, TestPriority(20)]
        public async Task GetInventoryLevelAsync_TestCreated_AdditionalPropertiesAreEmpty()
        {
            Skip.If(!Fixture.CreatedInventoryLevels.Any(), "Must be run with create test");
            var inventoryLevel = Fixture.CreatedInventoryLevels.First();
            var response = await Fixture.Service.InventoryLevel.GetInventoryLevelAsync(inventoryLevel.Id);
            _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
            _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.InventoryLevel, Fixture.MyShopifyUrl);
        }

        #endregion Read

        #region Update

        [SkippableFact, TestPriority(30)]
        public async Task UpdateInventoryLevelAsync_CanUpdate()
        {
            var originalInventoryLevel = Fixture.CreatedInventoryLevels.First();
            var request = new UpdateInventoryLevelRequest()
            {
                InventoryLevel = new()
                {
                    Id = originalInventoryLevel.Id,
                    Fields = new List<string> { "id" }
                }
            };
            var response = await Fixture.Service.InventoryLevel.UpdateInventoryLevelAsync(request.InventoryLevel.Id, request);
            _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

            Fixture.CreatedInventoryLevels.Remove(originalInventoryLevel);
            Fixture.CreatedInventoryLevels.Add(response.Result.InventoryLevel);
        }

        #endregion Update
    */

    #region Delete

    [SkippableFact, TestPriority(99)]
    public async Task DeleteInventoryLevelAsync_CanDelete()
    {
        await Fixture.DeleteInventoryLevelAsync_CanDelete();
    }

    #endregion Delete
}
