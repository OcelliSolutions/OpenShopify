using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Products;


public class ProductVariantFixture : SharedFixture, IAsyncLifetime
{
    public Product Product = new();
    public List<ProductVariant> CreatedProductVariants = new();
    
    public async Task InitializeAsync()
    {
        await CreateProduct();
    }

    public async Task CreateProduct()
    {
        var productService = new ProductsService(MyShopifyUrl, AccessToken);
        var request = base.CreateProductRequest;
        var productResponse = await productService.Product.CreateProductAsync(request);
        Product = productResponse.Result.Product;
    }
    async Task IAsyncLifetime.DisposeAsync()
    {
        if (Product.Id > 0)
        {
            var productService = new ProductsService(MyShopifyUrl, AccessToken);
            await productService.Product.DeleteProductAsync(Product.Id);
        }
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ProductVariantTests : IClassFixture<ProductVariantFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ProductsService _service;

    public ProductVariantTests(ITestOutputHelper testOutputHelper, ProductVariantFixture fixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new ProductsService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private ProductVariantFixture Fixture { get; }
    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task CreateProductVariantAsync_CanCreate()
    {
        var request = new CreateProductVariantRequest()
        {
            Variant = new()
            {
                Option1 = "Yellow",
                Price = (decimal)1.00
            }
        };
        var response = await _service.ProductVariant.CreateProductVariantAsync(Fixture.Product.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedProductVariants.Add(response.Result.Variant);
    }

    [SkippableFact, TestPriority(10)]
    public async Task CreateProductVariantAsync_IsUnprocessableEntityError()
    {
        var request = new CreateProductVariantRequest()
        {
            Variant = new()
        };
        await Assert.ThrowsAsync<ApiException<ProductVariantError>>(async () => await _service.ProductVariant.CreateProductVariantAsync(Fixture.Product.Id, request));
    }

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

    [SkippableFact, TestPriority(30)]
    public async Task UpdateProductVariantAsync_CanUpdate()
    {
        var originalProductVariant = Fixture.CreatedProductVariants.First();
        var request = new UpdateProductVariantRequest()
        {
            Variant = new()
            {
                Id = originalProductVariant.Id,
                Option1 = "Not Pink", 
                Price = (decimal)99.00
            }
        };
        var response = await _service.ProductVariant.UpdateProductVariantAsync(request.Variant.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedProductVariants.Remove(originalProductVariant);
        Fixture.CreatedProductVariants.Add(response.Result.Variant);
    }

    #endregion Update

    #region Delete

    [SkippableFact, TestPriority(40)]
    public async Task DeleteProductVariantAsync_CanDelete()
    {
        Skip.If(Fixture.CreatedProductVariants.Count == 0, "WARN: No data returned. Could not test");
        var errors = new List<Exception>();
        foreach (var productVariant in Fixture.CreatedProductVariants)
        {
            try
            {
                _ = await _service.ProductVariant.DeleteProductVariantAsync(productVariant.ProductId ?? 0, productVariant.Id);
            }
            catch (Exception ex)
            {
                errors.Add(ex);
            }
        }

        foreach (var error in errors)
        {
            _testOutputHelper.WriteLine(error.Message);
        }
        Assert.Empty(errors);
    }
    #endregion Delete
}
