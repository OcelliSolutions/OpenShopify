namespace Ocelli.OpenShopify.Tests.ShopifyPayments;

public class TransactionsFixture : SharedFixture, IAsyncLifetime
{
    public List<Transaction> CreatedTransactions = new();

    public TransactionsFixture() =>
        Service = new ShopifyPaymentsService(MyShopifyUrl, AccessToken);

    public IShopifyPaymentsService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("TransactionsTests")]
public class TransactionsTests : IClassFixture<TransactionsFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly TransactionsMockClient _badRequestMockClient;
    private readonly TransactionsMockClient _okEmptyMockClient;
    private readonly TransactionsMockClient _okInvalidJsonMockClient;

    public TransactionsTests(TransactionsFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new TransactionsMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new TransactionsMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new TransactionsMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private TransactionsFixture Fixture { get; }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListTransactionsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Transactions.ListBalanceTransactionsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var transaction in response.Result.Transactions)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(transaction, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Transactions.Any(), "No results returned. Unable to test");
    }

    #endregion Read


    #region Create - NA

    #endregion Create - NA

    #region Update - NA

    #endregion Update - NA

    #region Delete - NA

    #endregion Delete - NA
    
    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class TransactionsMockClient : TransactionsClient, IMockTests
{
    public TransactionsMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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
        await Assert.ThrowsAsync<ApiException>(async () => await ListBalanceTransactionsAsync(cancellationToken: CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListBalanceTransactionsAsync(cancellationToken: CancellationToken.None));
    }
}
