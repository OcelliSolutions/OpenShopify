using System;

namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;
public class FulfillmentOrderFixture : SharedFixture, IAsyncLifetime
{
    public IShippingAndFulfillmentService Service;
    public FulfillmentService FulfillmentService = new();
    public Product Product = new();
    public ProductVariant ProductVariant = new();
    public List<Order> CreatedOrders = new();

    public FulfillmentOrderFixture()
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
        var orderService = new OrdersService(MyShopifyUrl, AccessToken);
        foreach (var order in CreatedOrders)
        {
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

 //TODO: This is non-standard and will require some more work.
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("FulfillmentOrderTests")]
public class FulfillmentOrderTests : IClassFixture<FulfillmentOrderFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly FulfillmentOrderMockClient _badRequestMockClient;
    private readonly FulfillmentOrderMockClient _okEmptyMockClient;
    private readonly FulfillmentOrderMockClient _okInvalidJsonMockClient;

    public FulfillmentOrderTests(FulfillmentOrderFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new FulfillmentOrderMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new FulfillmentOrderMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new FulfillmentOrderMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private FulfillmentOrderFixture Fixture { get; }

    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task CancelFulfillmentOrderAsync_CanCreate()
    {
        var acceptedResponse = await CreateOrderWithAcceptedFulfillment();

        var cancellationRequest = await Fixture.Service.CancellationRequest.SendCancellationRequestAsync(acceptedResponse.Id,
            new SendCancellationRequestRequest()
                { CancellationRequest = new MessageDetail() { Message = "Test cancellation" } });
        Assert.Contains(FulfillmentOrderActions.CancelFulfillmentOrder, cancellationRequest.Result.FulfillmentOrder.SupportedActions);

        var response = await Fixture.Service.FulfillmentOrder.CancelFulfillmentOrderAsync(acceptedResponse.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(10)]
    public async Task MarkFulfillmentOrderAsIncompleteAsync_CanCreate()
    {
        var acceptedResponse = await CreateOrderWithAcceptedFulfillment();
        Assert.Equal(FulfillmentOrderStatus.InProgress, acceptedResponse.Status);
        var request = new MarkFulfillmentOrderAsIncompleteRequest()
        {
            FulfillmentOrder = new()
            {
                Message = "Not enough inventory to complete this work."
            }
        };
        var response = await Fixture.Service.FulfillmentOrder.MarkFulfillmentOrderAsIncompleteAsync(acceptedResponse.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(10)]
    public async Task ApplyFulfillmentHoldOnFulfillmentOrderAsync_CanCreate()
    {
        var acceptedResponse = await CreateOrderWithAcceptedFulfillment();
        //Assert.Equal(FulfillmentOrderStatus.Open, acceptedResponse.Status);
        var request = new ApplyFulfillmentHoldOnOpenFulfillmentOrderRequest()
        {
            FulfillmentHold = new()
            {
                Reason = FulfillmentHoldReason.InventoryOutOfStock,
                ReasonNotes = "Not enough inventory to complete this work"
            }
        };
        
        var response = await Fixture.Service.FulfillmentOrder.ApplyFulfillmentHoldOnOpenFulfillmentOrderAsync(acceptedResponse.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(10)]
    public async Task MoveFulfillmentOrderToNewLocationAsync_CanCreate()
    {
        var acceptedResponse = await CreateOrderWithAcceptedFulfillment();
        var locationResponse =
            await Fixture.Service.LocationsForMove.ListLocationsThatFulfillmentOrderCanPotentiallyMoveToAsync(
                acceptedResponse.Id);

        var request = new MoveFulfillmentOrderToNewLocationRequest()
        {
            FulfillmentOrder = new()
            {
                NewLocationId = locationResponse.Result.LocationsForMove.First().Location?.Id
            }
        };
        var response = await Fixture.Service.FulfillmentOrder.MoveFulfillmentOrderToNewLocationAsync(acceptedResponse.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(10)]
    public async Task MarkFulfillmentOrderAsOpenAsync_CanCreate()
    {
        var acceptedResponse = await CreateOrderWithAcceptedFulfillment();
        Assert.Contains(FulfillmentOrderActions.MarkAsOpen, acceptedResponse.SupportedActions);
        var response = await Fixture.Service.FulfillmentOrder.MarkFulfillmentOrderAsOpenAsync(acceptedResponse.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(10)]
    public async Task ReleaseFulfillmentHoldOnFulfillmentOrderAsync_CanCreate()
    {
        var acceptedResponse = await CreateOrderWithAcceptedFulfillment();
        Assert.Contains(FulfillmentOrderActions.ReleaseHold, acceptedResponse.SupportedActions);
        var response = await Fixture.Service.FulfillmentOrder.ReleaseFulfillmentHoldOnFulfillmentOrderAsync(acceptedResponse.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(10)]
    public async Task RescheduleFulfillAtTimeOfScheduledFulfillmentOrderAsync_CanCreate()
    {
        var acceptedResponse = await CreateOrderWithAcceptedFulfillment();
        var request = new RescheduleFulfillAtTimeOfScheduledFulfillmentOrderRequest()
        {
            FulfillmentOrder = new()
            {
                NewFulfillAt = DateTimeOffset.Now.AddDays(7)
            }
        };
        var response = await Fixture.Service.FulfillmentOrder.RescheduleFulfillAtTimeOfScheduledFulfillmentOrderAsync(acceptedResponse.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    #endregion Create

    #region Read
    
    [SkippableFact, TestPriority(20)]
    public async Task ListFulfillmentOrdersAsync_AdditionalPropertiesAreEmpty()
    {
        var acceptedResponse = await CreateOrderWithAcceptedFulfillment();
        var response = await Fixture.Service.FulfillmentOrder.ListFulfillmentOrdersForSpecificOrderAsync(acceptedResponse.OrderId ?? 0);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var fulfillmentOrder in response.Result.FulfillmentOrders)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(fulfillmentOrder, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.FulfillmentOrders.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetFulfillmentOrderAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        var acceptedResponse = await CreateOrderWithAcceptedFulfillment();
        Skip.If(acceptedResponse == null, "Must be run with create test");
        var response = await Fixture.Service.FulfillmentOrder.GetFulfillmentOrderAsync(acceptedResponse.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Misc

    private async Task<FulfillmentOrderWithOrigin> CreateOrderWithAcceptedFulfillment()
    {
        var order = await Fixture.CreateOrder(Fixture.ProductVariant);
        Fixture.CreatedOrders.Add(order);
        var sendFulfillmentResponse = await Fixture.SendFulfillmentRequest(order);

        var submittedFulfillmentOrder = sendFulfillmentResponse.SubmittedFulfillmentOrder;

        var acceptFulfillment = await Fixture.Service.FulfillmentRequest.AcceptFulfillmentRequestAsync(
            submittedFulfillmentOrder?.Id ?? 0,
            new AcceptFulfillmentRequestRequest() { FulfillmentRequest = new MessageDetail() { Message = "We will start processing your fulfillment on the next business day." } });

        return acceptFulfillment.Result.FulfillmentOrder;
    }

    #endregion Misc

    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class FulfillmentOrderMockClient : FulfillmentOrderClient, IMockTests
{
    public FulfillmentOrderMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListFulfillmentOrdersForSpecificOrderAsync(0, CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListFulfillmentOrdersForSpecificOrderAsync(0, CancellationToken.None));
    }
}
