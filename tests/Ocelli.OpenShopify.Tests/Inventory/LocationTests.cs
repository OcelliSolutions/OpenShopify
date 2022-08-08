namespace Ocelli.OpenShopify.Tests.Inventory;

public class LocationFixture : SharedFixture, IAsyncLifetime
{
    public List<Location> CreatedLocations = new();
    public IInventoryService Service;

    public LocationFixture() =>
        Service = new InventoryService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("LocationTests")]
public class LocationTests : IClassFixture<LocationFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly LocationMockClient _badRequestMockClient;
    private readonly LocationMockClient _okEmptyMockClient;
    private readonly LocationMockClient _okInvalidJsonMockClient;

    public LocationTests(LocationFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new LocationMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new LocationMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new LocationMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
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
        Fixture.CreatedLocations.AddRange(response.Result.Locations);
    }

    [SkippableFact]
    [TestPriority(21)]
    public async Task GetLocationAsync_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedLocations.Any(), "Must be run with create test");
        var location = Fixture.CreatedLocations.First();
        var response = await Fixture.Service.Location.GetLocationAsync(location.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Location, Fixture.MyShopifyUrl);
    }

    #endregion Read


    [SkippableFact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class LocationMockClient : LocationClient, IMockTests
{
    public LocationMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnData()
    {
        await Assert.ThrowsAsync<ApiException>(async () => await ListInventoryLevelsForLocationAsync(0));
        await Assert.ThrowsAsync<ApiException>(async () => await ListLocationsAsync());
        await Assert.ThrowsAsync<ApiException>(async () => await CountLocationsAsync());
        await Assert.ThrowsAsync<ApiException>(async () => await GetLocationAsync(0));
    }
}
