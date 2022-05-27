using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.SalesChannels;

public class ProductListingFixture : SharedFixture, IAsyncLifetime
{
    public SalesChannelsService Service;
    public List<ProductListing> CreatedProductListings = new();

    public ProductListingFixture()
    {
        Service = new SalesChannelsService(MyShopifyUrl, AccessToken);
    }
    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteProductListingAsync_CanDelete();
    }
    
    public async Task DeleteProductListingAsync_CanDelete()
    {
        foreach (var productListing in CreatedProductListings)
        {
            _ = await Service.ProductListing.DeleteProductListingAsync(productListing.Id);
        }
        CreatedProductListings.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ProductListingTests : IClassFixture<ProductListingFixture>
{
    private ProductListingFixture Fixture { get; }
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
        

    public ProductListingTests(ProductListingFixture fixture, ITestOutputHelper testOutputHelper)
    {
                Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
            }
    /*
    
    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task CountProductsThatArePublishedToYourAppAsync_CanGet()
    {
        var response = await Fixture.Service.ProductListing.CountProductsThatArePublishedToYourAppAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListProductListingsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.ProductListing.list();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var productListing in response.Result.ProductListings)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(productListing, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.ProductListings.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetProductListingAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedProductListings.Any(), "Must be run with create test");
        var productListing = Fixture.CreatedProductListings.First();
        var response = await Fixture.Service.ProductListing.GetProductListingAsync(productListing.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.ProductListing, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    [SkippableFact, TestPriority(30)]
    public async Task UpdateProductListingAsync_CanUpdate()
    {
        var originalProductListing = Fixture.CreatedProductListings.First();
        var request = new UpdateProductListingRequest()
        {
            ProductListing = new()
            {
                Id = originalProductListing.Id,
                Fields = new List<string> { "id" }
            }
        };
        var response = await Fixture.Service.ProductListing.UpdateProductListingAsync(request.ProductListing.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedProductListings.Remove(originalProductListing);
        Fixture.CreatedProductListings.Add(response.Result.ProductListing);
    }

    #endregion Update
    */

    #region Delete

    [SkippableFact, TestPriority(99)]
    public async Task DeleteProductListingAsync_CanDelete()
    {
        await Fixture.DeleteProductListingAsync_CanDelete();
    }

    #endregion Delete
    }