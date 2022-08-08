namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;

public class FulfillmentEventFixture : SharedFixture, IAsyncLifetime
{
    public List<FulfillmentEvent> CreatedFulfillmentEvents = new();
    public Fulfillment Fulfillment = new();
    public FulfillmentService FulfillmentService = new();
    public Order Order = new();
    public Product Product = new();
    public ProductVariant ProductVariant = new();
    public IShippingAndFulfillmentService Service;

    public FulfillmentEventFixture() =>
        Service = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync()
    {
        FulfillmentService = await CreateFulfillmentService();
        Product = await CreateProduct();
        ProductVariant = Product.Variants!.First();
        Order = await CreateOrder(ProductVariant);
        //Fulfillment = await CreateFulfillment(Order, FulfillmentService);
        await GetFulfillment();
    }

    public async Task GetFulfillment()
    {
        var response = await Service.Fulfillment.GetFulfillmentsAssociatedWithOrderAsync(Order.Id);
        if(response.Result.Fulfillments.Any())
            Fulfillment = response.Result.Fulfillments.First();
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteFulfillmentEventAsync_CanDelete();

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

        if (FulfillmentService.Id > 0)
        {
            var fulfillmentService = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);
            await fulfillmentService.FulfillmentService.DeleteFulfillmentServiceAsync(FulfillmentService.Id);
        }
    }
    
    public async Task DeleteFulfillmentEventAsync_CanDelete()
    {
        foreach (var fulfillmentEvent in CreatedFulfillmentEvents)
        {
            _ = await Service.FulfillmentEvent.DeleteFulfillmentEventAsync(fulfillmentEvent.Id, Fulfillment.Id,
                Order.Id, CancellationToken.None);
        }
        CreatedFulfillmentEvents.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("FulfillmentEventTests")]
public class FulfillmentEventTests : IClassFixture<FulfillmentEventFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly FulfillmentEventMockClient _badRequestMockClient;
    private readonly FulfillmentEventMockClient _okEmptyMockClient;
    private readonly FulfillmentEventMockClient _okInvalidJsonMockClient;

    public FulfillmentEventTests(FulfillmentEventFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new FulfillmentEventMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new FulfillmentEventMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new FulfillmentEventMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private FulfillmentEventFixture Fixture { get; }

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateFulfillmentEventAsync_CanCreate()
    {
        var request = new CreateFulfillmentEventRequest
        {
            FulfillmentEvent = new CreateFulfillmentEvent
            {
                Status = FulfillmentEventStatus.InTransit
            }
        };
        var response =
            await Fixture.Service.FulfillmentEvent.CreateFulfillmentEventAsync(Fixture.Fulfillment.Id, Fixture.Order.Id,
                request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedFulfillmentEvents.Add(response.Result.FulfillmentEvent);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateFulfillmentEventAsync_IsUnprocessableEntityError()
    {
        var request = new CreateFulfillmentEventRequest
        {
            FulfillmentEvent = new CreateFulfillmentEvent()
        };
        await Assert.ThrowsAsync<ApiException<FulfillmentEventError>>(async () =>
            await Fixture.Service.FulfillmentEvent.CreateFulfillmentEventAsync(Fixture.Fulfillment.Id, Fixture.Order.Id,
                request, CancellationToken.None));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListFulfillmentEventsAsync_AdditionalPropertiesAreEmpty()
    {
        Skip.If(Fixture.Fulfillment.Id <= 0, "`fulfillment_id` is invalid.");
        Skip.If(Fixture.Fulfillment.OrderId == null , "`order_id` is null.");
        Skip.If(Fixture.Fulfillment.OrderId <= 0, "`order_id` is invalid.");
        var response =
            await Fixture.Service.FulfillmentEvent.ListFulfillmentEventsForSpecificFulfillmentAsync(
                Fixture.Fulfillment.Id, Fixture.Fulfillment.OrderId ?? 0, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var fulfillmentEvent in response.Result.FulfillmentEvents)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(fulfillmentEvent, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.FulfillmentEvents.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetFulfillmentEventAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedFulfillmentEvents.Any(), "Must be run with create test");
        var fulfillmentEvent = Fixture.CreatedFulfillmentEvents.First();
        var response =
            await Fixture.Service.FulfillmentEvent.GetFulfillmentEventAsync(fulfillmentEvent.Id, Fixture.Fulfillment.Id,
                Fixture.Order.Id, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentEvent, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete


    [SkippableFact, TestPriority(99)]
    public async Task DeleteFulfillmentEventAsync_CanDelete()
    {
        await Fixture.DeleteFulfillmentEventAsync_CanDelete();
    }

    #endregion


    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class FulfillmentEventMockClient : FulfillmentEventClient, IMockTests
{
    public FulfillmentEventMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListFulfillmentEventsForSpecificFulfillmentAsync(0, 0, CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListFulfillmentEventsForSpecificFulfillmentAsync(0, 0, CancellationToken.None));
    }
}
