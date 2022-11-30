namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;
public class FulfillmentRequestFixture : SharedFixture, IAsyncLifetime
{
    public IShippingAndFulfillmentService Service;
    public FulfillmentService FulfillmentService = new();
    public Product Product = new();
    public ProductVariant ProductVariant = new();
    public List<Order> CreatedOrders = new ();

    public FulfillmentRequestFixture()
    {
        Service = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);
    }
    public async Task InitializeAsync()
    {
        FulfillmentService = await CreateFulfillmentService();
        Product = await CreateProduct(FulfillmentService);
        ProductVariant = Product.Variants!.First(v => v.FulfillmentService != null);
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        foreach (var order in CreatedOrders)
        {
            var orderService = new OrdersService(MyShopifyUrl, AccessToken);
            await orderService.Order.DeleteOrderAsync(order.Id);
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
}


 //TODO: this is non-standard and will require more work.
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("FulfillmentRequestTests")]
public class FulfillmentRequestTests : IClassFixture<FulfillmentRequestFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly FulfillmentRequestMockClient _badRequestMockClient;
    private readonly FulfillmentRequestMockClient _okEmptyMockClient;
    private readonly FulfillmentRequestMockClient _okInvalidJsonMockClient;

    public FulfillmentRequestTests(FulfillmentRequestFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new FulfillmentRequestMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new FulfillmentRequestMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new FulfillmentRequestMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private FulfillmentRequestFixture Fixture { get; }
    private readonly ITestOutputHelper _testOutputHelper;

    [SkippableFact, TestPriority(10)]
    public async Task SendFulfillmentRequestAsync_CanCreate()
    {
        var order = await Fixture.CreateOrder(Fixture.ProductVariant);
        Fixture.CreatedOrders.Add(order);
        var response = await Fixture.SendFulfillmentRequest(order);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        var originalFulfillmentOrder = response.OriginalFulfillmentOrder;
        var submittedFulfillmentOrder = response.SubmittedFulfillmentOrder;
        var unsubmittedFulfillmentOrder = response.UnsubmittedFulfillmentOrder;

        Assert.Equal(FulfillmentOrderRequestStatus.Submitted, submittedFulfillmentOrder?.RequestStatus);
        Assert.Equal(FulfillmentOrderStatus.Open, submittedFulfillmentOrder?.Status);
        Assert.Null(unsubmittedFulfillmentOrder); //no line items were specified, so there is nothing unsubmitted.
    }

    [SkippableFact, TestPriority(11)]
    public async Task AcceptFulfillmentRequestAsync_CanCreate()
    {
        var order = await Fixture.CreateOrder(Fixture.ProductVariant);
        Fixture.CreatedOrders.Add(order);
        var sendFulfillmentResponse = await Fixture.SendFulfillmentRequest(order);
        
        var submittedFulfillmentOrder = sendFulfillmentResponse.SubmittedFulfillmentOrder;

        var response = await Fixture.AcceptFulfillmentRequest(submittedFulfillmentOrder);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Assert.Equal(FulfillmentOrderRequestStatus.Accepted, response.RequestStatus);
        Assert.Equal(FulfillmentOrderStatus.InProgress, response.Status);
    }


    [SkippableFact, TestPriority(12)]
    public async Task RejectFulfillmentRequestAsync_CanCreate()
    {
        var order = await Fixture.CreateOrder(Fixture.ProductVariant);
        Fixture.CreatedOrders.Add(order);
        var sendFulfillmentResponse = await Fixture.SendFulfillmentRequest(order);

        var submittedFulfillmentOrder = sendFulfillmentResponse.SubmittedFulfillmentOrder;

        var response = await Fixture.Service.FulfillmentRequest.RejectFulfillmentRequestAsync(
            submittedFulfillmentOrder?.Id ?? 0,
            new RejectFulfillmentRequestRequest() { FulfillmentRequest = new MessageDetail() { Message = "Not enough inventory on hand to complete the work." } });
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result, Fixture.MyShopifyUrl);

        var acceptedResponse = response.Result.FulfillmentOrder;
        Assert.Equal(FulfillmentOrderRequestStatus.Rejected, acceptedResponse.RequestStatus);
        Assert.Equal(FulfillmentOrderStatus.Open, acceptedResponse.Status);
    }

    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class FulfillmentRequestMockClient : FulfillmentRequestClient, IMockTests
{
    public FulfillmentRequestMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await SendFulfillmentRequestAsync(0, new SendFulfillmentRequestRequest(), CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await SendFulfillmentRequestAsync(0, new SendFulfillmentRequestRequest(), CancellationToken.None));
    }
}

