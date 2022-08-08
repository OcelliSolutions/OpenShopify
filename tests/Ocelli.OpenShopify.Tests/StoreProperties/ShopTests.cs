namespace Ocelli.OpenShopify.Tests.StoreProperties;

public class ShopFixture : SharedFixture, IAsyncLifetime
{
    public List<Shop> CreatedShops = new();
    public IStorePropertiesService Service;

    public ShopFixture() =>
        Service = new StorePropertiesService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("ShopTests")]
public class ShopTests : IClassFixture<ShopFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ShopMockClient _badRequestMockClient;
    private readonly ShopMockClient _okEmptyMockClient;
    private readonly ShopMockClient _okInvalidJsonMockClient;

    public ShopTests(ShopFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new ShopMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new ShopMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new ShopMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private ShopFixture Fixture { get; }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetShopsConfigurationAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Shop.GetShopsConfigurationAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Shop, Fixture.MyShopifyUrl);
    }

    #endregion Read

    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class ShopMockClient : ShopClient, IMockTests
{
    public ShopMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await GetShopsConfigurationAsync());
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await GetShopsConfigurationAsync());
    }
}