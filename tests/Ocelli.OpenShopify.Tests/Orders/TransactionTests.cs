using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Orders;

public class TransactionFixture : SharedFixture, IAsyncLifetime
{
    public List<Transaction> CreatedTransactions = new();
    public Order Order = new();
    public Product Product = new();
    public OrdersService Service;

    public TransactionFixture() =>
        Service = new OrdersService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync()
    {
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
    }

    public async Task CreateProduct()
    {
        var productService = new ProductsService(MyShopifyUrl, AccessToken);
        var request = CreateProductRequest();
        request.Product.Title = $@"{Company} OrderTransaction {BatchId}";
        var productResponse = await productService.Product.CreateProductAsync(request);
        Product = productResponse.Result.Product;
    }

    public async Task CreateOrder()
    {
        var orderService = new OrdersService(MyShopifyUrl, AccessToken);
        var request = base.CreateOrderRequest(Product.Variants!.First().Id);
        var response = await orderService.Order.CreateOrderAsync(request);
        Order = response.Result.Order;
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class TransactionTests : IClassFixture<TransactionFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;


    public TransactionTests(TransactionFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private TransactionFixture Fixture { get; }


    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateTransactionAsync_CanCreate()
    {
        var request = new CreateTransactionRequest
        {
            Transaction = new CreateTransaction
            {
                Currency = "USD",
                Amount = (decimal)10.00,
                Kind = TransactionKind.Capture,
                ParentId = Fixture.Order.Id
            }
        };
        var response = await Fixture.Service.Transaction.CreateTransactionForOrderAsync(Fixture.Order.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedTransactions.Add(response.Result.Transaction);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateTransactionAsync_IsUnprocessableEntityError()
    {
        var request = new CreateTransactionRequest
        {
            Transaction = new CreateTransaction()
        };
        await Assert.ThrowsAsync<ApiException<CreateTransactionRequestError>>(async () =>
            await Fixture.Service.Transaction.CreateTransactionForOrderAsync(Fixture.Order.Id, request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountTransactionsAsync_CanGet()
    {
        var response = await Fixture.Service.Transaction.CountOrdersTransactionsAsync(Fixture.Order.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListTransactionsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Transaction.ListTransactionsAsync(Fixture.Order.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var transaction in response.Result.Transactions)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(transaction, Fixture.MyShopifyUrl);
        }

        var list = response.Result.Transactions;
        Skip.If(!list.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetTransactionAsync_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedTransactions.Any(), "No results returned. Unable to test");
        var response =
            await Fixture.Service.Transaction.GetTransactionAsync(Fixture.Order.Id,
                Fixture.CreatedTransactions.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Transaction, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete
}