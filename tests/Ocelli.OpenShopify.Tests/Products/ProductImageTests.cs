using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Products;

public class ProductImageFixture : SharedFixture, IAsyncLifetime
{
    public List<ProductImage> CreatedProductImages = new();
    public Product Product = new();
    public ProductsService Service;

    public ProductImageFixture() =>
        Service = new ProductsService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync()
    {
        await CreateProduct();
    }

    public async Task CreateProduct()
    {
        var request = CreateProductRequest();
        var response = await Service.Product.CreateProductAsync(request);
        Product = response.Result.Product;
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteProductImageAsync_CanDelete();

        if (Product.Id > 0)
        {
            await Service.Product.DeleteProductAsync(Product.Id);
        }
    }
    
    public async Task DeleteProductImageAsync_CanDelete()
    {
        foreach (var productImage in CreatedProductImages)
        {
            _ = await Service.ProductImage.DeleteProductImageAsync(productImage.Id, Product.Id);
        }
        CreatedProductImages.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ProductImageTests : IClassFixture<ProductImageFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public ProductImageTests(ProductImageFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private ProductImageFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateProductImageAsync_CanUpdate()
    {
        var originalProductImage = Fixture.CreatedProductImages.First();
        var request = new UpdateProductImageRequest
        {
            Image = new UpdateProductImage
            {
                Id = originalProductImage.Id,
                Position = 2,
                Alt = Fixture.UniqueString()
            }
        };
        var response = await Fixture.Service.ProductImage.UpdateProductImageAsync(originalProductImage.Id,
            Fixture.Product.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedProductImages.Remove(originalProductImage);
        Fixture.CreatedProductImages.Add(response.Result.Image);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateProductImageAsync_CanCreate()
    {
        var request = Fixture.CreateProductImageRequest();
        var response = await Fixture.Service.ProductImage.CreateProductImageAsync(Fixture.Product.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedProductImages.Add(response.Result.Image);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateProductImageAsync_IsUnprocessableEntityError()
    {
        var request = new CreateProductImageRequest
        {
            Image = new CreateProductImage()
            {
                Attachment = string.Empty
            }
        };
        await Assert.ThrowsAsync<ApiException<ProductImageError>>(async () =>
            await Fixture.Service.ProductImage.CreateProductImageAsync(Fixture.Product.Id, request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountProductImagesAsync_CanGet()
    {
        var response = await Fixture.Service.ProductImage.CountProductImagesAsync(Fixture.Product.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListProductImagesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.ProductImage.ListProductImagesAsync(Fixture.Product.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var productImage in response.Result.Images)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(productImage, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Images.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetProductImageAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedProductImages.Any(), "Must be run with create test");
        var productImage = Fixture.CreatedProductImages.First();
        var response =
            await Fixture.Service.ProductImage.GetProductImageAsync(productImage.Id, Fixture.Product.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Image, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete


    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteProductImageAsync_CanDelete()
    {
        await Fixture.DeleteProductImageAsync_CanDelete();
    }

    #endregion Delete
    }