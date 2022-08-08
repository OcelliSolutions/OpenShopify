namespace Ocelli.OpenShopify.Tests.SalesChannels;

public class ProductListingFixture : SharedFixture, IAsyncLifetime
{
    public ISalesChannelsService Service;
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
//[Collection("ProductListingTests")]
public class ProductListingTests : IClassFixture<ProductListingFixture>
{
    private ProductListingFixture Fixture { get; }
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ProductListingMockClient _badRequestMockClient;
    private readonly ProductListingMockClient _okEmptyMockClient;
    private readonly ProductListingMockClient _okInvalidJsonMockClient;

    public ProductListingTests(ProductListingFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new ProductListingMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new ProductListingMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new ProductListingMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    //TODO: Build Product Listing Tests
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


    [SkippableFact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class ProductListingMockClient : ProductListingClient, IMockTests
{
    public ProductListingMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnData()
    {
        ReadResponseAsString = true;
        //TODO: Validate that all methods are tested in this first section
        await Assert.ThrowsAsync<ApiException>(async () => await GetProductListingsAsync());
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await GetProductListingsAsync());
    }
}
