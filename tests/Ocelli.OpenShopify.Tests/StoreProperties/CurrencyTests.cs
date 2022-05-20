using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.StoreProperties;

[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CurrencyTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public CurrencyTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }

    /*
    [SkippableFact, TestPriority(20)]
    public async Task ListCurrenciesEnabledOnShopAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var service = new StorePropertiesService(Fixture.MyShopifyUrl, Fixture.AccessToken);

        var result =
            await service.Currency.ListCurrenciesEnabledOnShopAsync(CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(result, Fixture.MyShopifyUrl);

        Debug.Assert(result.Currencies != null, "result.Currencies != null");
        Skip.If(!result.Currencies.Any(), "No results returned.");
    }
    */
}
