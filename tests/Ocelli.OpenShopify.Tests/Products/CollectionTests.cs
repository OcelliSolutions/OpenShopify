using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Products;
public class CollectionFixture : SharedFixture, IAsyncLifetime
{
    public ProductsService Service;
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
    public CollectionTests(CollectionFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
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
}
