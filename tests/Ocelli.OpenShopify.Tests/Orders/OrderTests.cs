using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Orders;

public class OrderFixture : SharedFixture, IAsyncLifetime
{
    public List<Order> CreatedOrders = new();
    public Product Product = new();
    public OrdersService Service;

    public OrderFixture() =>
        Service = new OrdersService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync() => await CreateProduct();

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteOrderAsync_CanDelete();

        if (Product.Id > 0)
        {
            var productService = new ProductsService(MyShopifyUrl, AccessToken);
            await productService.Product.DeleteProductAsync(Product.Id);
        }
    }

    public async Task CreateProduct()
    {
        var productService = new ProductsService(MyShopifyUrl, AccessToken);
        var request = CreateProductRequest();
        request.Product.Variants ??= new List<ProductVariant>();
        request.Product.Variants.Add(new ProductVariant { Sku = BatchId });
        var productResponse = await productService.Product.CreateProductAsync(request);
        Product = productResponse.Result.Product;
    }

    public async Task DeleteOrderAsync_CanDelete()
    {
        foreach (var order in CreatedOrders)
        {
            _ = await Service.Order.DeleteOrderAsync(order.Id);
        }

        CreatedOrders.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class OrderTests : IClassFixture<OrderFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public OrderTests(OrderFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private OrderFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateOrderAsync_CanUpdate()
    {
        var originalOrder = Fixture.CreatedOrders.First();
        var request = new UpdateOrderRequest
        {
            Order = new UpdateOrder
            {
                Id = originalOrder.Id,
                Note = $@"{originalOrder.Note} | Customer contacted us about a custom engraving on this iPod"
            }
        };
        var response = await Fixture.Service.Order.UpdateOrderAsync(request.Order.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedOrders.Remove(originalOrder);
        Fixture.CreatedOrders.Add(response.Result.Order);
    }

    #endregion Update

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteOrderAsync_CanDelete() => await Fixture.DeleteOrderAsync_CanDelete();

    #endregion Delete

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateOrderAsync_CanCreate()
    {
        var request = Fixture.CreateOrderRequest(Fixture.Product.Variants!.First().Id);
        var response = await Fixture.Service.Order.CreateOrderAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedOrders.Add(response.Result.Order);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateOrderAsync_IsUnprocessableEntityError()
    {
        var request = new CreateOrderRequest
        {
            Order = new CreateOrder()
        };
        await Assert.ThrowsAsync<ApiException<OrderError>>(async () =>
            await Fixture.Service.Order.CreateOrderAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountOrdersAsync_CanGet()
    {
        var response = await Fixture.Service.Order.CountOrdersAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListOrdersAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Order.ListOrdersAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var order in response.Result.Orders)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(order, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Orders.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetOrderAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedOrders.Any(), "Must be run with create test");
        var order = Fixture.CreatedOrders.First();
        var response = await Fixture.Service.Order.GetOrderAsync(order.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Order, Fixture.MyShopifyUrl);
    }

    #endregion Read
}