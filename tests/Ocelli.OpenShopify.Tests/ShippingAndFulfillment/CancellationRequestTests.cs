namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;

public class CancellationRequestFixture : SharedFixture, IAsyncLifetime
{
    public IShippingAndFulfillmentService Service;
    public FulfillmentService FulfillmentService = new();
    public Product Product = new();
    public ProductVariant ProductVariant = new();
    public FulfillmentOrder FulfillmentOrder = new();
    public IEnumerable<Order> Orders = new List<Order>();

    public CancellationRequestFixture()
    {
        Service = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);
    }
    public async Task InitializeAsync()
    {
        FulfillmentService = await CreateFulfillmentService(GetType().Name);
        Product = await CreateProduct(FulfillmentService, GetType().Name);
        ProductVariant = Product.Variants!.First(v => v.FulfillmentService != null);
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        if (Orders.Any())
        {
            foreach (var order in Orders)
            {
                var orderService = new OrdersService(MyShopifyUrl, AccessToken);
                await orderService.Order.DeleteOrderAsync(order.Id);
            }
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

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("CancellationRequestTests")]
public class CancellationRequestTests : IClassFixture<CancellationRequestFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly CancellationRequestMockClient _badRequestMockClient;
    private readonly CancellationRequestMockClient _okEmptyMockClient;
    private readonly CancellationRequestMockClient _okInvalidJsonMockClient;

    public CancellationRequestTests(CancellationRequestFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new CancellationRequestMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new CancellationRequestMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new CancellationRequestMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private CancellationRequestFixture Fixture { get; }

    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task SendCancellationRequestAsync_CanCreate()
    {
        var order = await Fixture.CreateOrder(Fixture.ProductVariant, GetType().Name);
        var fulfillmentOrders = await Fixture.GetFulfillmentOrders(order);
        var fulfillmentOrder = fulfillmentOrders.First();
        //Fixture.Service.FulfillmentRequest.AcceptFulfillmentRequestAsync(fulfillmentOrder.Id,new AcceptFulfillmentRequestRequest() { });
        var request = new SendCancellationRequestRequest()
        {
            CancellationRequest = new MessageDetail()
            {
                Message = $@"@{Fixture.BatchId}, Please wrap in yellow paper."
            }
        };
        var response =
            await Fixture.Service.CancellationRequest.SendCancellationRequestAsync(fulfillmentOrder.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result, Fixture.MyShopifyUrl);

        //Assert.Equal(FulfillmentOrderStatus.Scheduled, response.Result.FulfillmentOrder.Status);
        Assert.Equal(RequestStatus.CancellationRequested, response.Result.FulfillmentOrder.RequestStatus);
    }
    /*
    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCancellationRequestAsync_EmptyBody_IsError()
    {
        var request = new CreateCancellationRequestRequest
        {
            CancellationRequest = new CreateCancellationRequest()
        };
        await Assert.ThrowsAsync<ApiException<CancellationRequestError>>(async () =>
            await Fixture.Service.CancellationRequest.CreateCancellationRequestAsync(request));
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCancellationRequestAsync_IsUnprocessableEntityError()
    {
        var request = new CreateCancellationRequestRequest
        {
            CancellationRequest = new CreateCancellationRequest()
            {
                Topic = CancellationRequestTopic.AppUninstalled
            }
        };
        await Assert.ThrowsAsync<ApiException<CancellationRequestError>>(async () =>
            await Fixture.Service.CancellationRequest.CreateCancellationRequestAsync(request));
    }

    */
    #endregion Create


    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class CancellationRequestMockClient : CancellationRequestClient, IMockTests
{
    public CancellationRequestMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await SendCancellationRequestAsync(0,new SendCancellationRequestRequest(), CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await SendCancellationRequestAsync(0, new SendCancellationRequestRequest(), CancellationToken.None));
    }
}
