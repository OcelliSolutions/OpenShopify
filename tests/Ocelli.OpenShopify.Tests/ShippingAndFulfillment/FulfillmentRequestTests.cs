using System.Collections.Generic;
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
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private FulfillmentRequestFixture Fixture { get; }
    /*
    [SkippableFact, TestPriority(10)]
    public async Task CreateFulfillmentRequestAsync_CanCreate()
    {
        var request = Fixture.CreateFulfillmentRequestRequest();
        var response = await Fixture.Service.FulfillmentRequest.SendFulfillmentRequestAsync(Fixture.FulfillmentOrder.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedFulfillmentRequests.Add(response.Result.FulfillmentRequest);
    }
    */
}
