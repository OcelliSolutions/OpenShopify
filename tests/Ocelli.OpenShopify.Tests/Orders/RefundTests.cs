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
        Product = await CreateProduct();
        Order = await CreateOrder(Product.Variants!.First());
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

    //TODO: mark the order as paid before issuing a refund: {"errors":{"transactions":["require a parent_id associated with the order"]}}
    public async Task CreateRefundAsync_CanCreate()
    {
        var request = new CreateRefundRequest
        {
            Refund = new CreateRefund
            {
                Currency = "USD",
                Shipping = new Shipping
                {
                    Amount = (decimal)1.00
                },
                Transactions = new List<Transaction>
                {
                    new()
                    {
                        ParentId = Fixture.Order.Transactions?.First().Id ?? 0, 
                        Amount = (decimal)1.00, 
                        Kind = TransactionKind.Refund,
                        Gateway = "bogus"
                    }
                }
            }
        };
        var response = await Fixture.Service.Refund.CreateRefundAsync(Fixture.Order.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedRefunds.Add(response.Result.Refund);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateRefundAsync_BlankRequest_IsError()
    {
        var request = new CreateRefundRequest
        {
            Refund = new CreateRefund()
        };
        await Assert.ThrowsAsync<ApiException<RefundGeneralError>>(async () =>
            await Fixture.Service.Refund.CreateRefundAsync(Fixture.Order.Id, request));
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CalculateRefundAsync_CalculateTheRefundWithoutSpecifyingCurrency_CanCalculate()
    {
        var lineItem = Fixture.Order.LineItems!.First();
        var request = new CalculateRefundRequest()
        {
            Refund = new()
            {
                Shipping = new()
                {
                    FullRefund = true
                },
                RefundLineItems = new List<RefundLineItem>()
                {
                    new()
                    {
                        LineItemId = lineItem.Id,
                        Quantity = lineItem.Quantity,
                        RestockType = RestockType.NoRestock
                    }
                }
            }
        };
        var response = await Fixture.Service.Refund.CalculateRefundAsync(Fixture.Order.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedRefunds.Add(response.Result.Refund);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CalculateRefundAsync_CalculateTheRefundForLineItemAndShipping_CanCalculate()
    {
        var lineItem = Fixture.Order.LineItems!.First();
        var request = new CalculateRefundRequest()
        {
            Refund = new()
            {
                Currency = "USD",
                Shipping = new()
                {
                    FullRefund = true
                },
                RefundLineItems = new List<RefundLineItem>()
                {
                    new()
                    {
                        LineItemId = lineItem.Id,
                        Quantity = lineItem.Quantity,
                        RestockType = RestockType.NoRestock
                    }
                }
            }
        };
        var response = await Fixture.Service.Refund.CalculateRefundAsync(Fixture.Order.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedRefunds.Add(response.Result.Refund);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CalculateRefundAsync_CalculateRefundForPartialAmountOfShipping_CanCalculate()
    {
        var request = new CalculateRefundRequest()
        {
            Refund = new()
            {
                Currency = "USD",
                Shipping = new()
                {
                    Amount = (decimal)1.0
                }
            }
        };
        var response = await Fixture.Service.Refund.CalculateRefundAsync(Fixture.Order.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedRefunds.Add(response.Result.Refund);
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListRefundsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Refund.ListRefundsAsync(Fixture.Order.Id);
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