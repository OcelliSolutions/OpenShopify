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
    public List<ProductVariant> CreatedProductVariants = new();
    public Product Product = new();
    public ProductsService Service;

    public ProductVariantFixture() =>
        Service = new ProductsService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync() => await CreateProduct();

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteProductVariantAsync_CanDelete();

        if (Product.Id > 0)
        {
            await Service.Product.DeleteProductAsync(Product.Id);
        }
    }

    public async Task CreateProduct()
    {
        var request = CreateProductRequest();
        var productResponse = await Service.Product.CreateProductAsync(request);
        Product = productResponse.Result.Product;
    }
    
    public async Task DeleteProductVariantAsync_CanDelete()
    {
        foreach (var productVariant in CreatedProductVariants)
        {
            _ = await Service.ProductVariant.DeleteProductVariantAsync(Product.Id, productVariant.Id);
        }
        CreatedProductVariants.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ProductVariantTests : IClassFixture<ProductVariantFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public ProductVariantTests(ProductVariantFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private ProductVariantFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateProductVariantAsync_CanUpdate()
    {
        var originalProductVariant = Fixture.CreatedProductVariants.First();
        var request = new UpdateProductVariantRequest
        {
            Variant = new UpdateProductVariant
            {
                Id = originalProductVariant.Id,
                Option1 = "Not Pink",
                Price = (decimal)99.00
            }
        };
        var response =
            await Fixture.Service.ProductVariant.UpdateProductVariantAsync(originalProductVariant.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedProductVariants.Remove(originalProductVariant);
        Fixture.CreatedProductVariants.Add(response.Result.Variant);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateProductVariantAsync_CanCreate()
    {
        var request = Fixture.CreateProductVariantRequest();
        var response = await Fixture.Service.ProductVariant.CreateProductVariantAsync(Fixture.Product.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedProductVariants.Add(response.Result.Variant);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateProductVariantAsync_IsUnprocessableEntityError()
    {
        var request = new CreateProductVariantRequest
        {
            Variant = new CreateProductVariant()
        };
        await Assert.ThrowsAsync<ApiException<ProductVariantError>>(async () =>
            await Fixture.Service.ProductVariant.CreateProductVariantAsync(Fixture.Product.Id, request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountProductVariantsAsync_CanGet()
    {
        var response = await Fixture.Service.ProductVariant.CountProductVariantsAsync(Fixture.Product.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListProductVariantsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.ProductVariant.ListProductVariantsAsync(Fixture.Product.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var productVariant in response.Result.Variants)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(productVariant, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Variants.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetProductVariantAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedProductVariants.Any(), "Must be run with create test");
        var productVariant = Fixture.CreatedProductVariants.First();
        var response = await Fixture.Service.ProductVariant.GetProductVariantAsync(productVariant.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Variant, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteProductVariantAsync_CanDelete()
    {
        await Fixture.DeleteProductVariantAsync_CanDelete();
    }

    #endregion Delete
    }