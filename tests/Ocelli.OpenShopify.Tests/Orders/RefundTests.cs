using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Orders;

public class RefundFixture : SharedFixture, IAsyncLifetime
{
    public List<Refund> CreatedRefunds = new();
    public Order Order = new();
    public Product Product = new();
    public OrdersService Service;

    public RefundFixture() =>
        Service = new OrdersService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync()
    {
        await CreateProduct();
        await CreateOrder();
    }

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

    public async Task CreateProduct()
    {
        var productService = new ProductsService(MyShopifyUrl, AccessToken);
        var request = CreateProductRequest();
        request.Product.Variants ??= new List<ProductVariant>();
        request.Product.Variants.Add(new ProductVariant { Sku = BatchId });
        var productResponse = await productService.Product.CreateProductAsync(request);
        Product = productResponse.Result.Product;
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
                        VariantId = Product.Variants!.First().Id,
                        Quantity = 1
                    }
                }
            }
        };
        var response = await orderService.Order.CreateOrderAsync(request);
        Order = response.Result.Order;
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class RefundTests : IClassFixture<RefundFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public RefundTests(RefundFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private RefundFixture Fixture { get; }

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateRefundAsync_CanCreate()
    {
        var request = new CreateRefundRequest
        {
            Refund = new CreateRefund
            {
                Currency = "USD",
                Shipping = new Shipping
                {
                    Amount = (decimal)5.00
                },
                Transactions = new List<Transaction>
                {
                    new()
                    {
                        ParentId = Fixture.Order.Id, 
                        Amount = (decimal)5.00, 
                        Kind = TransactionKind.Refund,
                        Gateway = "bogus"
                    }
                }
            }
        };
        var response = await Fixture.Service.Refund.CreateRefundAsync(Fixture.Order.Id, body: request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedRefunds.Add(response.Result.Refund);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateRefundAsync_IsUnprocessableEntityError()
    {
        var request = new CreateRefundRequest
        {
            Refund = new CreateRefund()
        };
        await Assert.ThrowsAsync<ApiException<CreateRefundRequestError>>(async () =>
            await Fixture.Service.Refund.CreateRefundAsync(Fixture.Order.Id));
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CalculateRefundAsync_CanCalculate()
    {
        var response = await Fixture.Service.Refund.CalculateRefundAsync(Fixture.Order.Id, "USD");
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedRefunds.Add(response.Result.Refund);
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListRefundsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Refund.ListRefundsForOrderAsync(Fixture.Order.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var refund in response.Result.Refunds)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(refund, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Refunds.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetRefundAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedRefunds.Any(), "Must be run with create test");
        var refund = Fixture.CreatedRefunds.First();
        var response = await Fixture.Service.Refund.GetRefundAsync(Fixture.Order.Id, refund.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Refund, Fixture.MyShopifyUrl);
    }

    #endregion Read
}