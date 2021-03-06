using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;
public class FulfillmentRequestFixture : SharedFixture, IAsyncLifetime
{
    public ShippingAndFulfillmentService Service;
    public FulfillmentService FulfillmentService = new();
    public Product Product = new();
    public ProductVariant ProductVariant = new();
    public FulfillmentOrder FulfillmentOrder = new();
    public Order Order = new();

    public FulfillmentRequestFixture()
    {
        Service = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);
    }
    public async Task InitializeAsync()
    {
        FulfillmentService = await CreateFulfillmentService(GetType().Name);
        Product = await CreateProduct(FulfillmentService, GetType().Name);
        ProductVariant = Product.Variants!.First(v => v.FulfillmentService != null);
        Order = await CreateOrder(ProductVariant, GetType().Name);
        var fulfillmentOrders = await GetFulfillmentOrders(Order);
        FulfillmentOrder = fulfillmentOrders.First();
        //Figure out how to populate FulfillmentOrder
    }

    public async Task<ShopifyResponse<SendFulfillmentRequestItem>> SendFulfillmentRequestAsync(string? message)
    {

        var request = new SendFulfillmentRequestRequest()
        {
            FulfillmentRequest = new SendFulfillmentRequestDetail()
            {
                Message = message
            }
        };
        var response = await Service.FulfillmentRequest.SendFulfillmentRequestAsync(FulfillmentOrder.Id, request);
        return response;
    }

    async Task IAsyncLifetime.DisposeAsync()
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

        if (FulfillmentService.Id > 0)
        {
            var fulfillmentService = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);
            await fulfillmentService.FulfillmentService.DeleteFulfillmentServiceAsync(FulfillmentService.Id);
        }
    }
}


 //TODO: this is non-standard and will require more work.
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class FulfillmentRequestTests : IClassFixture<FulfillmentRequestFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    public FulfillmentRequestTests(FulfillmentRequestFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _testOutputHelper = testOutputHelper;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private FulfillmentRequestFixture Fixture { get; }
    private readonly ITestOutputHelper _testOutputHelper;

    [SkippableFact, TestPriority(10)]
    public async Task SendFulfillmentRequestAsync_CanCreate()
    {
        var response = await Fixture.SendFulfillmentRequestAsync($@"@{Fixture.BatchId}, Fulfill this ASAP please.");
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result, Fixture.MyShopifyUrl);

        var originalFulfillmentOrder = response.Result.OriginalFulfillmentOrder;
        var submittedFulfillmentOrder = response.Result.SubmittedFulfillmentOrder;
        var unsubmittedFulfillmentOrder = response.Result.UnsubmittedFulfillmentOrder;

        Assert.Equal(RequestStatus.Submitted, submittedFulfillmentOrder?.RequestStatus);
        Assert.Equal(FulfillmentOrderStatus.Open, submittedFulfillmentOrder?.Status);
        Assert.Null(unsubmittedFulfillmentOrder); //no line items were specified, so there is nothing unsubmitted.
    }

    [SkippableFact, TestPriority(10)]
    public async Task AcceptFulfillmentRequestAsync_CanCreate()
    {
        var sendFulfillmentResponse = await Fixture.SendFulfillmentRequestAsync($@"@{Fixture.BatchId}, Fulfill this ASAP please.");
        
        var submittedFulfillmentOrder = sendFulfillmentResponse.Result.SubmittedFulfillmentOrder;

        var response = await Fixture.Service.FulfillmentRequest.AcceptFulfillmentRequestAsync(
            submittedFulfillmentOrder?.Id ?? 0,
            new AcceptFulfillmentRequestRequest() { FulfillmentRequest = new MessageDetail() { Message = "We will start processing your fulfillment on the next business day." } });
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result, Fixture.MyShopifyUrl);

        var acceptedResponse = response.Result.FulfillmentOrder;
        Assert.Equal(RequestStatus.Accepted, acceptedResponse.RequestStatus);
        Assert.Equal(FulfillmentOrderStatus.InProgress, acceptedResponse.Status);
    }


    [SkippableFact, TestPriority(10)]
    public async Task RejectFulfillmentRequestAsync_CanCreate()
    {
        var sendFulfillmentResponse = await Fixture.SendFulfillmentRequestAsync($@"@{Fixture.BatchId}, Fulfill this ASAP please.");

        var submittedFulfillmentOrder = sendFulfillmentResponse.Result.SubmittedFulfillmentOrder;

        var response = await Fixture.Service.FulfillmentRequest.RejectFulfillmentRequestAsync(
            submittedFulfillmentOrder?.Id ?? 0,
            new RejectFulfillmentRequestRequest() { FulfillmentRequest = new MessageDetail() { Message = "Not enough inventory on hand to complete the work." } });
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result, Fixture.MyShopifyUrl);

        var acceptedResponse = response.Result.FulfillmentOrder;
        Assert.Equal(RequestStatus.Rejected, acceptedResponse.RequestStatus);
        Assert.Equal(FulfillmentOrderStatus.Open, acceptedResponse.Status);
    }
}
