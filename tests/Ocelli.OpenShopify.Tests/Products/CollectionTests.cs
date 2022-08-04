using System.Collections.Generic;

namespace Ocelli.OpenShopify.Tests.Products;
public class CollectionFixture : SharedFixture, IAsyncLifetime
{
    public IProductsService Service;
    public List<Collection> CreatedCollections = new();

    public CollectionFixture()
    {
        Service = new ProductsService(MyShopifyUrl, AccessToken);
    }
    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
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
        Skip.If(!Fixture.CreatedCollections.Any(), "Must be run with create test");
        var collection = Fixture.CreatedCollections.First();
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
        Skip.If(!Fixture.CreatedCollections.Any(), "Must be run with create test");
        var collection = Fixture.CreatedCollections.First();
        var response = await Fixture.Service.Collection.GetCollectionAsync(collection.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Collection, Fixture.MyShopifyUrl);
    }

    #endregion Read


    [Fact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class CollectionMockClient : CollectionClient, IMockTests
{
    public CollectionMockClient(HttpClient httpClient, CollectionFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        throw new XunitException("Not implemented.");
    }
}

