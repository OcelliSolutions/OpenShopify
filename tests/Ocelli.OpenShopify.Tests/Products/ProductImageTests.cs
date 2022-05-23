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
public class ProductImageTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ProductsService _service;

    public ProductImageTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
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
    public async Task Creates_ProductImages()
    {
        var created = await Fixture.Create();

        Assert.NotNull(created);
        Assert.True(created.Id.HasValue);
        Assert.Equal(Fixture.ProductId, created.ProductId);
    }
    */
    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task Counts_ProductImages()
    {
        var productResponse = await _service.Product.ListProductsAsync(limit: 1);
        var product = productResponse.Result.Products.First();
        var response = await _service.ProductImage.CountProductImagesAsync(product.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        Assert.NotNull(response.Result.Count);
    }

    [SkippableFact, TestPriority(20)]
    public async Task Lists_ProductImages()
    {
        var productResponse = await _service.Product.ListProductsAsync(limit: 1);
        var product = productResponse.Result.Products.First();
        var response = await _service.ProductImage.ListProductImagesAsync(product.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var productImage in response.Result.Images)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(productImage, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.Images.Any());
    }

    
    [SkippableFact, TestPriority(20)]
    public async Task Gets_ProductImages()
    {
        var productResponse = await _service.Product.ListProductsAsync(limit: 1);
        var product = productResponse.Result.Products.First();
        var productImagesResponse = await _service.ProductImage.ListProductImagesAsync(product.Id);
        var productImage = productImagesResponse.Result.Images.First();
        var response = await _service.ProductImage.GetProductImageAsync(productImage.Id, productImage.ProductId ?? 0);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Image, Fixture.MyShopifyUrl);
    }
    #endregion Read

    #region Update
    /*
    [SkippableFact, TestPriority(30)]
    public async Task Updates_ProductImages()
    {
        var created = await Fixture.Create();
        var newAlt = $"ShopifySharp test {Guid.NewGuid()}";
        long id = created.Id.Value;

        created.Alt = newAlt;
        created.Id = null;

        var updated = await Fixture.Service.UpdateAsync(created.ProductId.Value, id, created);

        // Reset the id so the Fixture can properly delete this object.
        created.Id = id;

        Assert.Equal(newAlt, updated.Alt);
    }
    */
    #endregion Update

    #region Delete
    /*
    [SkippableFact, TestPriority(40)]
    public async Task Deletes_ProductImages()
    {
        var created = await Fixture.Create(true);
        bool threw = false;

        try
        {
            await Fixture.Service.DeleteAsync(Fixture.ProductId, created.Id.Value);
        }
        catch (ShopifyException ex)
        {
            Console.WriteLine($"{nameof(Deletes_ProductImages)} failed. {ex.Message}");

            threw = true;
        }

        Assert.False(threw);
    }
    */
    #endregion Delete
}
