using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Inventory;

public class LocationFixture : SharedFixture, IAsyncLifetime
{
    public List<Location> CreatedLocations = new();
    public InventoryService Service;

    public LocationFixture() =>
        Service = new InventoryService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class LocationTests : IClassFixture<LocationFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public LocationTests(LocationFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private LocationFixture Fixture { get; }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountLocationsAsync_CanGet()
    {
        var response = await Fixture.Service.Location.CountLocationsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListLocationsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Location.ListLocationsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var location in response.Result.Locations)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(location, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Locations.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetLocationAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedLocations.Any(), "Must be run with create test");
        var location = Fixture.CreatedLocations.First();
        var response = await Fixture.Service.Location.GetLocationAsync(location.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Location, Fixture.MyShopifyUrl);
    }

    #endregion Read
}