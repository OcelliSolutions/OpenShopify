namespace Ocelli.OpenShopify.Tests.Orders;

public class TransactionFixture : SharedFixture, IAsyncLifetime
{
    public List<Transaction> CreatedTransactions = new();
    public Order Order = new();
    public Product Product = new();
    public IOrdersService Service;

    public TransactionFixture() =>
        Service = new OrdersService(MyShopifyUrl, AccessToken);

    public async Task InitializeAsync()
    {
        Product = await CreateProduct();
        Order = await CreateOrder(Product.Variants!.First());
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
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("TransactionTests")]
public class TransactionTests : IClassFixture<TransactionFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly TransactionMockClient _badRequestMockClient;
    private readonly TransactionMockClient _okEmptyMockClient;
    private readonly TransactionMockClient _okInvalidJsonMockClient;

    public TransactionTests(TransactionFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new TransactionMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new TransactionMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new TransactionMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private TransactionFixture Fixture { get; }


    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateTransactionAsync_CanCreate()
    {
        var request = new CreateTransactionForOrderRequest()
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
        var request = new CreateTransactionForOrderRequest()
        {
            Transaction = new CreateTransaction()
        };
        await Assert.ThrowsAsync<ApiException>(async () =>
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


    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class TransactionMockClient : TransactionClient, IMockTests
{
    public TransactionMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnDataAsync()
    {
        ReadResponseAsString = true;
        //TODO: Validate that all methods are tested in this first section
        await Assert.ThrowsAsync<ApiException>(async () => await ListTransactionsAsync(0));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListTransactionsAsync(0));
    }
}
