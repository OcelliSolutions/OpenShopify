using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Products;

public class ProductFixture : SharedFixture, IAsyncLifetime
{
    public List<Product> CreatedProducts = new();
    public ProductsService Service;

    public ProductFixture() =>
        Service = new ProductsService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync() => await DeleteProductAsync_CanDelete();
    
    public async Task DeleteProductAsync_CanDelete()
    {
        foreach (var product in CreatedProducts)
        {
            _ = await Service.Product.DeleteProductAsync(product.Id);
        }
        CreatedProducts.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ProductTests : IClassFixture<ProductFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;


    public ProductTests(ProductFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private ProductFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateProductAsync_CanUpdate()
    {
        var originalProduct = Fixture.CreatedProducts.First();
        var request = new UpdateProductRequest
        {
            Product = new UpdateProduct
            {
                Id = originalProduct.Id,
                Title = $@"New product title ({Fixture.BatchId})"
            }
        };
        var response = await Fixture.Service.Product.UpdateProductAsync(request.Product.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedProducts.Remove(originalProduct);
        Fixture.CreatedProducts.Add(response.Result.Product);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateProductAsync_CanCreate()
    {
        var request = Fixture.CreateProductRequest();
        var response = await Fixture.Service.Product.CreateProductAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedProducts.Add(response.Result.Product);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateProductAsync_IsUnprocessableEntityError()
    {
        var request = new CreateProductRequest
        {
            Product = new CreateProduct
            {
                BodyHtml = "A mystery!"
            }
        };
        await Assert.ThrowsAsync<ApiException<ProductError>>(async () =>
            await Fixture.Service.Product.CreateProductAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task Lists_Products_NoFilter()
    {
        var response = await Fixture.Service.Product.ListProductsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var product in response.Result.Products)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(product, Fixture.MyShopifyUrl);
            Debug.Assert(product.Variants != null, "product.Variants != null");
            Assert.True(product.Variants.Any());
        }
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task Lists_Products_ComparePagingByCursorAndBySinceId()
    {
        var response = await Fixture.Service.Product.ListProductsAsync(sinceId: 0, limit: 2);

        Assert.True(response.Result.Products.Count == 2);
        Assert.NotNull(response.Pagination.NextPageInfo);
        Assert.True(response.Pagination.HasNextPage);

        var nextPageViaCursor =
            await Fixture.Service.Product.ListProductsAsync(limit: 2, pageInfo: response.Pagination.NextPageInfo);
        Assert.True(nextPageViaCursor.Result.Products.Count == 2);
        Assert.NotNull(nextPageViaCursor.Pagination.NextPageInfo);
        Assert.True(nextPageViaCursor.Pagination.HasNextPage);
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task Lists_Products_PageAll()
    {
        string? pageInfo = null;
        while (true)
        {
            var response = await Fixture.Service.Product.ListProductsAsync(pageInfo: pageInfo);
            _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
            foreach (var product in response.Result.Products)
            {
                _additionalPropertiesHelper.CheckAdditionalProperties(product, Fixture.MyShopifyUrl);
                if (product.Vendor != null && product.Vendor.Contains(Fixture.Company)
                                           && !Fixture.CreatedProducts.Exists(w => w.Id == product.Id))
                {
                    Fixture.CreatedProducts.Add(product);
                }
            }

            if (!response.Pagination.HasNextPage)
            {
                break;
            }
        }
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task List_Products_By_Status()
    {
        var activeResponse = await Fixture.Service.Product.ListProductsAsync(status: "active");
        Assert.True(activeResponse.Result.Products.All(x => x.Status == "active"));

        var draftResponse = await Fixture.Service.Product.ListProductsAsync(status: "draft");
        Assert.True(draftResponse.Result.Products.All(x => x.Status == "draft"));

        var archivedResponse = await Fixture.Service.Product.ListProductsAsync(status: "archived");
        Assert.True(archivedResponse.Result.Products.All(x => x.Status == "archived"));
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetProductAsync_AdditionalPropertiesAreEmpty()
    {
        var productListResponse = await Fixture.Service.Product.ListProductsAsync(limit: 1);
        Skip.If(!productListResponse.Result.Products.Any(), "No results returned. Unable to test");
        var response = await Fixture.Service.Product.GetProductAsync(productListResponse.Result.Products.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Product, Fixture.MyShopifyUrl);
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetProductAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedProducts.Any(), "No results returned. Unable to test");
        var product = Fixture.CreatedProducts.First();
        var response = await Fixture.Service.Product.GetProductAsync(product.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Product, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteProductAsync_CanDelete()
    {
        await Fixture.DeleteProductAsync_CanDelete();
    }

    #endregion
    }