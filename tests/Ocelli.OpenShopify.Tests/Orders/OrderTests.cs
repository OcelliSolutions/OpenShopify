using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class OrderTests : IClassFixture<OrderFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly OrdersService _service;

    public OrderTests(ITestOutputHelper testOutputHelper, OrderFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new OrdersService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private OrderFixture Fixture { get; }

    #region Create
    
    [SkippableFact, TestPriority(10), Description("Create a simple order with only a product variant ID and no optional parameters")]
    public async Task CreateOrderAsync_CanCreate()
    {
        var productService = new ProductsService(Fixture.MyShopifyUrl, Fixture.AccessToken);
        var productResponse = await productService.Product.ListProductsAsync(limit: 1);
        var product = productResponse.Result.Products.First();
        var variant = product.Variants?.First();
        var request = Fixture.CreateSimpleOrder(variant!.Id);
        var response = await _service.Order.CreateOrderAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Order, Fixture.MyShopifyUrl);

        Fixture.CreatedOrders.Add(response.Result.Order);
    }
    
    #endregion Create

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task CountOrdersAsync_CanGet()
    {
        var response = await _service.Order.CountOrdersAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Assert.True(count > 0);
    }

    [SkippableFact, TestPriority(20)]
    public async Task ListOrdersAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await _service.Order.ListOrdersAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var order in response.Result.Orders)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(order, Fixture.MyShopifyUrl);
        }
        var list = response.Result.Orders;
        Skip.If(!list.Any(), "No results returned. Unable to test");
    }

    [SkippableFact, TestPriority(20)]
    public async Task GetOrderAsync_AdditionalPropertiesAreEmpty()
    {
        var orderListResponse = await _service.Order.ListOrdersAsync(limit: 1);
        var response = await _service.Order.GetOrderAsync(orderListResponse.Result.Orders.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Order, Fixture.MyShopifyUrl);
    }
    #endregion Read

    #region Update

    [SkippableFact, TestPriority(30)]
    public async Task UpdateOrderAsync_CanUpdate()
    {
        var originalOrder = Fixture.CreatedOrders.First();
        var request = new UpdateOrderRequest()
        {
            Order = new()
            {
                Id = originalOrder.Id,
                NoteAttributes = new List<NoteAttribute>()
                {
                    new (){Name = "color", Value = "red"}
                }
            }
        };
        var response = await _service.Order.UpdateOrderAsync(request.Order.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedOrders.Remove(originalOrder);
        Fixture.CreatedOrders.Add(response.Result.Order);
    }

    #endregion Update

    #region Delete


    [SkippableFact, TestPriority(40)]
    public async Task DeleteOrderAsync_CanDelete()
    {
        Skip.If(Fixture.CreatedOrders.Count == 0, "WARN: No data returned. Could not test");
        var errors = new List<Exception>();
        foreach (var order in Fixture.CreatedOrders)
        {
            try
            {
                _ = await _service.Order.DeleteOrderAsync(order.Id);
            }
            catch (Exception ex)
            {
                errors.Add(ex);
            }
        }

        foreach (var error in errors)
        {
            _testOutputHelper.WriteLine(error.Message);
        }
        Assert.Empty(errors);
    }
    #endregion Delete
}
