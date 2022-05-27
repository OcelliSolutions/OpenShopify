using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;

public class FulfillmentEventFixture : SharedFixture, IAsyncLifetime
{
    public List<FulfillmentEvent> CreatedFulfillmentEvents = new();
    public Fulfillment Fulfillment = new();
    public FulfillmentService FulfillmentService = new();
    public Order Order = new();
    public Product Product = new();
    public ProductVariant ProductVariant = new();
    public ShippingAndFulfillmentService Service;

    public FulfillmentEventFixture() =>
        Service = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync()
    {
        FulfillmentService = await CreateFulfillmentService();
        Product = await CreateProduct();
        ProductVariant = Product.Variants!.First();
        Order = await CreateOrder(ProductVariant);
        //Fulfillment = await CreateFulfillment(Order, FulfillmentService);
        await GetFulfillment();
    }

    public async Task GetFulfillment()
    {
        var response = await Service.Fulfillment.GetFulfillmentsAssociatedWithOrderAsync(Order.Id);
        Fulfillment = response.Result.Fulfillments.First();
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteFulfillmentEventAsync_CanDelete();

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
    
    public async Task DeleteFulfillmentEventAsync_CanDelete()
    {
        foreach (var fulfillmentEvent in CreatedFulfillmentEvents)
        {
            _ = await Service.FulfillmentEvent.DeleteFulfillmentEventAsync(fulfillmentEvent.Id, Fulfillment.Id,
                Order.Id);
        }
        CreatedFulfillmentEvents.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class FulfillmentEventTests : IClassFixture<FulfillmentEventFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public FulfillmentEventTests(FulfillmentEventFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private FulfillmentEventFixture Fixture { get; }

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateFulfillmentEventAsync_CanCreate()
    {
        var request = new CreateFulfillmentEventRequest
        {
            FulfillmentEvent = new CreateFulfillmentEvent
            {
                Status = FulfillmentEventStatus.InTransit
            }
        };
        var response =
            await Fixture.Service.FulfillmentEvent.CreateFulfillmentEventAsync(Fixture.Fulfillment.Id, Fixture.Order.Id,
                request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedFulfillmentEvents.Add(response.Result.FulfillmentEvent);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateFulfillmentEventAsync_IsUnprocessableEntityError()
    {
        var request = new CreateFulfillmentEventRequest
        {
            FulfillmentEvent = new CreateFulfillmentEvent()
        };
        await Assert.ThrowsAsync<ApiException<FulfillmentEventError>>(async () =>
            await Fixture.Service.FulfillmentEvent.CreateFulfillmentEventAsync(Fixture.Fulfillment.Id, Fixture.Order.Id,
                request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListFulfillmentEventsAsync_AdditionalPropertiesAreEmpty()
    {
        var response =
            await Fixture.Service.FulfillmentEvent.ListFulfillmentEventsForSpecificFulfillmentAsync(
                Fixture.Fulfillment.Id, Fixture.Order.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var fulfillmentEvent in response.Result.FulfillmentEvents)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(fulfillmentEvent, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.FulfillmentEvents.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetFulfillmentEventAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedFulfillmentEvents.Any(), "Must be run with create test");
        var fulfillmentEvent = Fixture.CreatedFulfillmentEvents.First();
        var response =
            await Fixture.Service.FulfillmentEvent.GetFulfillmentEventAsync(fulfillmentEvent.Id, Fixture.Fulfillment.Id,
                Fixture.Order.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.FulfillmentEvent, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete


    [SkippableFact, TestPriority(99)]
    public async Task DeleteFulfillmentEventAsync_CanDelete()
    {
        await Fixture.DeleteFulfillmentEventAsync_CanDelete();
    }

    #endregion
    }