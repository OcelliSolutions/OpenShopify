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
    private readonly List<Product> _testProducts;
    private readonly ProductsService _service;
    private const string ProductPrefix = "OpenShopify Product Test";
    private const string Vendor = "OpenShopify";
    private string TestProductName => $@"{ProductPrefix} {Fixture.BatchId}";

    public ProductTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _testProducts = new List<Product>();
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new ProductsService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }
    /*
    /// <summary>
    /// Create product first
    /// </summary>
    [SkippableFact, TestPriority(10)]
    public async Task CreateFulfillmentServiceAsync_CanCreate()
    {
        var request = new ProductItem()
        {
            Product = new Product()
            {
                Title = TestProductName,
                Vendor = Vendor
            }
        };
        var created = await _service.Product.CreateProductAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(created, Fixture.MyShopifyUrl);

        Assert.Equal(TestProductName, created.Product?.Title);
        Assert.NotNull(created.Product?.Id);
        Debug.Assert(created.Product != null, "created.Product != null");
        _testProducts.Add(created.Product);
    }


    [SkippableFact, TestPriority(20)]
    public async Task Counts_Products()
    {
        var count = await _service.Product.GetCountOfProductsAsync();
        Assert.True(count.Count > 0);
    }

    [Fact]
    public async Task Lists_Products_NoFilter()
    {
        var list = await _service.Product.ListProductsAsync();

        Debug.Assert(list.Products != null, "list.Products != null");
        foreach (var product in list.Products)
        {
            Debug.Assert(product.Variants != null, "product.Variants != null");
            Assert.True(product.Variants.Any());
            Assert.NotNull(product.LinkHeader.NextLink);
            Assert.NotNull(product.LinkHeader.NextLink.PageInfo);
            Assert.NotNull(product.LinkHeader.NextLink.Url);
        }
    }

    [Fact]
    public async Task Lists_Products_ComparePagingByCursorAndBySinceId()
    {
        var list = await _service.ListAsync(new ProductListFilter
        {
            SinceId = 0,
            Limit = 2
        });
        Assert.True(list.Items.Count() == 2);
        Assert.NotNull(list.LinkHeader.NextLink);
        Assert.NotNull(list.LinkHeader.NextLink.PageInfo);
        Assert.NotNull(list.LinkHeader.NextLink.Url);

        var nextPageViaCursor = await _service.ListAsync(list.GetNextPageFilter(2));
        Assert.True(list.Items.Count() == 2);
        Assert.NotNull(list.LinkHeader.NextLink);
        Assert.NotNull(list.LinkHeader.NextLink.PageInfo);
        Assert.NotNull(list.LinkHeader.NextLink.Url);

        var nextPageViaSinceId = await _service.ListAsync(new ProductListFilter
        {
            SinceId = list.Items.Last().Id.Value,
            Limit = 2
        });
        Assert.True(list.Items.Count() == 2);
        Assert.NotNull(list.LinkHeader.NextLink);
        Assert.NotNull(list.LinkHeader.NextLink.PageInfo);
        Assert.NotNull(list.LinkHeader.NextLink.Url);

        Assert.True(Enumerable.SequenceEqual(nextPageViaCursor.Items.Select(i => i.Id.Value),
                                             nextPageViaSinceId.Items.Select(i => i.Id.Value)));
    }

    [Fact]
    public async Task Lists_Products_PageAll()
    {
        var svc = _service;
        var list = await svc.ListAsync(new ProductListFilter { Limit = 5 });

        while (true)
        {
            Assert.True(list.Items.Any());
            list = await svc.ListAsync(list.GetNextPageFilter());
            if (!list.HasNextPage)
                break;
        }
    }

    [Fact]
    public async Task List_Products_By_Status()
    {
        var svc = _service;
        var list = await svc.ListAsync(new ProductListFilter { Limit = 5 });
        Assert.True(list.Items.Any()); //if we get something here, then...

        list = await svc.ListAsync(new ProductListFilter { Limit = 5, Status = "active" });
        bool anyActive = list.Items.Any();
        if (anyActive)
            Assert.True(list.Items.All(x => x.Status == "active"));

        list = await svc.ListAsync(new ProductListFilter { Limit = 5, Status = "draft" });
        bool anyDraft = list.Items.Any();
        if (anyDraft)
            Assert.True(list.Items.All(x => x.Status == "draft"));

        list = await svc.ListAsync(new ProductListFilter { Limit = 5, Status = "archived" });
        bool anyArchive = list.Items.Any();
        if (anyDraft)
            Assert.True(list.Items.All(x => x.Status == "archived"));

        Assert.False(!anyActive && !anyDraft && !anyArchive); //we should make sure we get something here (these represent all statuses for a product)
    }

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
    public async Task Creates_Unpublished_Products()
    {
        var created = await Fixture.Create(options: new ProductCreateOptions()
        {
            Published = false
        });

        Assert.False(created.PublishedAt.HasValue);
    }

    [Fact]
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

    [Fact]
    public async Task Publishes_Products()
    {
        var created = await Fixture.Create(options: new ProductCreateOptions()
        {
            Published = false
        });
        var published = await _service.PublishAsync(created.Id.Value);

        Assert.True(published.PublishedAt.HasValue);
    }

    [Fact]
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
}
