using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Products;

[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ProductTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ProductsService _service;
    private readonly ITestOutputHelper _testOutputHelper;
    private const string ProductPrefix = "OpenShopify Product Test";
    private const string Vendor = "OpenShopify";
    private string TestProductName => $@"{ProductPrefix} {Fixture.BatchId}";

    public ProductTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
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
    public async Task Creates_Products()
    {
        var obj = await Fixture.Create();

        Assert.NotNull(obj);
        Assert.True(obj.Id.HasValue);
        Assert.Equal(Fixture.Title, obj.Title);
        Assert.Equal(Fixture.BodyHtml, obj.BodyHtml);
        Assert.Equal(Fixture.ProductType, obj.ProductType);
        Assert.Equal(Fixture.Vendor, obj.Vendor);
    }

    [SkippableFact, TestPriority(10)]
    public async Task Creates_Unpublished_Products()
    {
        var created = await Fixture.Create(options: new ProductCreateOptions()
        {
            Published = false
        });

        Assert.False(created.PublishedAt.HasValue);
    }
    */
    #endregion Create

    #region Read
    [SkippableFact, TestPriority(20)]
    public async Task Lists_Products_NoFilter()
    {
        var response = await _service.Product.ListProductsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var product in response.Result.Products)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(product, Fixture.MyShopifyUrl);
            Debug.Assert(product.Variants != null, "product.Variants != null");
            Assert.True(product.Variants.Any());
        }
    }

    [SkippableFact, TestPriority(20)]
    public async Task Lists_Products_ComparePagingByCursorAndBySinceId()
    {
        var response = await _service.Product.ListProductsAsync(sinceId: 0, limit: 2);
        
        Assert.True(response.Result.Products.Count == 2);
        Assert.NotNull(response.Pagination.NextPageInfo);
        Assert.True(response.Pagination.HasNextPage);

        var nextPageViaCursor =
            await _service.Product.ListProductsAsync(limit: 2, pageInfo: response.Pagination.NextPageInfo);
        Assert.True(nextPageViaCursor.Result.Products.Count == 2);
        Assert.NotNull(nextPageViaCursor.Pagination.NextPageInfo);
        Assert.True(nextPageViaCursor.Pagination.HasNextPage);
    }

    [SkippableFact, TestPriority(20)]
    public async Task Lists_Products_PageAll()
    {
        string? pageInfo = null;
        while (true)
        {
            var response = await _service.Product.ListProductsAsync(pageInfo: pageInfo);
            _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
            foreach (var product in response.Result.Products)
            {
                _additionalPropertiesHelper.CheckAdditionalProperties(product, Fixture.MyShopifyUrl);
            }

            if (!response.Pagination.HasNextPage) break;
        }
    }

    [SkippableFact, TestPriority(20)]
    public async Task List_Products_By_Status()
    {
        var activeResponse = await _service.Product.ListProductsAsync(status: "active");
        Assert.True(activeResponse.Result.Products.All(x => x.Status == "active"));

        var draftResponse = await _service.Product.ListProductsAsync(status: "draft");
        Assert.True(draftResponse.Result.Products.All(x => x.Status == "draft"));

        var archivedResponse = await _service.Product.ListProductsAsync(status: "archived");
        Assert.True(archivedResponse.Result.Products.All(x => x.Status == "archived"));
    }
    /*
    [SkippableFact, TestPriority(20)]
    public async Task Gets_Products()
    {
        var obj = await _service.GetAsync(Fixture.Created.First().Id.Value);

        Assert.NotNull(obj);
        Assert.True(obj.Id.HasValue);
        Assert.Equal(Fixture.Title, obj.Title);
        Assert.Equal(Fixture.BodyHtml, obj.BodyHtml);
        Assert.Equal(Fixture.ProductType, obj.ProductType);
        Assert.Equal(Fixture.Vendor, obj.Vendor);
    }
    */
    #endregion Read

    #region Update
    /*
    [SkippableFact, TestPriority(30)]
    public async Task Updates_Products()
    {
        string title = "ShopifySharp Updated Test Product";
        var created = await Fixture.Create();
        long id = created.Id.Value;

        created.Title = title;
        created.Id = null;

        var updated = await _service.UpdateAsync(id, created);

        // Reset the id so the Fixture can properly delete this object.
        created.Id = id;

        Assert.Equal(title, updated.Title);
    }

    [SkippableFact, TestPriority(30)]
    public async Task Publishes_Products()
    {
        var created = await Fixture.Create(options: new ProductCreateOptions()
        {
            Published = false
        });
        var published = await _service.PublishAsync(created.Id.Value);

        Assert.True(published.PublishedAt.HasValue);
    }

    [SkippableFact, TestPriority(30)]
    public async Task Unpublishes_Products()
    {
        var created = await Fixture.Create(options: new ProductCreateOptions()
        {
            Published = true
        });
        var unpublished = await _service.UnpublishAsync(created.Id.Value);

        Assert.False(unpublished.PublishedAt.HasValue);
    }
    */
    #endregion Update

    #region Delete
    /*
    [SkippableFact, TestPriority(40)]
    public async Task Deletes_Products()
    {
        var created = await Fixture.Create(true);
        bool threw = false;

        try
        {
            await _service.DeleteAsync(created.Id.Value);
        }
        catch (ShopifyException ex)
        {
            Console.WriteLine($"{nameof(Deletes_Products)} failed. {ex.Message}");

            threw = true;
        }

        Assert.False(threw);
    }
    */
    #endregion Delete
}
