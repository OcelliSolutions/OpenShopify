namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;

public class FulfillmentEventFixture : SharedFixture, IAsyncLifetime
{
    public FulfillmentService FulfillmentService = new();
    public Product Product = new();
    public ProductVariant ProductVariant = new();
    public List<Order> CreatedOrders = new();
    public List<Fulfillment> CreatedFulfillments = new();
    public List<FulfillmentOrder> CreatedFulfillmentOrders = new();
    public List<FulfillmentEvent> CreatedFulfillmentEvents = new();
    public IShippingAndFulfillmentService Service;

    public FulfillmentEventFixture() =>
        Service = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync()
    {
        FulfillmentService = await CreateFulfillmentService();
        Product = await CreateProduct(FulfillmentService);
        ProductVariant = Product.Variants!.First(v => v.FulfillmentService != null);
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteFulfillmentEventAsync_CanDelete();

        var orderService = new OrdersService(MyShopifyUrl, AccessToken);
        foreach (var order in CreatedOrders)
        {
            await orderService.Order.DeleteOrderAsync(order.Id);
        }

        var productService = new ProductsService(MyShopifyUrl, AccessToken);
        if (Product.Id > 0)
        {
            await productService.Product.DeleteProductAsync(Product.Id);
        }
        
        if (FulfillmentService.Id > 0)
        {
            await Service.FulfillmentService.DeleteFulfillmentServiceAsync(FulfillmentService.Id);
        }
    }
    
    public async Task DeleteFulfillmentEventAsync_CanDelete()
    {
        foreach (var fulfillmentEvent in CreatedFulfillmentEvents)
        {
            _ = await Service.FulfillmentEvent.DeleteFulfillmentEventAsync(fulfillmentEvent.Id,
                fulfillmentEvent.FulfillmentId ?? 0, fulfillmentEvent.OrderId ?? 0, CancellationToken.None);
        }
        CreatedFulfillmentEvents.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("FulfillmentEventTests")]
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
        var order = await Fixture.CreateOrder(Fixture.ProductVariant);
        Fixture.CreatedOrders.Add(order);
        var sendFulfillmentResponse = await Fixture.SendFulfillmentRequest(order);

        var submittedFulfillmentOrder = sendFulfillmentResponse.SubmittedFulfillmentOrder;

        var acceptFulfillment = await Fixture.Service.FulfillmentRequest.AcceptFulfillmentRequestAsync(
            submittedFulfillmentOrder?.Id ?? 0,
            new AcceptFulfillmentRequestRequest() { FulfillmentRequest = new MessageDetail() { Message = "We will start processing your fulfillment on the next business day." } });

        var acceptedResponse = acceptFulfillment.Result.FulfillmentOrder;

        var fulfillmentOrder = new FulfillmentOrder()
        {
            Id = acceptedResponse.Id,
            OrderId = acceptedResponse.OrderId,
            AssignedLocationId = acceptedResponse.Id, 
            LineItems = acceptedResponse.LineItems
        };

        var createFulfillmentRequest = Fixture.CreateFulfillmentRequest(fulfillmentOrder, Fixture.FulfillmentService);
        var fulfillmentResponse = await Fixture.Service.Fulfillment.CreateFulfillmentForOneOrManyFulfillmentOrdersAsync(createFulfillmentRequest, CancellationToken.None);

        var fulfillment = fulfillmentResponse.Result.Fulfillment;
        var request = new CreateFulfillmentEventRequest
        {
            Event = new CreateFulfillmentEvent
            {
                Status = FulfillmentEventStatus.InTransit
            }
        };
        var response = await Fixture.Service.FulfillmentEvent.CreateFulfillmentEventAsync(fulfillment.Id,
            fulfillment.OrderId ?? 0, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedFulfillmentEvents.Add(response.Result.FulfillmentEvent);
    }
    /*
    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateFulfillmentEventAsync_IsUnprocessableEntityError()
    {
        var order = await Fixture.CreateOrder(Fixture.ProductVariant);
        Fixture.CreatedArticles.Add(order);
        var fulfillment = await Fixture.CreateFulfillment(order, Fixture.FulfillmentService);
        Fixture.CreatedFulfillments.Add(fulfillment);
        var request = new CreateFulfillmentEventRequest
        {
            FulfillmentEvent = new CreateFulfillmentEvent()
        };
        await Assert.ThrowsAsync<ApiException>(async () =>
            await Fixture.Service.FulfillmentEvent.CreateFulfillmentEventAsync(fulfillment.Id, fulfillment.OrderId ?? 0,
                request, CancellationToken.None));
    }
    */
    #endregion Create

    #region Read
    
    [SkippableFact]
    [TestPriority(20)]
    public async Task ListFulfillmentEventsAsync_AdditionalPropertiesAreEmpty()
    {
        var order = await Fixture.CreateOrder(Fixture.ProductVariant);
        Fixture.CreatedOrders.Add(order);
        var fulfillmentOrders = await Fixture.GetFulfillmentOrders(order);
        var fulfillmentOrder = fulfillmentOrders.First();
        var sendFulfillmentResponse = await Fixture.SendFulfillmentRequest(order);

        var submittedFulfillmentOrder = sendFulfillmentResponse.SubmittedFulfillmentOrder;

        var acceptFulfillment = await Fixture.Service.FulfillmentRequest.AcceptFulfillmentRequestAsync(
            submittedFulfillmentOrder?.Id ?? 0,
            new AcceptFulfillmentRequestRequest() { FulfillmentRequest = new MessageDetail() { Message = "We will start processing your fulfillment on the next business day." } });

        var createFulfillmentRequest = Fixture.CreateFulfillmentRequest(fulfillmentOrder, Fixture.FulfillmentService);
        var fulfillmentResponse = await Fixture.Service.Fulfillment.CreateFulfillmentForOneOrManyFulfillmentOrdersAsync(createFulfillmentRequest, CancellationToken.None);

        var fulfillment = fulfillmentResponse.Result.Fulfillment;

        var response =
            await Fixture.Service.FulfillmentEvent.ListFulfillmentEventsForSpecificFulfillmentAsync(
                fulfillment.Id, fulfillment.OrderId ?? 0, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var fulfillmentEvent in response.Result.FulfillmentEvents)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(fulfillmentEvent, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.FulfillmentEvents.Any(), "No results returned. Unable to test");
    }
    /*
    [SkippableFact]
    [TestPriority(20)]
    public async Task GetFulfillmentEventAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        var order = await Fixture.CreateOrder(Fixture.ProductVariant);
        Fixture.CreatedArticles.Add(order);
        var fulfillment = await Fixture.CreateFulfillment(order, Fixture.FulfillmentService);
        Fixture.CreatedFulfillments.Add(fulfillment);

        var fulfillmentEvent = Fixture.CreatedFulfillmentEvents.First();
        var response =
            await Fixture.Service.FulfillmentEvent.GetFulfillmentEventAsync(fulfillmentEvent.Id, fulfillmentEvent.FulfillmentId ?? 0,
                fulfillmentEvent.OrderId ?? 0, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentEvent, Fixture.MyShopifyUrl);
    }
    */
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
