using System;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Products;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CollectTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ProductsService _service;

    public CollectTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
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
    public async Task Creates_Collects()
    {
        var collect = await Fixture.Create();

        Assert.NotNull(collect);
        Assert.True(collect.Id.HasValue);
        Assert.Equal(Fixture.CollectionId, collect.CollectionId);
        Assert.True(collect.ProductId > 0);
    }
    */
    #endregion Create

    #region Read
    [SkippableFact, TestPriority(20)]
    public async Task Counts_Collects()
    {
        var response = await _service.Collect.CountCollectsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        Assert.NotNull(response.Result.Count);
    }

    [SkippableFact, TestPriority(20)]
    public async Task Lists_Collects()
    {
        var response = await _service.Collect.ListCollectsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var collect in response.Result.Collects)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(collect, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.Collects.Any());
    }
    /*
    [SkippableFact, TestPriority(20)]
    public async Task Lists_Collects_With_A_Filter()
    {
        var productId = Fixture.Created.First().ProductId;
        var collects = await Fixture.Service.ListAsync(new CollectListFilter()
        {
            ProductId = productId,
        });

        Assert.True(collects.Items.Count() > 0);
        Assert.All(collects.Items, collect => Assert.True(collect.ProductId > 0));
    }

    [SkippableFact, TestPriority(20)]
    public async Task Gets_Collects()
    {
        var collect = await Fixture.Service.GetAsync(Fixture.Created.First().Id.Value);

        Assert.NotNull(collect);
        Assert.True(collect.Id.HasValue);
        Assert.Equal(Fixture.CollectionId, collect.CollectionId);
        Assert.True(collect.ProductId > 0);
    }
    */
    #endregion Read

    #region Update

    //TODO: is there an update method?

    #endregion Update

    #region Delete
    /*
    [SkippableFact, TestPriority(40)]
    public async Task Deletes_Collects()
    {
        var created = await Fixture.Create(true);
        bool thrown = false;

        try
        {
            await Fixture.Service.DeleteAsync(created.Id.Value);
        }
        catch (ShopifyException ex)
        {
            Console.Write($"{nameof(Deletes_Collects)} failed. {ex.Message}.");

            thrown = true;
        }

        Assert.False(thrown);
    }
    */
    #endregion Delete
}
