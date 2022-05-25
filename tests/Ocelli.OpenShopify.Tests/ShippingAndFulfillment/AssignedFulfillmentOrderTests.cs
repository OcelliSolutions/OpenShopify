using System;
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
    public Product Product = new();
    public ProductVariant ProductVariant = new();
    public Order Order = new ();
    
    public async Task CreateFulfillmentService()
    {
        var fulfillmentService = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);
        var request = base.CreateFulfillmentServiceRequest;
        request.FulfillmentService.CallbackUrl += "/assigned_fulfillment_order";
        var response = await fulfillmentService.FulfillmentService.CreateFulfillmentServiceAsync(request);
        FulfillmentService = response.Result.FulfillmentService;
    }
    public async Task CreateProduct()
    {
        var productService = new ProductsService(MyShopifyUrl, AccessToken);
        var request = base.CreateProductRequest;
        request.Product.Variants ??= new List<ProductVariant>();
        request.Product.Variants.Add(new (){Sku = BatchId});
        var productResponse = await productService.Product.CreateProductAsync(request);
        Product = productResponse.Result.Product;

        if (Product.Variants != null)
        {
            var variant = Product.Variants.First();
            var variantRequest = new UpdateProductVariantRequest()
            {
                Variant = new()
                {
                    Id = variant.Id,
                    Sku = BatchId,
                    FulfillmentService = FulfillmentService.Handle,
                    Option1 = variant.Option1
                }
            };
            var variantResponse = await productService.ProductVariant.UpdateProductVariantAsync(variant.Id, variantRequest);
            ProductVariant = variantResponse.Result.Variant;
            Product.Variants.Remove(variant);
            Product.Variants.Add(ProductVariant);
        }
    }

    public async Task CreateOrder()
    {
        var orderService = new OrdersService(MyShopifyUrl, AccessToken);
        var request = new CreateOrderRequest()
        {
            Order = new()
            {
                Email = Email,
                LineItems = new List<LineItem>()
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

    public async Task InitializeAsync()
    {
        await CreateFulfillmentService();
        await CreateProduct();
        await CreateOrder();
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
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ShippingAndFulfillmentService _service;

    public AssignedFulfillmentOrderTests(ITestOutputHelper testOutputHelper, AssignedFulfillmentOrderFixture fixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new ShippingAndFulfillmentService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private AssignedFulfillmentOrderFixture Fixture { get; }

    #region Create - NA

    #endregion Create - NA

    #region Read

    [SkippableFact, TestPriority(20)]
    public async Task ListAssignedFulfillmentOrdersAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await _service.AssignedFulfillmentOrder.ListFulfillmentOrdersOnShopForSpecificAppAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var assignedFulfillmentOrder in response.Result.FulfillmentOrders)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(assignedFulfillmentOrder, Fixture.MyShopifyUrl);
        }
        var list = response.Result.FulfillmentOrders;
        Skip.If(!list.Any(), "No results returned. Unable to test");
    }

    #endregion Read

    #region Update - NA

    #endregion Update - NA

    #region Delete - NA

    #endregion Delete - NA
    
}