using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShopifyPayments;

public class TransactionsFixture : SharedFixture, IAsyncLifetime
{
    public List<Transaction> CreatedTransactions = new();

    public TransactionsFixture() =>
        Service = new ShopifyPaymentsService(MyShopifyUrl, AccessToken);

    public ShopifyPaymentsService Service { get; set; }

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class TransactionsTests : IClassFixture<TransactionsFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;


    public TransactionsTests(TransactionsFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
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
}