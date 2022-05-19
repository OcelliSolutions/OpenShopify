using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Billing;

[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ApplicationChargeTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public ApplicationChargeTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }
    /*
    [SkippableFact]
    public async Task RetrieveListOfApplicationChargesAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var service = new BillingService(Fixture.MyShopifyUrl, Fixture.AccessToken);
        var result = await service.ApplicationCharge.RetrieveListOfApplicationChargesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(result, Fixture.MyShopifyUrl);

        if (result.ApplicationCharges != null && !result.ApplicationCharges.Any())
        {
            Skip.If(result.ApplicationCharges == null || !result.ApplicationCharges.Any(),
                "WARN: No data returned. Could not test");
            return;
        }

        Debug.Assert(result.ApplicationCharges != null, "result.ApplicationCharges != null");
        foreach (var token in result.ApplicationCharges)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(token, Fixture.MyShopifyUrl);
        }

        Assert.NotEmpty(result.ApplicationCharges);
    }
    */
}
