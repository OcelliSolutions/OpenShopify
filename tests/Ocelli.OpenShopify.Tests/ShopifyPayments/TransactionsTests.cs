using System.Collections.Generic;

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
    
    [Fact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [Fact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class TransactionsMockClient : TransactionsClient, IMockTests
{
    public TransactionsMockClient(HttpClient httpClient, TransactionsFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        throw new XunitException("Not implemented.");
    }
}
