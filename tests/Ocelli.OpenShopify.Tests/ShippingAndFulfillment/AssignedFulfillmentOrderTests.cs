using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;

public class AssignedFulfillmentOrderFixture : SharedFixture, IAsyncLifetime
{
    public FulfillmentService FulfillmentService = new();
    public Order Order = new();
    public Product Product = new();
    public ProductVariant ProductVariant = new();

    public AssignedFulfillmentOrderFixture() =>
        Service = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);

    public ShippingAndFulfillmentService Service { get; set; }

    public async Task InitializeAsync()
    {
        FulfillmentService = await CreateFulfillmentService();
        Product = await CreateProduct(FulfillmentService);
        ProductVariant = Product.Variants!.First(v => v.FulfillmentService != null);
        Order = await CreateOrder(ProductVariant);
        
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

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class AssignedFulfillmentOrderTests : IClassFixture<AssignedFulfillmentOrderFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;


    public AssignedFulfillmentOrderTests(AssignedFulfillmentOrderFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private AssignedFulfillmentOrderFixture Fixture { get; }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListAssignedFulfillmentOrdersAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.AssignedFulfillmentOrder.ListFulfillmentOrdersOnShopForSpecificAppAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var assignedFulfillmentOrder in response.Result.FulfillmentOrders)
        {
            Assert.NotNull(assignedFulfillmentOrder.OrderId);
            _additionalPropertiesHelper.CheckAdditionalProperties(assignedFulfillmentOrder, Fixture.MyShopifyUrl);
        }

        var list = response.Result.FulfillmentOrders;
        Skip.If(!list.Any(), "No results returned. Unable to test");
    }

    #endregion Read
}