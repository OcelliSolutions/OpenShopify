using System;
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
    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ProductTests : IClassFixture<ProductFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ProductsService _service;
    private readonly ITestOutputHelper _testOutputHelper;
    
    public ProductTests(ITestOutputHelper testOutputHelper, ProductFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new ProductsService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private ProductFixture Fixture { get; }

    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task CreateProductAsync_CanCreate()
    {
        var request = Fixture.CreateProductRequest;
        var response = await _service.Product.CreateProductAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedProducts.Add(response.Result.Product);
    }

    [SkippableFact, TestPriority(10)]
    public async Task CreateProductAsync_IsUnprocessableEntityError()
    {
        var request = new CreateProductRequest()
        {
            Product = new()
            {
                BodyHtml = "A mystery!"
            }
        };
        await Assert.ThrowsAsync<ApiException<ProductError>>(async () => await _service.Product.CreateProductAsync(request));
    }

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
                if (product.Vendor != null && product.Vendor.Contains(Fixture.Company)
                                            && !Fixture.CreatedProducts.Exists(w => w.Id == product.Id))
                    Fixture.CreatedProducts.Add(product);
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

    [SkippableFact, TestPriority(20)]
    public async Task GetProductAsync_AdditionalPropertiesAreEmpty()
    {
        var productListResponse = await _service.Product.ListProductsAsync(limit: 1);
        Skip.If(!productListResponse.Result.Products.Any(), "No results returned. Unable to test");
        var response = await _service.Product.GetProductAsync(productListResponse.Result.Products.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Product, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetProductAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedProducts.Any(), "No results returned. Unable to test");
        var product = Fixture.CreatedProducts.First();
        var response = await _service.Product.GetProductAsync(product.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Product, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    [SkippableFact, TestPriority(30)]
    public async Task UpdateProductAsync_CanUpdate()
    {
        var originalProduct = Fixture.CreatedProducts.First();
        var request = new UpdateProductRequest()
        {
            Product = new()
            {
                Id = originalProduct.Id, 
                Title = $@"New product title ({Fixture.BatchId})"
            }
        };
        var response = await _service.Product.UpdateProductAsync(request.Product.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedProducts.Remove(originalProduct);
        Fixture.CreatedProducts.Add(response.Result.Product);
    }

    #endregion Update

    #region Delete

    [SkippableFact, TestPriority(40)]
    public async Task DeleteProductAsync_CanDelete()
    {
        Skip.If(Fixture.CreatedProducts.Count == 0, "WARN: No data returned. Could not test");
        var errors = new List<Exception>();
        foreach (var product in Fixture.CreatedProducts)
        {
            try
            {
                _ = await _service.Product.DeleteProductAsync(product.Id);
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
