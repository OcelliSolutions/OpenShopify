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
        await CreateFulfillmentService();
        await CreateProduct();
        await CreateOrder();
        await CreateFulfillment();
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

    public async Task CreateFulfillmentService()
    {
        var fulfillmentService = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);
        var request = CreateFulfillmentServiceRequest();
        request.FulfillmentService.CallbackUrl += "/fulfillment_event";
        var response = await fulfillmentService.FulfillmentService.CreateFulfillmentServiceAsync(request);
        FulfillmentService = response.Result.FulfillmentService;
    }

    public async Task CreateProduct()
    {
        var productService = new ProductsService(MyShopifyUrl, AccessToken);
        var request = CreateProductRequest();
        request.Product.Variants ??= new List<ProductVariant>();
        request.Product.Variants.Add(new ProductVariant { Sku = BatchId });
        var productResponse = await productService.Product.CreateProductAsync(request);
        Product = productResponse.Result.Product;

        if (Product.Variants != null)
        {
            var variant = Product.Variants.First();
            var variantRequest = new UpdateProductVariantRequest
            {
                Variant = new UpdateProductVariant
                {
                    Id = variant.Id,
                    Sku = BatchId,
                    FulfillmentService = FulfillmentService.Handle,
                    Option1 = variant.Option1
                }
            };
            var variantResponse =
                await productService.ProductVariant.UpdateProductVariantAsync(variant.Id, variantRequest);
            ProductVariant = variantResponse.Result.Variant;
            Product.Variants.Remove(variant);
            Product.Variants.Add(ProductVariant);
        }
    }

    public async Task CreateOrder()
    {
        var orderService = new OrdersService(MyShopifyUrl, AccessToken);
        var request = new CreateOrderRequest
        {
            Order = new CreateOrder
            {
                Email = Email,
                LineItems = new List<LineItem>
                {
                    new()
                    {
                        VariantId = ProductVariant.Id,
                        Quantity = 1
                    }
                }
            }
        };
        var response = await orderService.Order.CreateOrderAsync(request);
        Order = response.Result.Order;
    }

    public async Task CreateFulfillment()
    {
        //TODO: Figure out what objects can have a `test` property and validate accordingly.
        var request = new CreateFulfillmentRequest
        {
            Fulfillment = new CreateFulfillment
            {
                LocationId = Fulfillment.LocationId,
                TrackingNumbers = new List<string> { "123456789" },
                TrackingUrls = new List<string>
                {
                    "https://shipping.xyz/track.php?num=123456789", "https://anothershipper.corp/track.php?code=abc"
                },
                NotifyCustomer = true
            }
        };
        var response = await Service.Fulfillment.CreateFulfillmentAsync(Order.Id, request);
        Fulfillment = response.Result.Fulfillment;
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