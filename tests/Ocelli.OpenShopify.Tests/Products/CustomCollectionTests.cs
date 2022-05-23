using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Products;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CustomCollectionTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ProductsService _service;

    public CustomCollectionTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new ProductsService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }

    #region Create

    /*
    [SkippableFact, TestPriority(10)]
    public async Task Creates_CustomCollections()
    {
        var collection = await Fixture.Create();

        Assert.NotNull(collection);
        Assert.True(collection.Id.HasValue);
        Assert.Equal(Fixture.Title, collection.Title);
    }
    */

    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task Counts_CustomCollections()
    {
        var response = await _service.CustomCollection.CountCustomCollectionsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        Assert.NotNull(response.Result.Count);
    }

    [SkippableFact, TestPriority(20)]
    public async Task Lists_CustomCollections()
    {
        var response = await _service.CustomCollection.ListCustomCollectionsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var customCollection in response.Result.CustomCollections)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(customCollection, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.CustomCollections.Any());
    }

    [SkippableFact, TestPriority(20)]
    public async Task Gets_CustomCollections()
    {
        var listResponse = await _service.CustomCollection.ListCustomCollectionsAsync(limit:1);
        var customCollection = listResponse.Result.CustomCollections.First();
        var response = await _service.CustomCollection.GetCustomCollectionAsync(customCollection.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CustomCollection, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update
    /*
    [SkippableFact, TestPriority(30)]
    public async Task Updates_CustomCollections()
    {
        string newTitle = "New Title";
        var created = await Fixture.Create();
        long id = created.Id.Value;

        created.Title = newTitle;
        created.Id = null;

        var updated = await Fixture.Service.UpdateAsync(id, created);

        // Reset the id so the Fixture can properly delete this object.
        created.Id = id;

        Assert.Equal(newTitle, updated.Title);
    }
    */
    #endregion Update

    #region Delete
    /*
    [SkippableFact, TestPriority(40)]
    public async Task Deletes_CustomCollections()
    {
        var created = await Fixture.Create(true);
        bool threw = false;

        try
        {
            await Fixture.Service.DeleteAsync(created.Id.Value);
        }
        catch (ShopifyException ex)
        {
            Console.WriteLine($"{nameof(Deletes_CustomCollections)} failed. {ex.Message}");

            threw = true;
        }

        Assert.False(threw);
    }
    */
    #endregion Delete
}
