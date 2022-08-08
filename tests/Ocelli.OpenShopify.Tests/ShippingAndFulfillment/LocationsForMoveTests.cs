namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;
public class LocationsForMoveFixture : SharedFixture, IAsyncLifetime
{
    public IShippingAndFulfillmentService Service;
    public Product Product = new();
    public Order Order = new();
    public FulfillmentOrder FulfillmentOrder = new();
    public List<LocationsForMove> CreatedLocationsForMoves = new();

    public LocationsForMoveFixture()
    {
        Service = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);
    }

    public async Task InitializeAsync()
    {
        Product = await CreateProduct();
        Order = await CreateOrder(Product.Variants!.First());
        var fulfillmentOrders = await GetFulfillmentOrders(Order);
        FulfillmentOrder = fulfillmentOrders.First();
    }

    public async Task DisposeAsync()
    {
        if (Order.Id > 0)
        {
            var orderService = new OrdersService(MyShopifyUrl, AccessToken);
            await orderService.Order.DeleteOrderAsync(Order.Id);
        }
        if (Product.Id > 0)
        {
            var productService = new ProductsService(MyShopifyUrl, AccessToken);
            await productService.Product.DeleteProductAsync(Product.Id);
        }
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("LocationsForMoveTests")]
public class LocationsForMoveTests : IClassFixture<LocationsForMoveFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly LocationsForMoveMockClient _badRequestMockClient;
    private readonly LocationsForMoveMockClient _okEmptyMockClient;
    private readonly LocationsForMoveMockClient _okInvalidJsonMockClient;

    public LocationsForMoveTests(LocationsForMoveFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new LocationsForMoveMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new LocationsForMoveMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new LocationsForMoveMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private LocationsForMoveFixture Fixture { get; }
    
    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task ListLocationsForMovesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.LocationsForMove.ListLocationsThatFulfillmentOrderCanPotentiallyMoveToAsync(Fixture.FulfillmentOrder.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var locationsForMove in response.Result.LocationsForMove)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(locationsForMove, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.LocationsForMove.Any(), "No results returned. Unable to test");
    }

    #endregion Read


    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class LocationsForMoveMockClient : LocationsForMoveClient, IMockTests
{
    public LocationsForMoveMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        //TODO: Validate that all methods are tested in this first section
        await Assert.ThrowsAsync<ApiException>(async () => await ListLocationsThatFulfillmentOrderCanPotentiallyMoveToAsync(0, CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListLocationsThatFulfillmentOrderCanPotentiallyMoveToAsync(0, CancellationToken.None));
    }
}

