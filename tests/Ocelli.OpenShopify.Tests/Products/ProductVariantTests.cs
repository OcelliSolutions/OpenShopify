using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Products;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ProductVariantTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ProductsService _service;

    public ProductVariantTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
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
    public async Task Creates_Variants()
    {
        var created = await Fixture.Create();

        Assert.NotNull(created);
        Assert.True(created.Id.HasValue);
        Assert.Equal(Fixture.Price, created.Price);
        EmptyAssert.NotNullOrEmpty(created.Option1);
    }
    */
    #endregion Create

    #region Read
    [SkippableFact, TestPriority(20)]
    public async Task Counts_Variants()
    {
        var productResponse = await _service.Product.ListProductsAsync(limit: 1);
        var product = productResponse.Result.Products.First();
        var response = await _service.ProductVariant.CountProductVariantsAsync(product.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        Assert.NotNull(response.Result.Count);
    }

    [SkippableFact, TestPriority(20)]
    public async Task Lists_Variants()
    {
        var productResponse = await _service.Product.ListProductsAsync(limit: 1);
        var product = productResponse.Result.Products.First();
        var response = await _service.ProductVariant.ListProductVariantsAsync(product.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var productVariant in response.Result.Variants)
            _additionalPropertiesHelper.CheckAdditionalProperties(productVariant, Fixture.MyShopifyUrl);
        Skip.If(!response.Result.Variants.Any());
    }

    
    [SkippableFact, TestPriority(20)]
    public async Task Gets_Variants()
    {
        var productResponse = await _service.Product.ListProductsAsync(limit: 1);
        var product = productResponse.Result.Products.First();
        var variant = product.Variants?.First();
        Skip.If(variant == null, "Not a valid variant for testing.");
        var response = await _service.ProductVariant.GetProductVariantAsync(variant.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
            _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Variant, Fixture.MyShopifyUrl);
    }
    #endregion Read

    #region Update
    /*
    [SkippableFact, TestPriority(30)]
    public async Task Updates_Variants()
    {
        decimal newPrice = (decimal)11.22;
        var created = await Fixture.Create();
        long id = created.Id.Value;

        created.Price = newPrice;
        created.Id = null;
        // Must set variant.InventoryQuantity to null as it is now read-only. Sending the quantity accidentally will result in an exception.
        created.InventoryQuantity = null;

        var updated = await Fixture.Service.UpdateAsync(id, created);

        // Reset the id so the Fixture can properly delete this object.
        created.Id = id;

        Assert.Equal(newPrice, updated.Price);
    }
    */
    #endregion Update

    #region Delete
    /*
    [SkippableFact, TestPriority(40)]
    public async Task Deletes_Variants()
    {
        var created = await Fixture.Create(skipAddToCreatedList: true);
        bool threw = false;

        try
        {
            await Fixture.Service.DeleteAsync(Fixture.ProductId, created.Id.Value);
        }
        catch (ShopifyException ex)
        {
            Console.WriteLine($"{nameof(Deletes_Variants)} failed. {ex.Message}");

            threw = true;
        }

        Assert.False(threw);
    }
    */
    #endregion Delete
}
