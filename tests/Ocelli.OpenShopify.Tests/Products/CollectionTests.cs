namespace Ocelli.OpenShopify.Tests.Products;
public class CollectionFixture : SharedFixture, IAsyncLifetime
{
    public IProductsService Service;
    public List<SmartCollection> Collections = new();

    public CollectionFixture()
    {
        Service = new ProductsService(MyShopifyUrl, AccessToken);
    }

    public async Task InitializeAsync()
    {
        var response = await Service.SmartCollection.ListSmartCollectionsAsync();
        Collections.AddRange(response.Result.SmartCollections);
    }
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("CollectionTests")]
public class CollectionTests : IClassFixture<CollectionFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly CollectionMockClient _badRequestMockClient;
    private readonly CollectionMockClient _okEmptyMockClient;
    private readonly CollectionMockClient _okInvalidJsonMockClient;

    public CollectionTests(CollectionFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new CollectionMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new CollectionMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new CollectionMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private CollectionFixture Fixture { get; }
    
    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task ListCollectionsAsync_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.Collections.Any(), "Must be run with create test");
        var collection = Fixture.Collections.First();
        var response = await Fixture.Service.Collection.ListProductsBelongingToCollectionAsync(collection.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var product in response.Result.Products)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(product, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.Products.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetCollectionAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.Collections.Any(), "Must be run with create test");
        var collection = Fixture.Collections.First();
        var response = await Fixture.Service.Collection.GetCollectionAsync(collection.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Collection, Fixture.MyShopifyUrl);
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

internal class CollectionMockClient : CollectionClient, IMockTests
{
    public CollectionMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListProductsBelongingToCollectionAsync(0, 1, "NA"));
        await Assert.ThrowsAsync<ApiException>(async () => await GetCollectionAsync(0, "id"));
    }
}

