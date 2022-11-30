namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;
public class FulfillmentFixture : SharedFixture, IAsyncLifetime
{
    public IShippingAndFulfillmentService Service;
    public FulfillmentService FulfillmentService = new();
    public Product Product = new();
    public ProductVariant ProductVariant = new();
    public List<Order> CreatedOrders = new();
    public List<Fulfillment> CreatedFulfillments = new();

    public FulfillmentFixture()
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
        await DeleteFulfillmentAsync_CanDelete();

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

        var fulfillmentService = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);
        if (FulfillmentService.Id > 0)
        {
            await fulfillmentService.FulfillmentService.DeleteFulfillmentServiceAsync(FulfillmentService.Id);
        }
    }

    public async Task DeleteFulfillmentAsync_CanDelete()
    {
        foreach (var fulfillment in CreatedFulfillments)
        {
            _ = await Service.Fulfillment.CancelFulfillmentAsync(fulfillment.Id, CancellationToken.None);
        }
        CreatedFulfillments.Clear();
    }
}

 //TODO: Build Fulfillment tests.
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("FulfillmentTests")]
public class FulfillmentTests : IClassFixture<FulfillmentFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly FulfillmentMockClient _badRequestMockClient;
    private readonly FulfillmentMockClient _okEmptyMockClient;
    private readonly FulfillmentMockClient _okInvalidJsonMockClient;

    public FulfillmentTests(FulfillmentFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new FulfillmentMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new FulfillmentMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new FulfillmentMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private FulfillmentFixture Fixture { get; }

    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task CreateFulfillmentAsync_CanCreate()
    {
        var order = await Fixture.CreateOrder(Fixture.ProductVariant);
        Fixture.CreatedOrders.Add(order);
        var sendFulfillmentResponse = await Fixture.SendFulfillmentRequest(order);

        var submittedFulfillmentOrder = sendFulfillmentResponse.SubmittedFulfillmentOrder;

        var acceptFulfillment = await Fixture.Service.FulfillmentRequest.AcceptFulfillmentRequestAsync(
            submittedFulfillmentOrder?.Id ?? 0,
            new AcceptFulfillmentRequestRequest() { FulfillmentRequest = new MessageDetail() { Message = "We will start processing your fulfillment on the next business day." } });
        _additionalPropertiesHelper.CheckAdditionalProperties(acceptFulfillment, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(acceptFulfillment.Result, Fixture.MyShopifyUrl);

        var acceptedResponse = acceptFulfillment.Result.FulfillmentOrder;

        var fulfillmentOrder = new FulfillmentOrder()
        {
            Id = acceptedResponse?.Id ?? 0,
            OrderId = acceptedResponse?.OrderId,
            AssignedLocationId = acceptedResponse?.Id,
            LineItems = acceptedResponse?.LineItems
        };
        var request = Fixture.CreateFulfillmentRequest(fulfillmentOrder, Fixture.FulfillmentService);
        var response = await Fixture.Service.Fulfillment.CreateFulfillmentForOneOrManyFulfillmentOrdersAsync(request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedFulfillments.Add(response.Result.Fulfillment);
    }

    /*
    [SkippableFact, TestPriority(10)]
    public async Task CreateFulfillmentAsync_IsUnprocessableEntityError()
    {
        var request = new CreateFulfillmentForOneOrManyFulfillmentOrdersRequest()
        {
            Fulfillment = new()
        };
        await Assert.ThrowsAsync<ApiException>(async () => await Fixture.Service.Fulfillment.CreateFulfillmentForOneOrManyFulfillmentOrdersAsync(request));
    }
    */
    #endregion Create

    /*
    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task CountFulfillmentsAsync_CanGet()
    {
        var response = await Fixture.Service.Fulfillment.CountFulfillmentsAssociatedWithSpecificOrderAsync(Fixture.Order.Id, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListFulfillmentsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Fulfillment.ListFulfillmentsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var fulfillment in response.Result.Fulfillments)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(fulfillment, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.Fulfillments.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetFulfillmentAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedFulfillments.Any(), "Must be run with create test");
        var fulfillment = Fixture.CreatedFulfillments.First();
        var response = await Fixture.Service.Fulfillment.GetFulfillmentAsync(fulfillment.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Fulfillment, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    [SkippableFact, TestPriority(30)]
    public async Task UpdateFulfillmentAsync_CanUpdate()
    {
        var originalFulfillment = Fixture.CreatedFulfillments.First();
        var request = new UpdateFulfillmentRequest()
        {
            Fulfillment = new()
            {
                Id = originalFulfillment.Id,
                Fields = new List<string> { "id" }
            }
        };
        var response = await Fixture.Service.Fulfillment.UpdateFulfillmentAsync(originalFulfillment.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedFulfillments.Remove(originalFulfillment);
        Fixture.CreatedFulfillments.Add(response.Result.Fulfillment);
    }

    #endregion Update
    */

    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class FulfillmentMockClient : FulfillmentClient, IMockTests
{
    public FulfillmentMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await CountFulfillmentsAssociatedWithSpecificOrderAsync(0, cancellationToken: CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await CountFulfillmentsAssociatedWithSpecificOrderAsync(0, cancellationToken: CancellationToken.None));
    }
}
