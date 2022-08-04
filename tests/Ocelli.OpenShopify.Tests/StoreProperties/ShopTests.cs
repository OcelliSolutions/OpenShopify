using System.Collections.Generic;

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

    [Fact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class ShopMockClient : ShopClient, IMockTests
{
    public ShopMockClient(HttpClient httpClient, ShopFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        throw new XunitException("Not implemented.");
    }
}