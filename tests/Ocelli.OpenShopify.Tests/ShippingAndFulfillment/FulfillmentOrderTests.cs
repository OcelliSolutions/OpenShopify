using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;
public class FulfillmentOrderFixture : SharedFixture, IAsyncLifetime
{
    public ShippingAndFulfillmentService Service;
    public FulfillmentService FulfillmentService = new();
    public Product Product = new();
    public ProductVariant ProductVariant = new();
    public FulfillmentOrder FulfillmentOrder = new();
    public Order Order = new();

    public FulfillmentOrderFixture()
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

 //TODO: This is non-standard and will require some more work.
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class FulfillmentOrderTests : IClassFixture<FulfillmentOrderFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    public FulfillmentOrderTests(FulfillmentOrderFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private FulfillmentOrderFixture Fixture { get; }

    #region Create

    [SkippableFact, TestPriority(10)]
    public async Task CancelFulfillmentOrderAsync_CanCreate()
    {
        Assert.Contains(FulfillmentOrderActions.CancelFulfillmentOrder, Fixture.FulfillmentOrder.SupportedActions!);
        var request = new CancelFulfillmentOrderRequest()
        {

        };
        var response = await Fixture.Service.FulfillmentOrder.CancelFulfillmentOrderAsync(Fixture.FulfillmentOrder.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(10)]
    public async Task MarkFulfillmentOrderAsIncompleteAsync_CanCreate()
    {
        Assert.Equal(FulfillmentOrderStatus.InProgress, Fixture.FulfillmentOrder.Status);
        var request = new MarkFulfillmentOrderAsIncompleteRequest()
        {

        };
        var response = await Fixture.Service.FulfillmentOrder.MarkFulfillmentOrderAsIncompleteAsync(Fixture.FulfillmentOrder.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(10)]
    public async Task ApplyFulfillmentHoldOnFulfillmentOrderWithStatusOPENAsync_CanCreate()
    {
        Assert.Equal(FulfillmentOrderStatus.Open, Fixture.FulfillmentOrder.Status);
        var request = new ApplyFulfillmentHoldOnFulfillmentOrderRequest()
        {
            FulfillmentHold = new()
            {
                Reason = FulfillmentHoldReason.InventoryOutOfStock,
                ReasonNotes = "Not enough inventory to complete this work"
            }
        };
        var response = await Fixture.Service.FulfillmentOrder.ApplyFulfillmentHoldOnFulfillmentOrderAsync(Fixture.FulfillmentOrder.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(10)]
    public async Task MoveFulfillmentOrderToNewLocationAsync_CanCreate()
    {
        var locationResponse =
            await Fixture.Service.LocationsForMove.ListLocationsThatFulfillmentOrderCanPotentiallyMoveToAsync(
                Fixture.FulfillmentOrder.Id);

        var request = new MoveFulfillmentOrderToNewLocationRequest()
        {
            FulfillmentOrder = new()
            {
                NewLocationId = locationResponse.Result.LocationsForMove.First().Location?.Id
            }
        };
        var response = await Fixture.Service.FulfillmentOrder.MoveFulfillmentOrderToNewLocationAsync(Fixture.FulfillmentOrder.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(10)]
    public async Task MarkFulfillmentOrderAsOpenAsync_CanCreate()
    {
        Assert.Contains(FulfillmentOrderActions.MarkAsOpen, Fixture.FulfillmentOrder.SupportedActions!);
        var request = new MarkFulfillmentOrderAsOpenRequest()
        {

        };
        var response = await Fixture.Service.FulfillmentOrder.MarkFulfillmentOrderAsOpenAsync(Fixture.FulfillmentOrder.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(10)]
    public async Task ReleaseFulfillmentHoldOnFulfillmentOrderAsync_CanCreate()
    {
        Assert.Contains(FulfillmentOrderActions.ReleaseHold, Fixture.FulfillmentOrder.SupportedActions!);
        var request = new ReleaseFulfillmentHoldOnFulfillmentOrderRequest()
        {
            //TODO: populate the request fields
        };
        var response = await Fixture.Service.FulfillmentOrder.ReleaseFulfillmentHoldOnFulfillmentOrderAsync(Fixture.FulfillmentOrder.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    [SkippableFact, TestPriority(10)]
    public async Task RescheduleFulfillAtTimeOfScheduledFulfillmentOrderAsync_CanCreate()
    {
        var request = new RescheduleFulfillAtTimeOfScheduledFulfillmentOrderRequest()
        {
            //TODO: populate the request fields
        };
        var response = await Fixture.Service.FulfillmentOrder.RescheduleFulfillAtTimeOfScheduledFulfillmentOrderAsync(Fixture.FulfillmentOrder.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    #endregion Create

    #region Read
    
    [SkippableFact, TestPriority(20)]
    public async Task ListFulfillmentOrdersAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.FulfillmentOrder.ListFulfillmentOrdersForSpecificOrderAsync(Fixture.Order.Id);
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
        Skip.If(Fixture.FulfillmentOrder == null, "Must be run with create test");
        var response = await Fixture.Service.FulfillmentOrder.GetFulfillmentOrderAsync(Fixture.FulfillmentOrder.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentOrder, Fixture.MyShopifyUrl);
    }

    #endregion Read
}
