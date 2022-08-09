namespace Ocelli.OpenShopify.Tests.Inventory;
public class InventoryLevelFixture : SharedFixture, IAsyncLifetime
{
    public IInventoryService Service;
    public InventoryItem InventoryItem = new();
    public Location Location = new();
    public List<InventoryLevel> CreatedInventoryLevels = new();
    public List<FulfillmentService> CreatedFulfillmentServices = new();
    public List<Product> CreatedProducts = new();
    public List<ProductVariant> ProductVariants = new();

    public InventoryLevelFixture() => Service = new InventoryService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync()
    {
        var fulfillmentService = await CreateFulfillmentService();
        CreatedFulfillmentServices.Add(fulfillmentService);
        var productService = new ProductsService(MyShopifyUrl, AccessToken);
        var product = await CreateProduct(fulfillmentService);
        CreatedProducts.Add(product);
        var productVariants = await productService.ProductVariant.ListProductVariantsAsync(product.Id);
        ProductVariants.AddRange(productVariants.Result.Variants);
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        //await DeleteInventoryLevelAsync_CanDelete();
        await DeleteProductAsync_CanDelete();
        await DeleteFulfillmentServiceAsync_CanDelete();
    }

    public async Task DeleteFulfillmentServiceAsync_CanDelete()
    {
        var shippingAndFulfillmentService = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);
        foreach (var fulfillmentService in CreatedFulfillmentServices)
        {
            _ = await shippingAndFulfillmentService.FulfillmentService.DeleteFulfillmentServiceAsync(fulfillmentService.Id, CancellationToken.None);
        }
        CreatedFulfillmentServices.Clear();
    }

    public async Task DeleteInventoryLevelAsync_CanDelete()
    {
        foreach (var inventoryLevel in CreatedInventoryLevels.Take(1))
        {
            _ = await Service.InventoryLevel.DeleteInventoryLevelFromLocationAsync(inventoryLevel.InventoryItemId, inventoryLevel.LocationId ?? 0, CancellationToken.None);
        }
        CreatedInventoryLevels.Clear();
    }
    public async Task DeleteProductAsync_CanDelete()
    {
        var productService = new ProductsService(MyShopifyUrl, AccessToken);
        foreach (var product in CreatedProducts)
        {
            _ = await productService.Product.DeleteProductAsync(product.Id, CancellationToken.None);
        }
        CreatedProducts.Clear();
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
        var inventoryItemIds = Fixture.ProductVariants.Where(v => v.InventoryItemId > 0).Select(v => v.InventoryItemId ?? 0 ).Take(50);
        var response = await Fixture.Service.InventoryLevel.ListInventoryLevelsAsync(inventoryItemIds, cancellationToken: CancellationToken.None);
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
        var productVariant = Fixture.ProductVariants.First();
        var fulfillmentService =
            Fixture.CreatedFulfillmentServices.First(fs => fs.Handle == productVariant.FulfillmentService);
        var request = new AdjustInventoryLevelOfInventoryItemAtLocationRequest()
            {
                InventoryItemId = productVariant.InventoryItemId ?? 0,
                LocationId = fulfillmentService.LocationId ?? 0, 
                AvailableAdjustment = 2
            };
            var response = await Fixture.Service.InventoryLevel.AdjustInventoryLevelOfInventoryItemAtLocationAsync(request, CancellationToken.None);
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
            var response = await Fixture.Service.InventoryLevel.ConnectInventoryItemToLocationAsync(request, CancellationToken.None);
            _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
    }

        [SkippableFact, TestPriority(32)]
        public async Task SetInventoryLevelForInventoryItemAtLocationAsync_CanUpdate()
        {
            var productVariant = Fixture.ProductVariants.First();
            var fulfillmentService =
                Fixture.CreatedFulfillmentServices.First(fs => fs.Handle == productVariant.FulfillmentService);
            var request = new SetInventoryLevelForInventoryItemAtLocationRequest()
            {
                InventoryItemId = productVariant.InventoryItemId ?? 0,
                LocationId = fulfillmentService.LocationId ?? 0,
                Available = 23
            };
            var response = await Fixture.Service.InventoryLevel.SetInventoryLevelForInventoryItemAtLocationAsync(request, CancellationToken.None);
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
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

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
            async () => await ListInventoryLevelsAsync(new List<long> { 0 }, 0, "NA", cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () =>
            await AdjustInventoryLevelOfInventoryItemAtLocationAsync(
                new AdjustInventoryLevelOfInventoryItemAtLocationRequest(), CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () =>
            await ConnectInventoryItemToLocationAsync(new ConnectInventoryItemToLocationRequest(), CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () =>
            await SetInventoryLevelForInventoryItemAtLocationAsync(
                new SetInventoryLevelForInventoryItemAtLocationRequest(), CancellationToken.None));
        
        ReadResponseAsString = false;
        await Assert.ThrowsAsync<ApiException>(
            async () => await ListInventoryLevelsAsync(new List<long> { 0 }, 0, "NA", cancellationToken: CancellationToken.None));
    }
}
