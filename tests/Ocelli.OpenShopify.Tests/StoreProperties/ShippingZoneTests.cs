namespace Ocelli.OpenShopify.Tests.StoreProperties;


public class ShippingZoneFixture : SharedFixture, IAsyncLifetime
{
    public ShippingZoneFixture() =>
        Service = new StorePropertiesService(MyShopifyUrl, AccessToken);

    public IStorePropertiesService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("ShippingZoneTests")]
public class ShippingZoneTests : IClassFixture<ShippingZoneFixture>
{
    private ShippingZoneFixture Fixture { get; }
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ShippingZoneMockClient _badRequestMockClient;
    private readonly ShippingZoneMockClient _okEmptyMockClient;
    private readonly ShippingZoneMockClient _okInvalidJsonMockClient;

    public ShippingZoneTests(ShippingZoneFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new ShippingZoneMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new ShippingZoneMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new ShippingZoneMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }


    #region Create

    #endregion Create

    #region Read

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete

    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class ShippingZoneMockClient : ShippingZoneClient, IMockTests
{
    public ShippingZoneMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnDataAsync()
    {
        ReadResponseAsString = true;
        //TODO: Validate that all methods are tested in this first section
        await Assert.ThrowsAsync<ApiException>(async () => await ListShippingZonesAsync());
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListShippingZonesAsync());
    }
}