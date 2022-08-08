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
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class ShippingZoneMockClient : ShippingZoneClient, IMockTests
{
    public ShippingZoneMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        Skip.If(0==1,"Not implemented.");
        return Task.CompletedTask;
    }
}