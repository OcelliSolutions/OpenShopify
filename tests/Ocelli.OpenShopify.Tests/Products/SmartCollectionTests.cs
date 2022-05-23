using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Products;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class SmartCollectionTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ProductsService _service;

    public SmartCollectionTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
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
    public async Task Creates_SmartCollections()
    {
        var obj = await Fixture.Create();

        Assert.NotNull(obj);
        Assert.True(obj.Id.HasValue);
        Assert.Equal(Fixture.BodyHtml, obj.BodyHtml);
        Assert.Equal(Fixture.Title, obj.Title);
        Assert.StartsWith(Fixture.Handle, obj.Handle, StringComparison.OrdinalIgnoreCase);
        Assert.NotNull(obj.PublishedAt);
        Assert.NotNull(obj.PublishedScope);
    }

    [SkippableFact, TestPriority(10)]
    public async Task Creates_Unpublished_SmartCollections()
    {
        var obj = await Fixture.Create(false);

        Assert.NotNull(obj);
        Assert.True(obj.Id.HasValue);
        Assert.Equal(Fixture.BodyHtml, obj.BodyHtml);
        Assert.Equal(Fixture.Title, obj.Title);
        Assert.StartsWith(Fixture.Handle, obj.Handle, StringComparison.OrdinalIgnoreCase);
        Assert.Null(obj.PublishedAt);
    }
    */
    #endregion Create

    #region Read
    [SkippableFact, TestPriority(20)]
    public async Task Counts_SmartCollections()
    {
        var response = await _service.SmartCollection.CountSmartCollectionsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        Assert.NotNull(response.Result.Count);
    }

    [SkippableFact, TestPriority(20)]
    public async Task Lists_SmartCollections()
    {
        var response = await _service.SmartCollection.ListSmartCollectionsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var smartCollection in response.Result.SmartCollections)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(smartCollection, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.SmartCollections.Any());
    }

    
    [SkippableFact, TestPriority(20)]
    public async Task Gets_SmartCollections()
    {
        var smartCollectionResponse = await _service.SmartCollection.ListSmartCollectionsAsync(limit: 1);
        var smartCollection = smartCollectionResponse.Result.SmartCollections.First();
        var response = await _service.SmartCollection.GetSmartCollectionAsync(smartCollection.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.SmartCollection, Fixture.MyShopifyUrl);
    }
    #endregion Read

    #region Update
    /*
    [SkippableFact, TestPriority(30)]
    public async Task Updates_SmartCollections()
    {
        string newValue = "New Title";
        var created = await Fixture.Create();
        long id = created.Id.Value;

        created.Title = newValue;
        created.Id = null;

        var updated = await Fixture.Service.UpdateAsync(id, created);

        // Reset the id so the Fixture can properly delete this object.
        created.Id = id;

        Assert.Equal(newValue, updated.Title);
    }

    [SkippableFact, TestPriority(30)]
    public async Task Publishes_SmartCollections()
    {
        var created = await Fixture.Create(false);

        Assert.Null(created.PublishedAt);

        var updated = await Fixture.Service.PublishAsync(created.Id.Value);

        Assert.NotNull(updated.PublishedAt);
    }

    [SkippableFact, TestPriority(30)]
    public async Task Unpublishes_SmartCollections()
    {
        var created = await Fixture.Create(true);

        Assert.NotNull(created.PublishedAt);

        var updated = await Fixture.Service.UnpublishAsync(created.Id.Value);

        Assert.Null(updated.PublishedAt);
    }
    */
    #endregion Update

    #region Delete
    /*
    [SkippableFact, TestPriority(40)]
    public async Task Deletes_SmartCollections()
    {
        var created = await Fixture.Create(true, true);
        bool threw = false;

        try
        {
            await Fixture.Service.DeleteAsync(created.Id.Value);
        }
        catch (ShopifyException ex)
        {
            Console.WriteLine($"{nameof(Deletes_SmartCollections)} failed. {ex.Message}");

            threw = true;
        }

        Assert.False(threw);
    }
    */
    #endregion Delete
}
