using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.StoreProperties;

public class CurrencyFixture : SharedFixture, IAsyncLifetime
{
    public List<Currency> CreatedCurrencies = new();
    public StorePropertiesService Service;

    public CurrencyFixture() =>
        Service = new StorePropertiesService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CurrencyTests : IClassFixture<CurrencyFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public CurrencyTests(CurrencyFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private CurrencyFixture Fixture { get; }

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListCurrenciesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Currency.ListCurrenciesEnabledOnShopAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var currency in response.Result.Currencies)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(currency, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Currencies.Any(), "No results returned. Currencies must be added manually. https://help.shopify.com/en/manual/payments/shopify-payments/multi-currency/setup");
    }

    #endregion Read
}