namespace Ocelli.OpenShopify.Tests.Inventory;

public class InventoryItemFixture : SharedFixture, IAsyncLifetime
{
    public List<InventoryItem> CreatedInventoryItems = new();
    public List<ProductVariant> ProductVariants = new();
    public IInventoryService Service;

    public InventoryItemFixture() =>
        Service = new InventoryService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync()
    {
        var productService = new ProductsService(MyShopifyUrl, AccessToken);
        var products = await productService.Product.ListProductsAsync();
        foreach (var product in products.Result.Products.Take(1))
        {
            var productVariants = await productService.ProductVariant.ListProductVariantsAsync(product.Id);
            ProductVariants.AddRange(productVariants.Result.Variants);
        }
    }
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("InventoryItemTests")]
public class InventoryItemTests : IClassFixture<InventoryItemFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly InventoryItemMockClient _badRequestMockClient;
    private readonly InventoryItemMockClient _okEmptyMockClient;
    private readonly InventoryItemMockClient _okInvalidJsonMockClient;

    public InventoryItemTests(InventoryItemFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new InventoryItemMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new InventoryItemMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new InventoryItemMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private InventoryItemFixture Fixture { get; }

    //TODO: Figure out how to create an Inventory Item

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateInventoryItemAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedInventoryItems.Any(), "Must be run with create test");
        var originalInventoryItem = Fixture.CreatedInventoryItems.First();
        var request = new UpdateInventoryItemRequest
        {
            InventoryItem = new UpdateInventoryItem
            {
                Id = originalInventoryItem.Id,
                Sku = Fixture.BatchId
            }
        };
        var response = await Fixture.Service.InventoryItem.UpdateInventoryItemAsync(originalInventoryItem.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedInventoryItems.Remove(originalInventoryItem);
        Fixture.CreatedInventoryItems.Add(response.Result.InventoryItem);
    }

    #endregion Update

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListInventoryItemsAsync_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.ProductVariants.Any(), "No available product variants");
        var ids = Fixture.ProductVariants.Where(v => v.InventoryItemId > 0).Select(v => v.InventoryItemId ?? 0);
        var response = await Fixture.Service.InventoryItem.ListInventoryItemsAsync(ids);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var inventoryItem in response.Result.InventoryItems)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(inventoryItem, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.InventoryItems.Any(), "No results returned. Unable to test");
        Fixture.CreatedInventoryItems.AddRange(response.Result.InventoryItems);
    }

    [SkippableFact]
    [TestPriority(21)]
    public async Task GetInventoryItemAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedInventoryItems.Any(), "Must be run with list test");
        var inventoryItem = Fixture.CreatedInventoryItems.First();
        var response = await Fixture.Service.InventoryItem.GetInventoryItemAsync(inventoryItem.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.InventoryItem, Fixture.MyShopifyUrl);
    }

    #endregion Read


    [SkippableFact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class InventoryItemMockClient : InventoryItemClient, IMockTests
{
    public InventoryItemMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListInventoryItemsAsync(new List<long> {0}, 0, "NA"));
        await Assert.ThrowsAsync<ApiException>(async () => await GetInventoryItemAsync(0));
        await Assert.ThrowsAsync<ApiException>(async () => await UpdateInventoryItemAsync(0, new UpdateInventoryItemRequest()));
    }
}
