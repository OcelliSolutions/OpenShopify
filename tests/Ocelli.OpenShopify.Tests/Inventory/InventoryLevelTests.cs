namespace Ocelli.OpenShopify.Tests.Inventory;
public class InventoryLevelFixture : SharedFixture, IAsyncLifetime
{
    public IInventoryService Service;
    public InventoryItem InventoryItem = new();
    public Location Location = new();
    public FulfillmentService FulfillmentService = new();
    public Product Product = new();
    public ProductVariant ProductVariant = new();
    public List<InventoryLevel> CreatedInventoryLevels = new();

    public InventoryLevelFixture() => Service = new InventoryService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync()
    {
        FulfillmentService = await CreateFulfillmentService();
        Product = await CreateProduct(FulfillmentService);
        ProductVariant = Product.Variants!.First(v => v.FulfillmentService != null);
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        if (Product.Id > 0)
        {
            var productService = new ProductsService(MyShopifyUrl, AccessToken);
            await productService.Product.DeleteProductAsync(Product.Id);
        }

        if (FulfillmentService.Id > 0)
        {
            var fulfillmentService = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);
            await fulfillmentService.FulfillmentService.DeleteFulfillmentServiceAsync(FulfillmentService.Id);
        }
    }

    public async Task DeleteInventoryLevelAsync_CanDelete()
    {
        foreach (var inventoryLevel in CreatedInventoryLevels.Take(1))
        {
            var productService = new ProductsService(MyShopifyUrl, AccessToken);
            var request = new UpdateProductVariantRequest() { Variant = new() { InventoryPolicy = "continue" } };
            await productService.ProductVariant.UpdateProductVariantAsync(ProductVariant.Id, request);

            _ = await Service.InventoryLevel.DeleteInventoryLevelFromLocationAsync(inventoryLevel.InventoryItemId, inventoryLevel.LocationId ?? 0, CancellationToken.None);
        }
        CreatedInventoryLevels.Clear();
    }

}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("InventoryLevelTests")]
public class InventoryLevelTests : IClassFixture<InventoryLevelFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly InventoryLevelMockClient _badRequestMockClient;
    private readonly InventoryLevelMockClient _okEmptyMockClient;
    private readonly InventoryLevelMockClient _okInvalidJsonMockClient;

    public InventoryLevelTests(InventoryLevelFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new InventoryLevelMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new InventoryLevelMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new InventoryLevelMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private InventoryLevelFixture Fixture { get; }

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task ListInventoryLevelsAsync_AdditionalPropertiesAreEmpty()
    {
        var inventoryItemIds = new List<long>() { Fixture.ProductVariant.InventoryItemId ?? 0 };
        var response =
            await Fixture.Service.InventoryLevel.ListInventoryLevelsAsync(inventoryItemIds,
                cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var inventoryLevel in response.Result.InventoryLevels)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(inventoryLevel, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.InventoryLevels.Any(), "No results returned. Unable to test");
        Fixture.CreatedInventoryLevels.AddRange(response.Result.InventoryLevels);
    }

    #endregion Read

    #region Update

    [SkippableFact, TestPriority(30)]
    public async Task AdjustInventoryLevelOfInventoryItemAtLocationAsync_CanUpdate()
    {
        var request = new AdjustInventoryLevelOfInventoryItemAtLocationRequest()
        {
            InventoryItemId = Fixture.ProductVariant.InventoryItemId ?? 0,
            LocationId = Fixture.FulfillmentService.LocationId ?? 0,
            AvailableAdjustment = 2
        };
        var response =
            await Fixture.Service.InventoryLevel.AdjustInventoryLevelOfInventoryItemAtLocationAsync(request,
                CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(31)]
    public async Task ConnectInventoryItemToLocationAsync_CanUpdate()
    {
        var originalInventoryLevel = Fixture.CreatedInventoryLevels.First();
        var request = new ConnectInventoryItemToLocationRequest()
        {
            InventoryItemId = originalInventoryLevel.InventoryItemId,
            LocationId = originalInventoryLevel.LocationId ?? 0,
            RelocateIfNecessary = true
        };
        var response =
            await Fixture.Service.InventoryLevel.ConnectInventoryItemToLocationAsync(request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(32)]
    public async Task SetInventoryLevelForInventoryItemAtLocationAsync_CanUpdate()
    {
        var request = new SetInventoryLevelForInventoryItemAtLocationRequest()
        {
            InventoryItemId = Fixture.ProductVariant.InventoryItemId ?? 0,
            LocationId = Fixture.FulfillmentService.LocationId ?? 0,
            Available = 23
        };
        var response =
            await Fixture.Service.InventoryLevel.SetInventoryLevelForInventoryItemAtLocationAsync(request,
                CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        Assert.Equal(request.Available, response.Result.InventoryLevel.Available ?? 0);
    }

    #endregion Update

    #region Delete

    [SkippableFact, TestPriority(99)]
    public async Task DeleteInventoryLevelAsync_CanDelete()
    {
        await Fixture.DeleteInventoryLevelAsync_CanDelete();
    }

    #endregion Delete


    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() =>
        await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class InventoryLevelMockClient : InventoryLevelClient, IMockTests
{
    public InventoryLevelMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnDataAsync()
    {
        ReadResponseAsString = true;
        await Assert.ThrowsAsync<ApiException>(
            async () => await ListInventoryLevelsAsync(new List<long> { 0 }, 0, "NA",
                cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () =>
            await AdjustInventoryLevelOfInventoryItemAtLocationAsync(
                new AdjustInventoryLevelOfInventoryItemAtLocationRequest(), CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () =>
            await ConnectInventoryItemToLocationAsync(new ConnectInventoryItemToLocationRequest(),
                CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () =>
            await SetInventoryLevelForInventoryItemAtLocationAsync(
                new SetInventoryLevelForInventoryItemAtLocationRequest(), CancellationToken.None));

        ReadResponseAsString = false;
        await Assert.ThrowsAsync<ApiException>(
            async () => await ListInventoryLevelsAsync(new List<long> { 0 }, 0, "NA",
                cancellationToken: CancellationToken.None));
    }
}
