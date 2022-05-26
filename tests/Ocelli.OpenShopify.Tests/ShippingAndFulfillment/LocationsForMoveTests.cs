using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;
public class LocationsForMoveFixture : SharedFixture, IAsyncLifetime
{
    public ShippingAndFulfillmentService Service;
    public Product Product = new();
    public Order Order = new();
    public FulfillmentOrder FulfillmentOrder = new();
    public List<LocationsForMove> CreatedLocationsForMoves = new();

    public LocationsForMoveFixture()
    {
        Service = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);
    }

    public async Task InitializeAsync()
    {
        await CreateProduct();
        await CreateOrder();
        //await CreateFulfillmentOrder();
    }

    public async Task CreateProduct()
    {
        var request = base.CreateProductRequest();
        var service = new ProductsService(MyShopifyUrl, AccessToken);
        var response = await service.Product.CreateProductAsync(request);
        Product = response.Result.Product;

    }
    public async Task CreateOrder()
    {
        var request = base.CreateOrderRequest(Product.Variants!.First().Id);
        var service = new OrdersService(MyShopifyUrl, AccessToken);
        var response = await service.Order.CreateOrderAsync(request);
        Order = response.Result.Order;
    }
    /*
    public async Task CreateFulfillmentOrder()
    {
        var request = CreateFulfillmentOrderRequest();
        var response = await Service.FulfillmentOrder.
    }*/

    public async Task DisposeAsync()
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
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class LocationsForMoveTests : IClassFixture<LocationsForMoveFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    public LocationsForMoveTests(LocationsForMoveFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private LocationsForMoveFixture Fixture { get; }
    
    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task ListLocationsForMovesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.LocationsForMove.ListLocationsThatFulfillmentOrderCanPotentiallyMoveToAsync(Fixture.FulfillmentOrder.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var locationsForMove in response.Result.LocationsForMoves)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(locationsForMove, Fixture.MyShopifyUrl);
        }
        Skip.If(!response.Result.LocationsForMoves.Any(), "No results returned. Unable to test");
    }

    #endregion Read
}
